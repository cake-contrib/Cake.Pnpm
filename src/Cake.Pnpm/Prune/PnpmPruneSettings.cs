using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Prune;

/// <summary>
///
/// </summary>
public class PnpmPruneSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmPruneSettings" /> class.
    /// </summary>
    public PnpmPruneSettings() : base("prune")
    {
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
    ///     Remove the packages specified in `optionalDependencies`
    /// </summary>
    public bool NoOptional { get; set; }

    /// <summary>
    ///     Remove the packages specified in `devDependencies`
    /// </summary>
    public bool Prod { get; set; }

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
        base.EvaluateCore(args);
        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (AggregateOutput) args.Append("--aggregate-output");
        if (NoOptional) args.Append("--no-optional");
        if (Prod) args.Append("--prod");
        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (Stream) args.Append("--stream");
        if (UseStderr) args.Append("--use-stderr");
        if (WorkspaceRoot) args.Append("--workspace-root");
    }
}
