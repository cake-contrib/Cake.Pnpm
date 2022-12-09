using Cake.Pnpm.Add;
using Cake.Pnpm.Import;

namespace Cake.Pnpm.Tests.Import;

internal sealed class PnpmImportFixture : PnpmFixture<PnpmImportSettings>
{
    protected override void RunTool()
    {
        var tool = new PnpmImport(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Import(Settings);
    }
}
