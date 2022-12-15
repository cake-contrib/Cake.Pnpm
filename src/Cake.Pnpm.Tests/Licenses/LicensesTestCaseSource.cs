using System.Collections;
using Cake.Pnpm.Licenses;
using NUnit.Framework;

namespace Cake.Pnpm.Tests.Licenses;

public class LicensesTestCaseSource : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return new TestCaseData(new PnpmLicensesSettings {Dev = true}).SetName("--dev").Returns("licenses list --dev");
        yield return new TestCaseData(new PnpmLicensesSettings {Long = true}).SetName("--long").Returns("licenses list --long");
        yield return new TestCaseData(new PnpmLicensesSettings {Json = true}).SetName("--json").Returns("licenses list --json");
        yield return new TestCaseData(new PnpmLicensesSettings {NoOptional = true}).SetName("--no-optional").Returns("licenses list --no-optional");
        yield return new TestCaseData(new PnpmLicensesSettings {Prod = true}).SetName("--prod").Returns("licenses list --prod");
    }
}
