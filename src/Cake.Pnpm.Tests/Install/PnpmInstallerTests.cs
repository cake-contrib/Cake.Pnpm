using Cake.Core.Diagnostics;
using Cake.Pnpm.Install;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Install;

[TestFixture]
[TestOf(typeof(PnpmInstaller))]
public class PnpmInstallerTests
{
    [Test]
    public void Should_Throw_If_Settings_Are_Null()
    {
        // Given
        var fixture = new PnpmInstallerFixture
        {
            Settings = null
        };

        // When
        // Then
        Assert.That(fixture.Run, Throws.ArgumentNullException);
    }

    [Test]
    public void Should_Add_Mandatory_Arguments()
    {
        // Given
        var fixture = new PnpmInstallerFixture();

        // When
        var result = fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("install"));
    }

    [TestCaseSource(typeof(FlagsTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmInstallSettings settings)
    {
        // Given
        var fixture = new PnpmInstallerFixture
        {
            Settings = settings
        };

        // When
        var result = fixture.Run();

        // Then
        return result.Args;
    }

    [TestCase(false, true, " --prod")]
    [TestCase(false, false, "")]
    [TestCase(true, false, " --dev")]
    public void Should_Not_Throw_Exception_If_Dev_Prod_Not_Conflicting(bool dev, bool prod, string argumentValue)
    {
        // Given
        var fixture = new PnpmInstallerFixture
        {
            Settings =
            {
                Dev = dev,
                Prod = prod
            }
        };

        // When
        var result = () => fixture.Run();

        // Then
        Assert.That(result, Throws.Nothing);
        Assert.That(result().Args, Is.EqualTo($"install{argumentValue}"));
    }


    [Test]
    public void Should_Throw_Exception_If_Dev_Prod_Conflicting()
    {
        // Given
        var fixture = new PnpmInstallerFixture
        {
            Settings =
            {
                Dev = true,
                Prod = true
            }
        };

        // When
        var result = () => fixture.Run();

        // Then
        Assert.That(result, Throws.ArgumentException);
    }

    [TestCase(true, true, "")]
    [TestCase(true, false, "*")]
    [TestCase(false, true, "*")]
    public void Should_Throw_Exception_If_Hoist_Conflicting(bool shamefullyHoist, bool noHoist, string hoistPattern)
    {
        // Given
        var fixture = new PnpmInstallerFixture
        {
            Settings =
            {
                ShamefullyHoist = shamefullyHoist,
                NoHoist = noHoist,
                HoistPattern = hoistPattern
            }
        };

        // When
        var result = () => fixture.Run();

        // Then
        Assert.That(result, Throws.ArgumentException);
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
        var fixture = new PnpmInstallerFixture
        {
            Settings =
            {
                CakeVerbosityLevel = verbosity
            }
        };

        // When
        var result = fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo(expected));
    }
}






