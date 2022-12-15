using System.Collections;
using Cake.Pnpm.Add;
using Cake.Pnpm.Update;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Update;

public class UpdateTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmUpdateSettings { AggregateOutput = true}).SetName("--aggregate-output").Returns("update --aggregate-output");
        yield return new TestCaseData(new PnpmUpdateSettings { Color = true}).SetName("--color").Returns("update --color");
        yield return new TestCaseData(new PnpmUpdateSettings { Color = false}).SetName("--no-color").Returns("update --no-color");
        yield return new TestCaseData(new PnpmUpdateSettings { Depth = 3}).SetName("--depth").Returns("update --depth 3");
        yield return new TestCaseData(new PnpmUpdateSettings { Dev = true}).SetName("--dev").Returns("update --dev");
        yield return new TestCaseData(new PnpmUpdateSettings { Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("update --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmUpdateSettings { Global = true}).SetName("--global").Returns("update --global");
        yield return new TestCaseData(new PnpmUpdateSettings { GlobalDir = "C:\\Program Files\\Dir"}).SetName("--global-dir").Returns("update --global-dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmUpdateSettings { Interactive = true}).SetName("--interactive").Returns("update --interactive");
        yield return new TestCaseData(new PnpmUpdateSettings { Latest = true}).SetName("--latest").Returns("update --latest");
        yield return new TestCaseData(new PnpmUpdateSettings { NoOptional = true}).SetName("--no-optional").Returns("update --no-optional");
        yield return new TestCaseData(new PnpmUpdateSettings { Prod = true}).SetName("--prod").Returns("update --prod");
        yield return new TestCaseData(new PnpmUpdateSettings { Recursive = true}).SetName("--recursive").Returns("update --recursive");
        yield return new TestCaseData(new PnpmUpdateSettings { Stream = true}).SetName("--stream").Returns("update --stream");
        yield return new TestCaseData(new PnpmUpdateSettings { UseStderr = true}).SetName("--use-stderr").Returns("update --use-stderr");
        yield return new TestCaseData(new PnpmUpdateSettings { Workspace = true}).SetName("--workspace").Returns("update --workspace");
        yield return new TestCaseData(new PnpmUpdateSettings { WorkspaceRoot = true}).SetName("--workspace-root").Returns("update --workspace-root");
    }
}
