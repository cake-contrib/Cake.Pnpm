using Cake.Pnpm.Run;

namespace Cake.Pnpm.Tests.Run;

internal sealed class PnpmRunFixture : PnpmFixture<PnpmRunSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmRun(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Run(Settings);
    }
}
