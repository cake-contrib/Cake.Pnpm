using Cake.Pnpm.Link;
using Cake.Pnpm.Prune;
using Cake.Pnpm.Tests.Link;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Prune;

[TestFixture]
[TestOf(typeof(PnpmPrune))]
public class PnpmPruneTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmPruneFixture();
    }

    private PnpmPruneFixture _fixture;

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
        Assert.That(result.Args, Is.EqualTo("prune"));
    }

    [TestCaseSource(typeof(PruneTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmPruneSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
