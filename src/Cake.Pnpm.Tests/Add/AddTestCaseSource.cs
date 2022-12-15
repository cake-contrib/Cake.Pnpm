using System.Collections;
using Cake.Pnpm.Add;
using Cake.Pnpm.Install;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Add;

public class AddTestCaseSource : IEnumerable
{
    public const string StubPackageName = "foo@bar";

    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Color = true}).SetName("--color").Returns($"add \"{StubPackageName}\" --color");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Color = false}).SetName("--no-color").Returns($"add \"{StubPackageName}\" --no-color");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, AggregateOutput = true}).SetName("--aggregate-output").Returns($"add \"{StubPackageName}\" --aggregate-output");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns($"add \"{StubPackageName}\" --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, GlobalDir = "C:\\Program Files\\Dir"}).SetName("--global-dir").Returns($"add \"{StubPackageName}\" --global-dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, IgnoreScripts = true}).SetName("--ignore-scripts").Returns($"add \"{StubPackageName}\" --ignore-scripts");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Offline = true}).SetName("--offline").Returns($"add \"{StubPackageName}\" --offline");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, PreferOffline = true}).SetName("--prefer-offline").Returns($"add \"{StubPackageName}\" --prefer-offline");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Recursive = true}).SetName("--recursive").Returns($"add \"{StubPackageName}\" --recursive");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Stream = true}).SetName("--stream").Returns($"add \"{StubPackageName}\" --stream");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, StoreDir = "./store"}).SetName("--store-dir").Returns($"add \"{StubPackageName}\" --store-dir \"./store\"");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, UseStderr = true}).SetName("--use-stderr").Returns($"add \"{StubPackageName}\" --use-stderr");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, VirtualStoreDir = "virtualDir"}).SetName("--virtual-store-dir").Returns($"add \"{StubPackageName}\" --virtual-store-dir \"virtualDir\"");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, WorkspaceRoot = true}).SetName("--workspace-root").Returns($"add \"{StubPackageName}\" --workspace-root");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SaveExact = true}).SetName("--save-exact").Returns($"add \"{StubPackageName}\" --save-exact");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SaveExact = false}).SetName("--no-save-exact").Returns($"add \"{StubPackageName}\" --no-save-exact");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Global = true}).SetName("--global").Returns($"add \"{StubPackageName}\" --global");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SaveWorkspaceProtocol = true}).SetName("--save-workspace-protocol").Returns($"add \"{StubPackageName}\" --save-workspace-protocol");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SaveWorkspaceProtocol = false}).SetName("--no-save-workspace-protocol").Returns($"add \"{StubPackageName}\" --no-save-workspace-protocol");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SaveDev = true}).SetName("--save-dev").Returns($"add \"{StubPackageName}\" --save-dev");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SaveOptional = true}).SetName("--save-optional").Returns($"add \"{StubPackageName}\" --save-optional");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SavePeer = true}).SetName("--save-peer").Returns($"add \"{StubPackageName}\" --save-peer");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, SaveProd = true}).SetName("--save-prod").Returns($"add \"{StubPackageName}\" --save-prod");
        yield return new TestCaseData(new PnpmAddSettings {PackageName = StubPackageName, Workspace = true}).SetName("--workspace").Returns($"add \"{StubPackageName}\" --workspace");


    }
}
