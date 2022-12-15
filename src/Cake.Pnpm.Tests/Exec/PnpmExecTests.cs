using Cake.Pnpm.Exec;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Exec;

[TestFixture]
[TestOf(typeof(PnpmExec))]
public class PnpmExecTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmExecFixture();
    }

    private PnpmExecFixture _fixture;

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
        _fixture.Settings = new PnpmExecSettings {Command = ExecTestCaseSource.StubCommand};

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"exec {ExecTestCaseSource.StubCommand}"));
    }

    [TestCaseSource(typeof(ExecTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmExecSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
