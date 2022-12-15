using Cake.Pnpm.Outdated;

namespace Cake.Pnpm.Tests.Outdated;

internal sealed class PnpmOutdatedFixture : PnpmFixture<PnpmOutdatedSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmOutdated(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Outdated(Settings);
    }
}
