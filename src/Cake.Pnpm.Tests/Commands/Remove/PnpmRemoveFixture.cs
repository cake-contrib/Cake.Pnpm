using Cake.Pnpm.Commands.Remove;

namespace Cake.Pnpm.Tests.Commands.Remove
{
    internal sealed class PnpmRemoveFixture : PnpmFixture<PnpmRemoveSettings>
    {
        public PnpmRemoveFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new PnpmRemove(FileSystem, Environment, ProcessRunner, Tools);
            tool.Install(Settings);
        }
    }
}
