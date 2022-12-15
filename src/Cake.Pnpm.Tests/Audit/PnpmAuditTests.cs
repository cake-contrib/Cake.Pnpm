using Cake.Pnpm.Audit;
using Cake.Testing.Fixtures;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Audit;

[TestFixture]
[TestOf(typeof(PnpmAudit))]
public class PnpmAuditTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmAuditFixture();
    }

    private PnpmAuditFixture _fixture;

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
        Assert.That(result.Args, Is.EqualTo("audit"));
    }

    [Test]
    public void Should_Throw_Exception_If_Dev_Prod_Conflicting()
    {
        // Given
        _fixture.Settings = new PnpmAuditSettings()
        {
            Dev = true,
            Prod = true
        };

        // When
        ToolFixtureResult Result() => _fixture.Run();

        // Then
        Assert.That(Result, Throws.ArgumentException);
    }

    [TestCaseSource(typeof(AuditTestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmAuditSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
