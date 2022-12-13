using Cake.Pnpm.Prune;
using Cake.Pnpm.Rebuild;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Rebuild;

[TestFixture]
[TestOf(typeof(PnpmRebuild))]
public class PnpmRebuildTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmRebuildFixture();
    }

    private PnpmRebuildFixture _fixture;

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
        Assert.That(result.Args, Is.EqualTo("rebuild"));
    }

    [Test]
    public void Should_Add_Single_Package_If_Presented()
    {
        // Given
        _fixture.Settings.Packages.Add("foo@bar");

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("rebuild \"foo@bar\""));
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
        Assert.That(result.Args, Is.EqualTo("rebuild \"foo@bar\" \"baz@v1.2.3\""));
    }

    [TestCaseSource(typeof(RebuildTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmRebuildSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
