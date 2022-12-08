﻿using Cake.Pnpm.Link;
using Cake.Pnpm.Tests.Import;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Link;

[TestFixture]
[TestOf(typeof(PnpmLink))]
public class PnpmLinkTests
{
    [SetUp]
    public void Init()
    {
        _fixture = new PnpmLinkFixture();
    }

    private PnpmLinkFixture _fixture;

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
        Assert.That(result.Args, Is.EqualTo("link"));
    }

    [TestCaseSource(typeof(TestCaseSource))]
    public string Should_Add_Parameter_If_Set(PnpmLinkSettings settings)
    {
        // Given
        _fixture.Settings = settings;

        // When
        var result = _fixture.Run();

        // Then
        return result.Args;
    }
}
