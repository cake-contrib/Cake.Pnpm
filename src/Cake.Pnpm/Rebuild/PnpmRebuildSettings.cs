using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Rebuild;

/// <summary>
///     Contains settings used by <see cref="PnpmRebuild" />.
/// </summary>
public class PnpmRebuildSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmRebuildSettings" /> class.
    /// </summary>
    public PnpmRebuildSettings() : base("rebuild")
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
    ///     Package names(s) to rebuild
    /// </summary>
    public HashSet<string> Packages { get; }

    /// <summary>
    ///     Rebuild packages that were not build during installation. Packages are not build when installing with the --ignore-scripts flag
    /// </summary>
    public bool Pending { get; set; }

    /// <summary>
    ///     Rebuild every package found in subdirectories or every workspace package, when executed inside a workspace. For options that may be used with `-r`, see "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    ///     The directory in which all the packages are saved on the disk
    /// </summary>
    public string StoreDir { get; set; }

    /// <summary>
    ///     Stream output from child processes immediately, prefixed with the originating package directory. This allows output
    ///     from different packages to be interleaved.
    /// </summary>
    public bool Stream { get; set; }

    /// <summary>
    ///     Divert all output to stderr
    /// </summary>
    public bool UseStderr { get; set; }

    /// <summary>
    ///     Run the command on the root workspace project
    /// </summary>
    public bool WorkspaceRoot { get; set; }

    /// <inheritdoc />
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        foreach (var package in Packages)
        {
            args.AppendQuoted(package);
        }

        base.EvaluateCore(args);
        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (AggregateOutput) args.Append("--aggregate-output");
        if (Pending) args.Append("--pending");
        if (Recursive) args.Append("--recursive");
        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (!string.IsNullOrEmpty(StoreDir)) args.AppendSwitchQuoted("--store-dir", StoreDir);
        if (Stream) args.Append("--stream");
        if (UseStderr) args.Append("--use-stderr");
        if (WorkspaceRoot) args.Append("--workspace-root");
    }
}
