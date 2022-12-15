using Cake.Pnpm.Install;

namespace Cake.Pnpm.Tests.Install;

internal sealed class PnpmInstallerFixture : PnpmFixture<PnpmInstallSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmInstaller(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Install(Settings);
    }
}
