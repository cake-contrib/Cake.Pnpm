using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Remove;

/// <summary>
///     Contains settings used by <see cref="Add.PnpmAdd" />.
/// </summary>
public class PnpmRemoveSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmRemoveSettings" /> class.
    /// </summary>
    public PnpmRemoveSettings() : base("remove")
    {
    }

    /// <summary>
    /// Package name to remove
    /// </summary>
    public string PackageName { get; set; }

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
    ///     Remove the dependency only from 'devDependencies'
    /// </summary>
    public bool SaveDev { get; set; }

    /// <summary>
    ///     Remove the dependency only from 'optionalDependencies'
    /// </summary>
    public bool SaveOptional { get; set; }

    /// <summary>
    ///     Remove the dependency only from 'dependencies'
    /// </summary>
    public bool SaveProd { get; set; }

    /// <summary>
    ///     Stream output from child processes immediately, prefixed with the originating package directory. This allows output
    ///     from different packages to be interleaved.
    /// </summary>
    public bool Stream { get; set; }

    /// <summary>
    ///     Remove from every package found in subdirectories or from every workspace package, when executed inside a workspace. For options that may be used with `-r`, see "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    ///     Divert all output to stderr
    /// </summary>
    public bool UseStderr { get; set; }

    /// <summary>
    ///     Run the command on the root workspace project
    /// </summary>
    public bool WorkspaceRoot { get; set; }

    /// <inheritdoc cref="PnpmSettings" />
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (string.IsNullOrEmpty(PackageName)) throw new ArgumentException($"{PackageName} setting is required for that command");

        args.AppendQuoted(PackageName);

        base.EvaluateCore(args);

        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (AggregateOutput) args.Append("--aggregate-output");
        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (Recursive) args.Append("--recursive");
        if (Stream) args.Append("--stream");
        if (SaveDev) args.Append("--save-dev");
        if (SaveOptional) args.Append("--save-optional");
        if (SaveProd) args.Append("--save-prod");
        if (UseStderr) args.Append("--use-stderr");
        if (WorkspaceRoot) args.Append("--workspace-root");

    }
}
