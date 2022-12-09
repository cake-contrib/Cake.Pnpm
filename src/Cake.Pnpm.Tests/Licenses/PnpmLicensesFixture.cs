using Cake.Pnpm.Audit;
using Cake.Pnpm.Licenses;

namespace Cake.Pnpm.Tests.Licenses;

internal sealed class PnpmLicensesFixture : PnpmFixture<PnpmLicensesSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmLicenses(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.List(Settings);
    }
}
