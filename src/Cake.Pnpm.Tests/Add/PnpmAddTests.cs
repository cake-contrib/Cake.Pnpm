﻿using Cake.Core.Diagnostics;
using Cake.Pnpm.Add;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Add;

[TestFixture]
[TestOf(typeof(PnpmAdd))]
public class PnpmAddTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmAddFixture();
    }

    private PnpmAddFixture _fixture;

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
        _fixture.Settings.PackageName = AddTestCaseSource.StubPackageName;
        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"add \"{AddTestCaseSource.StubPackageName}\""));
    }

    [TestCaseSource(typeof(AddTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmAddSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }

    [TestCase(Verbosity.Diagnostic, $"add \"{AddTestCaseSource.StubPackageName}\" --loglevel debug")]
    [TestCase(Verbosity.Minimal, $"add \"{AddTestCaseSource.StubPackageName}\" --loglevel warn")]
    [TestCase(Verbosity.Normal, $"add \"{AddTestCaseSource.StubPackageName}\"")]
    [TestCase(Verbosity.Quiet, $"add \"{AddTestCaseSource.StubPackageName}\" --silent")]
    [TestCase(Verbosity.Verbose, $"add \"{AddTestCaseSource.StubPackageName}\" --loglevel info")]
    public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
        Verbosity verbosity,
        string expected)
    {
        // Given
        _fixture.Settings = new PnpmAddSettings
            {CakeVerbosityLevel = verbosity, PackageName = AddTestCaseSource.StubPackageName};

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo(expected));
    }
}
