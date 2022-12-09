using System.Collections;
using Cake.Pnpm.Link;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Link;

public class LinkTestCaseSource : IEnumerable
{
    public const string StubPath = "foo@bar";
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, AggregateOutput = true}).SetName("--aggregate-output").Returns($"link \"{StubPath}\" --aggregate-output");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, Color = false}).SetName("--no-color").Returns($"link \"{StubPath}\" --no-color");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, Color = true}).SetName("--color").Returns($"link \"{StubPath}\" --color");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns($"link \"{StubPath}\" --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, Color = false}).SetName("--no-color").Returns($"link \"{StubPath}\" --no-color");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, Stream = true}).SetName("--stream").Returns($"link \"{StubPath}\" --stream");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, UseStderr = true}).SetName("--use-stderr").Returns($"link \"{StubPath}\" --use-stderr");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, WorkspaceRoot = true}).SetName("--workspace-root").Returns($"link \"{StubPath}\" --workspace-root");
        yield return new TestCaseData(new PnpmLinkSettings {Path = StubPath, Global = true}).SetName("--global").Returns($"link \"{StubPath}\" --global");
    }
}
