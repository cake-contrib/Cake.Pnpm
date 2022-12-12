using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.List;

/// <summary>
///     Contains settings used by <see cref="PnpmList" />.
/// </summary>
public class PnpmListSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmListSettings" /> class.
    /// </summary>
    public PnpmListSettings() : base("list")
    {
        Packages = new HashSet<string>();
    }

    /// <summary>
    ///     Aggregate output from child processes that are run in parallel, and only print output when child process is
    ///     finished. It makes reading large logs after running `pnpm recursive` with `--parallel` or with
    ///     `--workspace-concurrency` much easier (especially on CI). Only `--reporter=append-only` is supported.
    /// </summary>
    public bool AggregateOutput { get; set; }

    /// <summary>
    ///     Controls colors in the output. By default, output is always colored when it goes directly to a terminal
    /// </summary>
    public bool? Color { get; set; }

    /// <summary>
    ///     Change to directory (default: the running dir)
    /// </summary>

    public string Dir { get; set; }
    /// <summary>
    ///     Max display depth of the dependency tree
    ///     To display only projects use '-1' value
    ///     To Display only direct dependencies use '0' value (default value)
    /// </summary>
    public int? Depth { get; set; }

    /// <summary>
    ///     Check only 'devDependencies'
    /// </summary>
    public bool Dev { get; set; }

    /// <summary>
    ///     Update globally installed packages
    /// </summary>
    public bool Global { get; set; }

    /// <summary>
    ///     Specify a custom directory to store global packages
    /// </summary>
    public string GlobalDir { get; set; }

    /// <summary>
    ///     Show information in JSON format
    /// </summary>
    public bool Json { get; set; }

    /// <summary>
    ///     Show extended information
    /// </summary>
    public bool Long { get; set; }

    /// <summary>
    ///     Don't check 'optionalDependencies'
    /// </summary>
    public bool NoOptional { get; set; }

    /// <summary>
    /// Packages names to show information about
    /// </summary>
    public HashSet<string> Packages { get; }

    /// <summary>
    ///     Show parseable output instead of tree view
    /// </summary>
    public bool Parseable { get; set; }

    /// <summary>
    ///     Check only "dependencies" and "optionalDependencies"
    /// </summary>
    public bool Prod { get; set; }

    /// <summary>
    ///     Perform command on every package in subdirectories or on every workspace package,
    ///     when executed inside a workspace. For options that may be used with `-r`, see "pnpm help recursive
    /// </summary>
    public bool Recursive { get; set; }
    /// <summary>
    ///     Run the command on the root workspace project
    /// </summary>
    public bool WorkspaceRoot { get; set; }

    /// <summary>
    ///     Stream output from child processes immediately, prefixed with the originating package directory. This allows output
    ///     from different packages to be interleaved.
    /// </summary>
    public bool Stream { get; set; }

    /// <summary>
    ///     Divert all output to stderr
    /// </summary>
    public bool UseStderr { get; set; }


   /// <inheritdoc />
   protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (Dev && Prod) throw new ArgumentException("Dev conflicting with Prod setting");

        foreach (var package in Packages)
        {
            args.AppendQuoted(package);
        }

        base.EvaluateCore(args);

        if (AggregateOutput) args.Append("--aggregate-output");
        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (Depth.HasValue) args.AppendSwitch("--depth", Depth.ToString());
        if (Dev) args.Append("--dev");
        if (Json) args.Append("--json");
        if (Long) args.Append("--long");
        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (!string.IsNullOrEmpty(GlobalDir)) args.AppendSwitchQuoted("--global-dir", GlobalDir);
        if (Global) args.Append("--global");
        if (NoOptional) args.Append("--no-optional");
        if (Parseable) args.Append("--parseable");
        if (Prod) args.Append("--prod");
        if (Recursive) args.Append("--recursive");
        if (Stream) args.Append("--stream");
        if (UseStderr) args.Append("--use-stderr");
        if (WorkspaceRoot) args.Append("--workspace-root");
    }
}
