using System;
using Cake.Core.Diagnostics;
using Cake.Pnpm.Update;
using Cake.Testing.Fixtures;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Update;

[TestFixture]
[TestOf(typeof(PnpmUpdate))]
public class PnpmUpdateTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmUpdateFixture();
    }

    private PnpmUpdateFixture _fixture;

    [Test]
    public void Should_Throw_If_Settings_Are_Null()
    {
        // Given
        _fixture.Settings = null;

        // When
        // Then
        Assert.That(_fixture.Run, Throws.ArgumentNullException);
    }

    [Test]
    public void Should_Add_Mandatory_Arguments()
    {
        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"update"));
    }

    [Test]
    public void Should_Add_Single_Package_If_Presented()
    {
        // Given
        _fixture.Settings.Packages.Add("foo@bar");

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("update \"foo@bar\""));
    }

    [Test]
    public void Should_Add_Few_Packages_If_Presented()
    {
        // Given
        _fixture.Settings.Packages.Add("foo@bar");
        _fixture.Settings.Packages.Add("baz@v1.0.0");

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"update \"foo@bar\" \"baz@v1.0.0\""));
    }

    [Test]
    public void Should_Add_Few_Packages_And_Parameters_If_Presented()
    {
        // Given
        _fixture.Settings.Packages.Add("foo@bar");
        _fixture.Settings.Packages.Add("baz@v1.0.0");
        _fixture.Settings.Color = true;

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"update \"foo@bar\" \"baz@v1.0.0\" --color"));
    }

    [TestCaseSource(typeof(UpdateTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmUpdateSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }

    [Test]
    public void Should_Throw_Exception_If_Dev_Prod_Conflicting()
    {
        // Given
        _fixture.Settings = new PnpmUpdateSettings()
        {
            Dev = true,
            Prod = true
        };

        // When
        ToolFixtureResult Result() => _fixture.Run();

        // Then
        Assert.That(Result, Throws.ArgumentException);
    }

    [TestCase(Verbosity.Diagnostic, "update --loglevel debug")]
    [TestCase(Verbosity.Minimal, "update --loglevel warn")]
    [TestCase(Verbosity.Normal, $"update")]
    [TestCase(Verbosity.Quiet, "update --silent")]
    [TestCase(Verbosity.Verbose, "update --loglevel info")]
    public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
        Verbosity verbosity,
        string expected)
    {
        // Given
        _fixture.Settings = new PnpmUpdateSettings {CakeVerbosityLevel = verbosity};

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo(expected));
    }
}
