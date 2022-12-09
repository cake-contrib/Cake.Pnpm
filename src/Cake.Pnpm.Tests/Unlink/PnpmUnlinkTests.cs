using Cake.Pnpm.Link;
using Cake.Pnpm.Unlink;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Unlink;

[TestFixture]
[TestOf(typeof(PnpmUnlink))]
public class PnpmUnlinkTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmUnlinkFixture();
    }

    private PnpmUnlinkFixture _fixture;

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
        _fixture.Settings.Path = UnlinkTestCaseSource.StubPath;

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"unlink \"{UnlinkTestCaseSource.StubPath}\""));
    }

    [TestCaseSource(typeof(UnlinkTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmUnlinkSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
