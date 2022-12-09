using System.Collections;
using Cake.Pnpm.Remove;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Remove;

public class RemoveTestCaseSource : IEnumerable
{
    public const string StubPackageName = "foo@bar";

    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, Color = true}).SetName("--color").Returns($"remove \"{StubPackageName}\" --color");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, Color = false}).SetName("--no-color").Returns($"remove \"{StubPackageName}\" --no-color");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, AggregateOutput = true}).SetName("--aggregate-output").Returns($"remove \"{StubPackageName}\" --aggregate-output");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns($"remove \"{StubPackageName}\" --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, Recursive = true}).SetName("--recursive").Returns($"remove \"{StubPackageName}\" --recursive");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, Stream = true}).SetName("--stream").Returns($"remove \"{StubPackageName}\" --stream");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, UseStderr = true}).SetName("--use-stderr").Returns($"remove \"{StubPackageName}\" --use-stderr");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, WorkspaceRoot = true}).SetName("--workspace-root").Returns($"remove \"{StubPackageName}\" --workspace-root");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, SaveDev = true}).SetName("--save-dev").Returns($"remove \"{StubPackageName}\" --save-dev");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, SaveOptional = true}).SetName("--save-optional").Returns($"remove \"{StubPackageName}\" --save-optional");
        yield return new TestCaseData(new PnpmRemoveSettings {PackageName = StubPackageName, SaveProd = true}).SetName("--save-prod").Returns($"remove \"{StubPackageName}\" --save-prod");
    }
}

