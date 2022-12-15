using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Outdated;

/// <summary>
///     Contains settings used by <see cref="PnpmOutdated" />.
/// </summary>
public class PnpmOutdatedSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmOutdatedSettings" /> class.
    /// </summary>
    public PnpmOutdatedSettings() : base("outdated")
    {
        Packages = new HashSet<string>();
    }

    /// <summary>
    ///     Controls colors in the output. By default, output is always colored when it goes directly to a terminal
    /// </summary>
    public bool? Color { get; set; }

    /// <summary>
    ///     Aggregate output from child processes that are run in parallel, and only print output when child process is
    ///     finished. It makes reading large logs after running `pnpm recursive` with `--parallel` or with
    ///     `--workspace-concurrency` much easier (especially on CI). Only `--reporter=append-only` is supported.
    /// </summary>
    public bool AggregateOutput { get; set; }

    /// <summary>
    ///     Change to directory (default: the running dir)
    /// </summary>
    public string Dir { get; set; }

    /// <summary>
    ///     Package names to check outdated only from this list
    /// </summary>
    public HashSet<string> Packages { get; }

    /// <summary>
    ///     Print only versions that satisfy specs in package.json
    /// </summary>
    public bool Compatible { get; set; }

    /// <summary>
    ///     Check only "devDependencies"
    /// </summary>
    public bool Dev { get; set; }

    /// <summary>
    ///     Specify a custom directory to store global packages
    /// </summary>
    public string GlobalDir { get; set; }

    /// <summary>
    ///     By default, details about the outdated packages (such as a link to the repo) are not displayed.
    ///     To display the details, pass this option.
    /// </summary>
    public bool Long { get; set; }

    /// <summary>
    ///     Don't check "optionalDependencies"
    /// </summary>
    public bool NoOptional { get; set; }

    /// <summary>
    ///     Prints the outdated packages in a list. Good for small consoles
    /// </summary>
    public bool NoTable { get; set; }

    /// <summary>
    ///     Check only "dependencies" and "optionalDependencies"
    /// </summary>
    public bool Prod { get; set; }

    /// <summary>
    ///     Check for outdated dependencies in every package found in subdirectories or in every workspace package,
    ///     when executed inside a workspace. For options that may be used with `-r`, see "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    ///     Stream output from child processes immediately, prefixed with the originating package directory.
    ///     This allows output from different packages to be interleaved.
    /// </summary>
    public bool Stream { get; set; }

    /// <summary>
    ///     Divert all output to stderr
    /// </summary>
    public bool UseStderr { get; set; }

    /// <summary>
    ///     Run the command on the root workspace project
    /// </summary>0
    public bool WorkspaceRoot { get; set; }

    /// <inheritdoc />
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (Dev && Prod) throw new ArgumentException("Dev conflicting with Prod setting");

        foreach (var package in Packages)
        {
            args.AppendQuoted(package);
        }

        base.EvaluateCore(args);
        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (AggregateOutput) args.Append("--aggregate-output");
        if (Compatible) args.Append("--compatible");
        if (Dev) args.Append("--dev");
        if (NoOptional) args.Append("--no-optional");
        if (Prod) args.Append("--prod");
        if (Recursive) args.Append("--recursive");
        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (!string.IsNullOrEmpty(GlobalDir)) args.AppendSwitchQuoted("--global-dir", GlobalDir);
        if (Stream) args.Append("--stream");
        if (UseStderr) args.Append("--use-stderr");
        if (WorkspaceRoot) args.Append("--workspace-root");
        if (Long) args.Append("--long");
        if (NoTable) args.Append("--no-table");
    }
}
