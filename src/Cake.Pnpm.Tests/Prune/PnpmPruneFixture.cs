using Cake.Pnpm.Prune;

namespace Cake.Pnpm.Tests.Prune;

internal sealed class PnpmPruneFixture : PnpmFixture<PnpmPruneSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmPrune(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Prune(Settings);
    }
}
