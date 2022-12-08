using Cake.Pnpm.Add;

namespace Cake.Pnpm.Tests.Add;

internal sealed class PnpmAddFixture : PnpmFixture<PnpmAddSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmAdd(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Add(Settings);
    }
}
