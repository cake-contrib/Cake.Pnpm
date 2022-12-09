using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Audit;

/// <summary>
///     Contains settings used by <see cref="PnpmAudit" />.
/// </summary>
public class PnpmAuditSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmAuditSettings" /> class.
    /// </summary>
    public PnpmAuditSettings() : base("audit")
    {
    }

    /// <summary>
    ///     Only print advisories with severity greater than or
    ///     equal to one of the following: low|moderate|high|critical. Default: low
    /// </summary>
    public AuditLevelSeverity? AuditLevel { get; set; }

    /// <summary>
    ///     Only audit 'devDependencies'
    /// </summary>
    public bool Dev { get; set; }

    /// <summary>
    ///     Add overrides to the package.json file in order to force non-vulnerable versions of the dependencies
    /// </summary>
    public bool Fix { get; set; }

    /// <summary>
    ///     Use exit code 0 if the registry responds with an error. Useful when audit checks are used in CI.
    ///     A build should fail because the registry has issues.
    /// </summary>
    public bool IgnoreRegistryErrors { get; set; }

    /// <summary>
    ///     Output audit report in JSON format
    /// </summary>
    public bool Json { get; set; }

    /// <summary>
    ///     Don't audit 'optionalDependencies'
    /// </summary>
    public bool NoOptional { get; set; }

    /// <summary>
    ///     Only audit "dependencies" and "optionalDependencies"
    /// </summary>
    public bool Prod { get; set; }

   /// <inheritdoc />
   protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (Dev && Prod) throw new ArgumentException("Dev conflicting with Prod setting");

        base.EvaluateCore(args);

        if (AuditLevel.HasValue)
        {
            switch (AuditLevel.Value)
            {
                case AuditLevelSeverity.Low:
                    args.AppendSwitch("--audit-level", "low");
                    break;
                case AuditLevelSeverity.Moderate:
                    args.AppendSwitch("--audit-level", "moderate");
                    break;
                case AuditLevelSeverity.High:
                    args.AppendSwitch("--audit-level", "high");
                    break;
                case AuditLevelSeverity.Critical:
                    args.AppendSwitch("--audit-level", "critical");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        if (Dev) args.Append("--dev");
        if (Fix) args.Append("--fix");
        if (IgnoreRegistryErrors) args.Append("--ignore-registry-errors");
        if (Json) args.Append("--json");
        if (NoOptional) args.Append("--no-optional");
        if (Prod) args.Append("--prod");
    }
}
