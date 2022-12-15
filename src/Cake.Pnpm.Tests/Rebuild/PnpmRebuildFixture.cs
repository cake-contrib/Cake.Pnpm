using Cake.Pnpm.Rebuild;

namespace Cake.Pnpm.Tests.Rebuild;

internal sealed class PnpmRebuildFixture : PnpmFixture<PnpmRebuildSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmRebuild(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Rebuild(Settings);
    }
}
