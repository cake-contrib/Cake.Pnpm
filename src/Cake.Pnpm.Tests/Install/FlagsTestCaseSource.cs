using System.Collections;
using Cake.Pnpm.Install;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Install;

public class FlagsTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmInstallSettings {Color = true}).SetName("--color").Returns("install --color");
        yield return new TestCaseData(new PnpmInstallSettings {Color = false}).SetName("--no-color").Returns("install --no-color");
        yield return new TestCaseData(new PnpmInstallSettings {FrozenLockfile = true}).SetName("--frozen-lockfile").Returns("install --frozen-lockfile");
        yield return new TestCaseData(new PnpmInstallSettings {FrozenLockfile = false}).SetName("--no-frozen-lockfile").Returns("install --no-frozen-lockfile");
        yield return new TestCaseData(new PnpmInstallSettings {VerifyStoreIntegrity = true}).SetName("--verify-store-integrity").Returns("install --verify-store-integrity");
        yield return new TestCaseData(new PnpmInstallSettings {VerifyStoreIntegrity = false}).SetName("--no-verify-store-integrity").Returns("install --no-verify-store-integrity");
        yield return new TestCaseData(new PnpmInstallSettings {AggregateOutput = true}).SetName("--aggregate-output").Returns("install --aggregate-output");
        yield return new TestCaseData(new PnpmInstallSettings {ChildConcurrency = 1}).SetName("--child-concurrency").Returns("install --child-concurrency 1");
        yield return new TestCaseData(new PnpmInstallSettings {Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("install --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmInstallSettings {FixLockfile = true}).SetName("--fix-lockfile").Returns("install --fix-lockfile");
        yield return new TestCaseData(new PnpmInstallSettings {Force = true}).SetName("--force").Returns("install --force");
        yield return new TestCaseData(new PnpmInstallSettings {GlobalDir = "C:\\Program Files\\Dir"}).SetName("--global-dir").Returns("install --global-dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmInstallSettings {HoistPattern = "node_modules/*"}).SetName("--hoist-pattern").Returns("install --hoist-pattern \"node_modules/*\"");
        yield return new TestCaseData(new PnpmInstallSettings {IgnorePnpmfile = true}).SetName("--ignore-pnpmfile").Returns("install --ignore-pnpmfile");
        yield return new TestCaseData(new PnpmInstallSettings {IgnoreScripts = true}).SetName("--ignore-scripts").Returns("install --ignore-scripts");
        yield return new TestCaseData(new PnpmInstallSettings {LockfileDir = "/var/temp folder/"}).SetName("--lockfile-dir").Returns("install --lockfile-dir \"/var/temp folder/\"");
        yield return new TestCaseData(new PnpmInstallSettings {LockfileOnly = true}).SetName("--lockfile-only").Returns("install --lockfile-only");
        yield return new TestCaseData(new PnpmInstallSettings {ModulesDir = "z:/tmp/folder"}).SetName("--modules-dir").Returns("install --modules-dir \"z:/tmp/folder\"");
        yield return new TestCaseData(new PnpmInstallSettings {NetworkConcurrency = 5}).SetName("--network-concurrency").Returns("install --network-concurrency 5");
        yield return new TestCaseData(new PnpmInstallSettings {NoHoist = true}).SetName("--no-hoist").Returns("install --no-hoist");
        yield return new TestCaseData(new PnpmInstallSettings {NoLockfile = true}).SetName("--no-lockfile").Returns("install --no-lockfile");
        yield return new TestCaseData(new PnpmInstallSettings {NoOptional = true}).SetName("--no-optional").Returns("install --no-optional");
        yield return new TestCaseData(new PnpmInstallSettings {Offline = true}).SetName("--offline").Returns("install --offline");
        yield return new TestCaseData(new PnpmInstallSettings {PackageImportMethod = PackageImportMethodType.Auto}).SetName("--package-import-method auto").Returns("install --package-import-method auto");
        yield return new TestCaseData(new PnpmInstallSettings {PackageImportMethod = PackageImportMethodType.Copy}).SetName("--package-import-method copy").Returns("install --package-import-method copy");
        yield return new TestCaseData(new PnpmInstallSettings {PackageImportMethod = PackageImportMethodType.Hardlink}).SetName("--package-import-method hardlink").Returns("install --package-import-method hardlink");
        yield return new TestCaseData(new PnpmInstallSettings {PackageImportMethod = PackageImportMethodType.Clone}).SetName("--package-import-method clone").Returns("install --package-import-method clone");
        yield return new TestCaseData(new PnpmInstallSettings {PreferFrozenLockfile = true}).SetName("--prefer-frozen-lockfile").Returns("install --prefer-frozen-lockfile");
        yield return new TestCaseData(new PnpmInstallSettings {PreferOffline = true}).SetName("--prefer-offline").Returns("install --prefer-offline");
        yield return new TestCaseData(new PnpmInstallSettings {PublicHoistPattern = "*"}).SetName("--public-hoist-pattern").Returns("install --public-hoist-pattern \"*\"");
        yield return new TestCaseData(new PnpmInstallSettings {Recursive = true}).SetName("--recursive").Returns("install --recursive");
        yield return new TestCaseData(new PnpmInstallSettings {ShamefullyHoist = true}).SetName("--shamefully-hoist").Returns("install --shamefully-hoist");
        yield return new TestCaseData(new PnpmInstallSettings {SideEffectsCache = true}).SetName("--side-effects-cache").Returns("install --side-effects-cache");
        yield return new TestCaseData(new PnpmInstallSettings {SideEffectsCacheReadonly = true}).SetName("--side-effects-cache-readonly").Returns("install --side-effects-cache-readonly");
        yield return new TestCaseData(new PnpmInstallSettings {Stream = true}).SetName("--stream").Returns("install --stream");
        yield return new TestCaseData(new PnpmInstallSettings {StoreDir = "./store"}).SetName("--store-dir").Returns("install --store-dir \"./store\"");
        yield return new TestCaseData(new PnpmInstallSettings {StrictPeerDependencies = true}).SetName("--strict-peer-dependencies").Returns("install --strict-peer-dependencies");
        yield return new TestCaseData(new PnpmInstallSettings {UseRunningStoreServer = true}).SetName("--use-running-store-server").Returns("install --use-running-store-server");
        yield return new TestCaseData(new PnpmInstallSettings {UseStderr = true}).SetName("--use-stderr").Returns("install --use-stderr");
        yield return new TestCaseData(new PnpmInstallSettings {UseStoreServer = true}).SetName("--use-store-server").Returns("install --use-store-server");
        yield return new TestCaseData(new PnpmInstallSettings {VirtualStoreDir = "virtualDir"}).SetName("--virtual-store-dir").Returns("install --virtual-store-dir \"virtualDir\"");
        yield return new TestCaseData(new PnpmInstallSettings {WorkspaceRoot = true}).SetName("--workspace-root").Returns("install --workspace-root");
        yield return new TestCaseData(new PnpmInstallSettings {OutputReportingType = OutputReportingType.Default}).SetName("--reporter default").Returns("install --reporter default");
        yield return new TestCaseData(new PnpmInstallSettings {OutputReportingType = OutputReportingType.AppendOnly}).SetName("--reporter append-only").Returns("install --reporter append-only");
        yield return new TestCaseData(new PnpmInstallSettings {OutputReportingType = OutputReportingType.Ndjson}).SetName("--reporter ndjson").Returns("install --reporter ndjson");
        yield return new TestCaseData(new PnpmInstallSettings {OutputReportingType = OutputReportingType.Ndjson, PnpmLogLevel = PnpmLogLevel.Silent}).SetName("--silent").Returns("install --silent");
    }
}

