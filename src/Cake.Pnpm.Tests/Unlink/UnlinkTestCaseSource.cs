using System.Collections;
using Cake.Pnpm.Unlink;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Unlink;

public class UnlinkTestCaseSource : IEnumerable
{
    public const string StubPath = "foo@bar";
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, AggregateOutput = true}).SetName("--aggregate-output").Returns($"unlink \"{StubPath}\" --aggregate-output");
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, Color = false}).SetName("--no-color").Returns($"unlink \"{StubPath}\" --no-color");
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, Color = true}).SetName("--color").Returns($"unlink \"{StubPath}\" --color");
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns($"unlink \"{StubPath}\" --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, Stream = true}).SetName("--stream").Returns($"unlink \"{StubPath}\" --stream");
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, UseStderr = true}).SetName("--use-stderr").Returns($"unlink \"{StubPath}\" --use-stderr");
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, WorkspaceRoot = true}).SetName("--workspace-root").Returns($"unlink \"{StubPath}\" --workspace-root");
        yield return new TestCaseData(new PnpmUnlinkSettings {Path = StubPath, Recursive = true}).SetName("--recursive").Returns($"unlink \"{StubPath}\" --recursive");
    }
}
