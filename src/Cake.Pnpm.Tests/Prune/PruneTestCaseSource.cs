using System.Collections;
using Cake.Pnpm.Prune;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Prune;

public class PruneTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmPruneSettings {AggregateOutput = true}).SetName("--aggregate-output").Returns("prune --aggregate-output");
        yield return new TestCaseData(new PnpmPruneSettings {Color = false}).SetName("--no-color").Returns("prune --no-color");
        yield return new TestCaseData(new PnpmPruneSettings {Color = true}).SetName("--color").Returns("prune --color");
        yield return new TestCaseData(new PnpmPruneSettings {Dir = "C:\\Program Files\\Dir"}).SetName("--dir").Returns("prune --dir \"C:\\Program Files\\Dir\"");
        yield return new TestCaseData(new PnpmPruneSettings {Color = false}).SetName("--no-color").Returns("prune --no-color");
        yield return new TestCaseData(new PnpmPruneSettings {Stream = true}).SetName("--stream").Returns("prune --stream");
        yield return new TestCaseData(new PnpmPruneSettings {UseStderr = true}).SetName("--use-stderr").Returns("prune --use-stderr");
        yield return new TestCaseData(new PnpmPruneSettings {WorkspaceRoot = true}).SetName("--workspace-root").Returns("prune --workspace-root");
        yield return new TestCaseData(new PnpmPruneSettings {NoOptional = true}).SetName("--no-optional").Returns("prune --no-optional");
        yield return new TestCaseData(new PnpmPruneSettings {Prod = true}).SetName("--prod").Returns("prune --prod");
    }
}
