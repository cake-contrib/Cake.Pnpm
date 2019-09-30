using Cake.Pnpm.Commands.Update;

namespace Cake.Pnpm.Tests.Commands.Install
{
    internal sealed class PnpmUpdateFixture : PnpmFixture<PnpmUpdateSettings>
    {
        public PnpmUpdateFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new PnpmUpdate(FileSystem, Environment, ProcessRunner, Tools);
            tool.Update(Settings);
        }
    }
}
