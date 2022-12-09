using Cake.Pnpm.Install;
using Cake.Pnpm.Remove;

namespace Cake.Pnpm.Tests.Remove;

internal sealed class PnpmRemoveFixture : PnpmFixture<PnpmRemoveSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmRemove(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Remove(Settings);
    }
}
