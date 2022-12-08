using System;
using Cake.Core.Diagnostics;
using Cake.Pnpm.Install;
using Cake.Testing.Fixtures;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Install;

[TestFixture]
[TestOf(typeof(PnpmInstaller))]
public class PnpmInstallerTests
{
    private PnpmInstallerFixture _fixture;

    [SetUp]
    public void Init()
    {
        _fixture = new PnpmInstallerFixture();
    }

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
        // Given
        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("install"));
    }

    [TestCaseSource(typeof(TestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmInstallSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }

    [TestCase(false, true, " --prod")]
    [TestCase(false, false, "")]
    [TestCase(true, false, " --dev")]
    public void Should_Not_Throw_Exception_If_Dev_Prod_Not_Conflicting(bool dev, bool prod, string argumentValue)
    {
        // Given
        _fixture.Settings = new PnpmInstallSettings
        {
            Dev = dev,
            Prod = prod
        };

        // When
        ToolFixtureResult Result() => _fixture.Run();

        // Then
        Assert.That((Func<ToolFixtureResult>) Result, Throws.Nothing);
        Assert.That(Result().Args, Is.EqualTo($"install{argumentValue}"));
    }


    [Test]
    public void Should_Throw_Exception_If_Dev_Prod_Conflicting()
    {
        // Given
        _fixture.Settings = new PnpmInstallSettings
        {
            Dev = true,
            Prod = true
        };

        // When
        ToolFixtureResult Result() => _fixture.Run();

        // Then
        Assert.That((Func<ToolFixtureResult>) Result, Throws.ArgumentException);
    }

    [TestCase(true, true, "")]
    [TestCase(true, false, "*")]
    [TestCase(false, true, "*")]
    public void Should_Throw_Exception_If_Hoist_Conflicting(bool shamefullyHoist, bool noHoist, string hoistPattern)
    {
        // Given
        _fixture.Settings = new PnpmInstallSettings
        {
            ShamefullyHoist = shamefullyHoist,
            NoHoist = noHoist,
            HoistPattern = hoistPattern
        };

        // When
        ToolFixtureResult Result() => _fixture.Run();

        // Then
        Assert.That((Func<ToolFixtureResult>) Result, Throws.ArgumentException);
    }

    [TestCase(Verbosity.Diagnostic, "install --loglevel debug")]
    [TestCase(Verbosity.Minimal, "install --loglevel warn")]
    [TestCase(Verbosity.Normal, "install")]
    [TestCase(Verbosity.Quiet, "install --silent")]
    [TestCase(Verbosity.Verbose, "install --loglevel info")]
    public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
        Verbosity verbosity,
        string expected)
    {
        // Given
        _fixture.Settings = new PnpmInstallSettings
        {
            CakeVerbosityLevel = verbosity
        };

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo(expected));
    }
}






