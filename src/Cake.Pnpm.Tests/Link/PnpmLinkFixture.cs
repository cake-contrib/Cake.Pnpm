using Cake.Pnpm.Import;
using Cake.Pnpm.Link;

namespace Cake.Pnpm.Tests.Link;

internal sealed class PnpmLinkFixture : PnpmFixture<PnpmLinkSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmLink(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Link(Settings);
    }
}
