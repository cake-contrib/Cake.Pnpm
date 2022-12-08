using Cake.Pnpm.Import;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Import;

[TestFixture]
[TestOf(typeof(PnpmImport))]
public class PnpmImportTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmImportFixture();
    }

    private PnpmImportFixture _fixture;

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
        Assert.That(result.Args, Is.EqualTo("import"));
    }
}
