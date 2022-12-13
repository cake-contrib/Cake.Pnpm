using Cake.Pnpm.Outdated;
using Cake.Testing.Fixtures;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Outdated;

[TestFixture]
[TestOf(typeof(PnpmOutdated))]
public class PnpmOutdatedTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmOutdatedFixture();
    }

    private PnpmOutdatedFixture _fixture;

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
        Assert.That(result.Args, Is.EqualTo("outdated"));
    }

    [Test]
    public void Should_Throw_Exception_If_Dev_Prod_Conflicting()
    {
        // Given
        _fixture.Settings = new PnpmOutdatedSettings
        {
            Dev = true,
            Prod = true
        };

        // When
        ToolFixtureResult Result() => _fixture.Run();

        // Then
        Assert.That(Result, Throws.ArgumentException);
    }

    [Test]
    public void Should_Add_Single_Package_If_Presented()
    {
        // Given
        _fixture.Settings.Packages.Add("foo@bar");

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("outdated \"foo@bar\""));
    }

    [Test]
    public void Should_Add_Multiple_Package_If_Presented()
    {
        // Given
        _fixture.Settings.Packages.Add("foo@bar");
        _fixture.Settings.Packages.Add("baz@v1.2.3");

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("outdated \"foo@bar\" \"baz@v1.2.3\""));
    }

    [TestCaseSource(typeof(OutdatedTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmOutdatedSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
