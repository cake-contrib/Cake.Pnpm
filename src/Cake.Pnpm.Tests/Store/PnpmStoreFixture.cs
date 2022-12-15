using Cake.Pnpm.Store;

namespace Cake.Pnpm.Tests.Store;

internal sealed class PnpmStoreFixture : PnpmFixture<PnpmStoreSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmStore(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.RunCommand(Settings);
    }
}

