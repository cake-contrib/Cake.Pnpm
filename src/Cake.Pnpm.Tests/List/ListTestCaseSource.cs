using System.Collections;
using System.Collections.Generic;
using Cake.Pnpm.List;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.List;

public class ListTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmListSettings {AggregateOutput = true}).SetName("--aggregate-output").Returns("list --aggregate-output");
        yield return new TestCaseData(new PnpmListSettings {Color = false}).SetName("--no-color").Returns("list --no-color");
        yield return new TestCaseData(new PnpmListSettings {Color = true}).SetName("--color").Returns("list --color");
        yield return new TestCaseData(new PnpmListSettings {Dev = true}).SetName("--dev").Returns("list --dev");
        yield return new TestCaseData(new PnpmListSettings {Json = true}).SetName("--json").Returns("list --json");
        yield return new TestCaseData(new PnpmListSettings {Long = true}).SetName("--long").Returns("list --long");
        yield return new TestCaseData(new PnpmListSettings {Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("list --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmListSettings {Global = true}).SetName("--global").Returns("list --global");
        yield return new TestCaseData(new PnpmListSettings {GlobalDir = "C:\\Program Files\\Dir"}).SetName("--global-dir").Returns("list --global-dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmListSettings {NoOptional = true}).SetName("--no-optional").Returns("list --no-optional");
        yield return new TestCaseData(new PnpmListSettings {Parseable = true}).SetName("--parseable").Returns("list --parseable");
        yield return new TestCaseData(new PnpmListSettings {Prod = true}).SetName("--prod").Returns("list --prod");
        yield return new TestCaseData(new PnpmListSettings {Recursive = true}).SetName("--recursive").Returns("list --recursive");
        yield return new TestCaseData(new PnpmListSettings {Stream = true}).SetName("--stream").Returns("list --stream");
        yield return new TestCaseData(new PnpmListSettings {UseStderr = true}).SetName("--use-stderr").Returns("list --use-stderr");
        yield return new TestCaseData(new PnpmListSettings {WorkspaceRoot = true}).SetName("--workspace-root").Returns("list --workspace-root");
    }
}
