using Cake.Pnpm.Audit;

namespace Cake.Pnpm.Tests.Audit;

internal sealed class PnpmAuditFixture : PnpmFixture<PnpmAuditSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmAudit(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Audit(Settings);
    }
}
