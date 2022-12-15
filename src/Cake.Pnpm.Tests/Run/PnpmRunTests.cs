using Cake.Pnpm.Run;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Run;

[TestFixture]
[TestOf(typeof(PnpmRun))]
public class PnpmRunTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmRunFixture();
    }

    private PnpmRunFixture _fixture;

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
        _fixture.Settings = new PnpmRunSettings {Command = "test"};

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("run test"));
    }

    [TestCaseSource(typeof(RunTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmRunSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}

