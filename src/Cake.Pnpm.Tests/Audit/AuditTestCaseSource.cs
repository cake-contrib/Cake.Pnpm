using System.Collections;
using Cake.Pnpm.Audit;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Audit;

public class AuditTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmAuditSettings {AuditLevel = AuditLevelSeverity.Low}).SetName("--audit-level low").Returns("audit --audit-level low");
        yield return new TestCaseData(new PnpmAuditSettings {AuditLevel = AuditLevelSeverity.Moderate}).SetName("--audit-level moderate").Returns("audit --audit-level moderate");
        yield return new TestCaseData(new PnpmAuditSettings {AuditLevel = AuditLevelSeverity.High}).SetName("--audit-level high").Returns("audit --audit-level high");
        yield return new TestCaseData(new PnpmAuditSettings {AuditLevel = AuditLevelSeverity.Critical}).SetName("--audit-level critical").Returns("audit --audit-level critical");
        yield return new TestCaseData(new PnpmAuditSettings {Dev = true}).SetName("--dev").Returns("audit --dev");
        yield return new TestCaseData(new PnpmAuditSettings {Fix = true}).SetName("--fix").Returns("audit --fix");
        yield return new TestCaseData(new PnpmAuditSettings {IgnoreRegistryErrors = true}).SetName("--ignore-registry-errors").Returns("audit --ignore-registry-errors");
        yield return new TestCaseData(new PnpmAuditSettings {Json = true}).SetName("--json").Returns("audit --json");
        yield return new TestCaseData(new PnpmAuditSettings {NoOptional = true}).SetName("--no-optional").Returns("audit --no-optional");
        yield return new TestCaseData(new PnpmAuditSettings {Prod = true}).SetName("--prod").Returns("audit --prod");
    }
}
