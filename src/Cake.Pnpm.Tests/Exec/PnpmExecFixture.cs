using Cake.Pnpm.Exec;

namespace Cake.Pnpm.Tests.Exec;

internal sealed class PnpmExecFixture : PnpmFixture<PnpmExecSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmExec(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Exec(Settings);
    }
}
