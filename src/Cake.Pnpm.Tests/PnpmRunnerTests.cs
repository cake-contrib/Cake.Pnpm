namespace Cake.Pnpm.Tests
{
    using System;
    using Cake.Core;
    using Cake.Testing;
    using NUnit.Framework;

    [TestFixture]
    [TestOf(typeof(PnpmRunner))]
    public class PnpmRunnerTests
    {
        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            var fixture = new PnpmRunnerFixture { Settings = null };

            Action result = () => fixture.Run();

            Assert.That(result, Throws.ArgumentNullException.With.Message.Contains("message"));
        }

        [Test]
        public void Should_Throw_If_Pnpm_Executable_Was_Not_Found()
        {
            var fixture = new PnpmRunnerFixture();
            fixture.GivenDefaultToolDoNotExist();
            const string expectedMessage = "Pnpm: Could not locate executable";

            Action result = () => fixture.Run();

            Assert.That(result, Throws.TypeOf<CakeException>().With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void Need_More_Unit_Test_Implementations()
        {
            Assert.That(false, Is.True, "More unit tests need to be implemented for the runner class");
        }
    }
}
