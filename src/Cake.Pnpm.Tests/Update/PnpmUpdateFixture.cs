using Cake.Pnpm.Update;

namespace Cake.Pnpm.Tests.Update;

internal sealed class PnpmUpdateFixture : PnpmFixture<PnpmUpdateSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmUpdate(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Update(Settings);
    }
}
