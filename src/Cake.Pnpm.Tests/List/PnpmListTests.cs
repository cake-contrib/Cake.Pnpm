using Cake.Pnpm.List;
using Cake.Testing.Fixtures;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.List;

[TestFixture]
[TestOf(typeof(PnpmList))]
public class PnpmListTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmListFixture();
    }

    private PnpmListFixture _fixture;

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
        Assert.That(result.Args, Is.EqualTo("list"));
    }

    [Test]
    public void Should_Throw_Exception_If_Dev_Prod_Conflicting()
    {
        // Given
        _fixture.Settings = new PnpmListSettings
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
        Assert.That(result.Args, Is.EqualTo("list \"foo@bar\""));
    }

    [TestCaseSource(typeof(ListTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmListSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
