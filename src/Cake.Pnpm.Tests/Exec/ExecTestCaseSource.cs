using System.Collections;
using Cake.Pnpm.Exec;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Exec;

public class ExecTestCaseSource : IEnumerable
{
    public const string StubCommand = "jest";
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmExecSettings {Command = StubCommand, Recursive = true}).SetName("--recursive").Returns($"-r exec {StubCommand}");
        yield return new TestCaseData(new PnpmExecSettings {Command = StubCommand, ShellMode = true}).SetName("--shell-mode").Returns($"-c exec {StubCommand}");
        yield return new TestCaseData(new PnpmExecSettings {Command = StubCommand, Parallel = true}).SetName("--parallel").Returns($"--parallel exec {StubCommand}");
    }
}
