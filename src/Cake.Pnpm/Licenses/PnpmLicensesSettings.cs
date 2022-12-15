using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Pnpm.Audit;

namespace Cake.Pnpm.Licenses;

/// <summary>
///     Contains settings used by <see cref="PnpmLicenses" />.
/// </summary>
public class PnpmLicensesSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmLicensesSettings" /> class.
    /// </summary>
    public PnpmLicensesSettings() : base("licenses list")
    {
    }

    /// <summary>
    ///     Check only 'devDependencies'
    /// </summary>
    public bool Dev { get; set; }

    /// <summary>
    ///     Show information in JSON format
    /// </summary>
    public bool Json { get; set; }

    /// <summary>
    ///     Show more details (such as a link to the repo) are not displayed. To display the details, pass this option.
    /// </summary>
    public bool Long { get; set; }

    /// <summary>
    ///     Don't check 'optionalDependencies'
    /// </summary>
    public bool NoOptional { get; set; }

    /// <summary>
    ///     Check only "dependencies" and "optionalDependencies"
    /// </summary>
    public bool Prod { get; set; }

   /// <inheritdoc />
   protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (Dev && Prod) throw new ArgumentException("Dev conflicting with Prod setting");

        base.EvaluateCore(args);

        if (Dev) args.Append("--dev");
        if (Json) args.Append("--json");
        if (Long) args.Append("--long");
        if (NoOptional) args.Append("--no-optional");
        if (Prod) args.Append("--prod");
    }
}
