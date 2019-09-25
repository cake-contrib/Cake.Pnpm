using Cake.Pnpm.Commands.Install;

namespace Cake.Pnpm.Tests.Commands.Install
{
    internal sealed class PnpmInstallFixture : PnpmFixture<PnpmInstallSettings>
    {
        public PnpmInstallFixture()
        {
        }

        protected override void RunTool()
        {
            var tool = new PnpmInstall(FileSystem, Environment, ProcessRunner, Tools);
            tool.Install(Settings);
        }
    }
}
