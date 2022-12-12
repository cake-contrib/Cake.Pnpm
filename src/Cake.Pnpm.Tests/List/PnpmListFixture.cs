using Cake.Pnpm.List;

namespace Cake.Pnpm.Tests.List;

internal sealed class PnpmListFixture : PnpmFixture<PnpmListSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmList(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.List(Settings);
    }
}
