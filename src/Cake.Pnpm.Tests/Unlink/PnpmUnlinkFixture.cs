using Cake.Pnpm.Unlink;

namespace Cake.Pnpm.Tests.Unlink;

internal sealed class PnpmUnlinkFixture : PnpmFixture<PnpmUnlinkSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmUnlink(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Unlink(Settings);
    }
}
