using System.Collections;
using Cake.Pnpm.Rebuild;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Rebuild;

public class RebuildTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmRebuildSettings {AggregateOutput = true}).SetName("--aggregate-output").Returns("rebuild --aggregate-output");
        yield return new TestCaseData(new PnpmRebuildSettings {Color = false}).SetName("--no-color").Returns("rebuild --no-color");
        yield return new TestCaseData(new PnpmRebuildSettings {Color = true}).SetName("--color").Returns("rebuild --color");
        yield return new TestCaseData(new PnpmRebuildSettings {Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("rebuild --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmRebuildSettings {Pending = true}).SetName("--pending").Returns("rebuild --pending");
        yield return new TestCaseData(new PnpmRebuildSettings {Recursive = true}).SetName("--recursive").Returns("rebuild --recursive");
        yield return new TestCaseData(new PnpmRebuildSettings {StoreDir = "/etc/bin"}).SetName("--store-dir").Returns("rebuild --store-dir \"/etc/bin\"");
        yield return new TestCaseData(new PnpmRebuildSettings {Stream = true}).SetName("--stream").Returns("rebuild --stream");
        yield return new TestCaseData(new PnpmRebuildSettings {UseStderr = true}).SetName("--use-stderr").Returns("rebuild --use-stderr");
        yield return new TestCaseData(new PnpmRebuildSettings {WorkspaceRoot = true}).SetName("--workspace-root").Returns("rebuild --workspace-root");
    }
}
