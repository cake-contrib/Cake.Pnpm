using System.Collections;
using Cake.Pnpm.Run;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Run;

public class RunTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", AggregateOutput = true}).SetName("--aggregate-output").Returns("run test --aggregate-output");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", Color = false}).SetName("--no-color").Returns("run test --no-color");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", Color = true}).SetName("--color").Returns("run test --color");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("run test --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", IfPresent = true}).SetName("--if-present").Returns("run test --if-present");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", NoBail = true}).SetName("--no-bail").Returns("run test --no-bail");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", Parallel = true}).SetName("--parallel").Returns("run test --parallel");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", Recursive = true}).SetName("--recursive").Returns("run test --recursive");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", Stream = true}).SetName("--stream").Returns("run test --stream");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", UseStderr = true}).SetName("--use-stderr").Returns("run test --use-stderr");
        yield return new TestCaseData(new PnpmRunSettings {Command = "test", WorkspaceRoot = true}).SetName("--workspace-root").Returns("run test --workspace-root");
    }
}
