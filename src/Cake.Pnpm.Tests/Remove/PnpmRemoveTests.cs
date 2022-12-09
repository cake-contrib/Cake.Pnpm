using Cake.Core.Diagnostics;
using Cake.Pnpm.Install;
using Cake.Pnpm.Remove;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Remove;

[TestFixture]
[TestOf(typeof(PnpmInstaller))]
public class PnpmRemoveTests
{
    private PnpmRemoveFixture _fixture;

    [SetUp]
    public void Init()
    {
        _fixture = new PnpmRemoveFixture();
    }

    [Test]
    public void Should_Throw_If_Settings_Are_Null()
    {
        // Given
        _fixture.Settings = null;

        // When
        // Then
        Assert.That( _fixture.Run, Throws.ArgumentNullException);
    }

    [Test]
    public void Should_Add_Mandatory_Arguments()
    {
        // Given

        _fixture.Settings.PackageName = RemoveTestCaseSource.StubPackageName;

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"remove \"{RemoveTestCaseSource.StubPackageName}\""));
    }

    [TestCaseSource(typeof(RemoveTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmRemoveSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }


    [TestCase(Verbosity.Diagnostic, $"remove \"{RemoveTestCaseSource.StubPackageName}\" --loglevel debug")]
    [TestCase(Verbosity.Minimal, $"remove \"{RemoveTestCaseSource.StubPackageName}\" --loglevel warn")]
    [TestCase(Verbosity.Normal, $"remove \"{RemoveTestCaseSource.StubPackageName}\"")]
    [TestCase(Verbosity.Quiet, $"remove \"{RemoveTestCaseSource.StubPackageName}\" --silent")]
    [TestCase(Verbosity.Verbose, $"remove \"{RemoveTestCaseSource.StubPackageName}\" --loglevel info")]
    public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
        Verbosity verbosity,
        string expected)
    {
        // Given
        _fixture.Settings = new PnpmRemoveSettings
        {
            PackageName = RemoveTestCaseSource.StubPackageName,
            CakeVerbosityLevel = verbosity
        };

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo(expected));
    }
}






