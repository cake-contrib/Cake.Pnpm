using Cake.Pnpm.Commands.Link;

namespace Cake.Pnpm.Tests.Commands.Link
{
    internal sealed class PnpmLinkFixture : PnpmFixture<PnpmLinkSettings>
    {
        public PnpmLinkFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new PnpmLink(FileSystem, Environment, ProcessRunner, Tools);
            tool.Install(Settings);
        }
    }
}
