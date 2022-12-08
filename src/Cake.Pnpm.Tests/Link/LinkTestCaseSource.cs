using System.Collections;
using Cake.Pnpm.Link;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Link;

public class LinkTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmLinkSettings {AggregateOutput = true}).SetName("--aggregate-output").Returns($"link --aggregate-output");
        yield return new TestCaseData(new PnpmLinkSettings {Color = false}).SetName("--no-color").Returns($"link --no-color");
        yield return new TestCaseData(new PnpmLinkSettings {Color = true}).SetName("--color").Returns($"link --color");
        yield return new TestCaseData(new PnpmLinkSettings {Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns($"link --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmLinkSettings {Color = false}).SetName("--no-color").Returns($"link --no-color");
        yield return new TestCaseData(new PnpmLinkSettings {Stream = true}).SetName("--stream").Returns($"link --stream");
        yield return new TestCaseData(new PnpmLinkSettings {UseStderr = true}).SetName("--use-stderr").Returns($"link --use-stderr");
        yield return new TestCaseData(new PnpmLinkSettings {WorkspaceRoot = true}).SetName("--workspace-root").Returns($"link --workspace-root");
        yield return new TestCaseData(new PnpmLinkSettings {Global = true}).SetName("--global").Returns($"link --global");
    }
}
