using Cake.Pnpm.Run;
using Cake.Pnpm.Store;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Store;

[TestFixture]
[TestOf(typeof(PnpmStore))]
public class PnpmStoreTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmStoreFixture();
    }

    private PnpmStoreFixture _fixture;

    [Test]
    public void Should_Throw_If_Settings_Are_Null()
    {
        // Given
        _fixture.Settings = null;

        // When
        // Then
        Assert.That( _fixture.Run, Throws.ArgumentNullException);
    }

    [TestCase(PnpmStoreSettings.PathCommand)]
    [TestCase(PnpmStoreSettings.PruneCommand)]
    [TestCase(PnpmStoreSettings.StatusCommand)]
    public void Should_Add_Mandatory_Arguments(string command)
    {
        // Given
        _fixture.Settings = new PnpmStoreSettings() {Command = command};

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo($"store {command}"));
    }

    [Test]
    public void Should_Throw_If_Add_Without_Packages()
    {
        // Given
        _fixture.Settings = new PnpmStoreSettings() {Command = PnpmStoreSettings.AddCommand};

        // When
        var result = () => _fixture.Run();

        // Then
        Assert.That(result, Throws.InvalidOperationException);
    }

    [Test]
    public void Should_Add_Packages_If_Presented()
    {
        // Given
        _fixture.Settings = new PnpmStoreSettings {Command = PnpmStoreSettings.AddCommand};
        _fixture.Settings.Packages.Add("foo@bar");

        // When
        var result = _fixture.Run();

        // Then
        Assert.That(result.Args, Is.EqualTo("store add \"foo@bar\""));
    }
}

