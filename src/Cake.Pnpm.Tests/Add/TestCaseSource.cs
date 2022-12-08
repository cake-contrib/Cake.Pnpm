using System.Collections;
using Cake.Pnpm.Add;
using Cake.Pnpm.Install;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Add;

public class TestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmAddSettings {Color = true}).SetName("--color").Returns("add --color");
        yield return new TestCaseData(new PnpmAddSettings {Color = false}).SetName("--no-color").Returns("add --no-color");
        yield return new TestCaseData(new PnpmAddSettings {AggregateOutput = true}).SetName("--aggregate-output").Returns("add --aggregate-output");
        yield return new TestCaseData(new PnpmAddSettings {Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("add --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmAddSettings {GlobalDir = "C:\\Program Files\\Dir"}).SetName("--global-dir").Returns("add --global-dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmAddSettings {IgnoreScripts = true}).SetName("--ignore-scripts").Returns("add --ignore-scripts");
        yield return new TestCaseData(new PnpmAddSettings {Offline = true}).SetName("--offline").Returns("add --offline");
        yield return new TestCaseData(new PnpmAddSettings {PreferOffline = true}).SetName("--prefer-offline").Returns("add --prefer-offline");
        yield return new TestCaseData(new PnpmAddSettings {Recursive = true}).SetName("--recursive").Returns("add --recursive");
        yield return new TestCaseData(new PnpmAddSettings {Stream = true}).SetName("--stream").Returns("add --stream");
        yield return new TestCaseData(new PnpmAddSettings {StoreDir = "./store"}).SetName("--store-dir").Returns("add --store-dir \"./store\"");
        yield return new TestCaseData(new PnpmAddSettings {UseStderr = true}).SetName("--use-stderr").Returns("add --use-stderr");
        yield return new TestCaseData(new PnpmAddSettings {VirtualStoreDir = "virtualDir"}).SetName("--virtual-store-dir").Returns("add --virtual-store-dir \"virtualDir\"");
        yield return new TestCaseData(new PnpmAddSettings {WorkspaceRoot = true}).SetName("--workspace-root").Returns("add --workspace-root");
        yield return new TestCaseData(new PnpmAddSettings {SaveExact = true}).SetName("--save-exact").Returns("add --save-exact");
        yield return new TestCaseData(new PnpmAddSettings {SaveExact = false}).SetName("--no-save-exact").Returns("add --no-save-exact");
        yield return new TestCaseData(new PnpmAddSettings {Global = true}).SetName("--global").Returns("add --global");
        yield return new TestCaseData(new PnpmAddSettings {SaveWorkspaceProtocol = true}).SetName("--save-workspace-protocol").Returns("add --save-workspace-protocol");
        yield return new TestCaseData(new PnpmAddSettings {SaveWorkspaceProtocol = false}).SetName("--no-save-workspace-protocol").Returns("add --no-save-workspace-protocol");
        yield return new TestCaseData(new PnpmAddSettings {SaveDev = true}).SetName("--save-dev").Returns("add --save-dev");
        yield return new TestCaseData(new PnpmAddSettings {SaveOptional = true}).SetName("--save-optional").Returns("add --save-optional");
        yield return new TestCaseData(new PnpmAddSettings {SavePeer = true}).SetName("--save-peer").Returns("add --save-peer");
        yield return new TestCaseData(new PnpmAddSettings {SaveProd = true}).SetName("--save-prod").Returns("add --save-prod");
        yield return new TestCaseData(new PnpmAddSettings {Workspace = true}).SetName("--workspace").Returns("add --workspace");


    }
}
