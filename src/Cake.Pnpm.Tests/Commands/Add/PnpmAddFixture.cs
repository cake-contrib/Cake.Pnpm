using Cake.Pnpm.Commands.Add;

namespace Cake.Pnpm.Tests.Commands.Add
{
    internal sealed class PnpmAddFixture : PnpmFixture<PnpmAddSettings>
    {
        public PnpmAddFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new PnpmAdd(FileSystem, Environment, ProcessRunner, Tools);
            tool.Install(Settings);
        }
    }
}
