using System.Collections;
using Cake.Pnpm.Outdated;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Outdated;

public class OutdatedTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmOutdatedSettings {AggregateOutput = true}).SetName("--aggregate-output").Returns("outdated --aggregate-output");
        yield return new TestCaseData(new PnpmOutdatedSettings {Color = false}).SetName("--no-color").Returns("outdated --no-color");
        yield return new TestCaseData(new PnpmOutdatedSettings {Color = true}).SetName("--color").Returns("outdated --color");
        yield return new TestCaseData(new PnpmOutdatedSettings {Compatible = true}).SetName("--compatible").Returns("outdated --compatible");
        yield return new TestCaseData(new PnpmOutdatedSettings {Dev = true}).SetName("--dev").Returns("outdated --dev");
        yield return new TestCaseData(new PnpmOutdatedSettings {Long = true}).SetName("--long").Returns("outdated --long");
        yield return new TestCaseData(new PnpmOutdatedSettings {Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("outdated --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmOutdatedSettings {GlobalDir = "C:\\Program Files\\Dir"}).SetName("--global-dir").Returns("outdated --global-dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmOutdatedSettings {NoOptional = true}).SetName("--no-optional").Returns("outdated --no-optional");
        yield return new TestCaseData(new PnpmOutdatedSettings {NoTable = true}).SetName("--no-table").Returns("outdated --no-table");
        yield return new TestCaseData(new PnpmOutdatedSettings {Prod = true}).SetName("--prod").Returns("outdated --prod");
        yield return new TestCaseData(new PnpmOutdatedSettings {Recursive = true}).SetName("--recursive").Returns("outdated --recursive");
        yield return new TestCaseData(new PnpmOutdatedSettings {Stream = true}).SetName("--stream").Returns("outdated --stream");
        yield return new TestCaseData(new PnpmOutdatedSettings {UseStderr = true}).SetName("--use-stderr").Returns("outdated --use-stderr");
        yield return new TestCaseData(new PnpmOutdatedSettings {WorkspaceRoot = true}).SetName("--workspace-root").Returns("outdated --workspace-root");
    }
}
