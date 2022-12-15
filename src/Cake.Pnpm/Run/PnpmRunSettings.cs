using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Run;

/// <summary>
///     Contains settings used by <see cref="PnpmRun" />.
/// </summary>
public class PnpmRunSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmRunSettings" /> class.
    /// </summary>
    public PnpmRunSettings() : base("run")
    {
    }

    /// <summary>
    ///     Command to run
    /// </summary>
    public string Command { get; internal set; }

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
    ///     Avoid exiting with a non-zero exit code when the script is undefined
    /// </summary>
    public bool IfPresent { get; set; }

    /// <summary>
    ///     The command will exit with a 0 exit code even if the script fails
    /// </summary>
    public bool NoBail { get; set; }

    /// <summary>
    ///     Run the defined package script in every package found in subdirectories or
    ///     every workspace package, when executed inside a workspace. For options that
    ///     may be used with `-r`, see "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    ///     Completely disregard concurrency and topological sorting, running
    ///     a given script immediately in all matching packages with prefixed
    ///     streaming output. This is the preferred flag for long-running
    ///     processes such as watch run over many packages.
    /// </summary>
    public bool Parallel { get; set; }

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
        if (string.IsNullOrEmpty(Command)) throw new InvalidOperationException("Command setting is required");
        base.EvaluateCore(args);

        args.Append(Command);
        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (AggregateOutput) args.Append("--aggregate-output");
        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (IfPresent) args.Append("--if-present");
        if (NoBail) args.Append("--no-bail");
        if (Recursive) args.Append("--recursive");
        if (Parallel) args.Append("--parallel");
        if (Stream) args.Append("--stream");
        if (UseStderr) args.Append("--use-stderr");
        if (WorkspaceRoot) args.Append("--workspace-root");

    }
}
