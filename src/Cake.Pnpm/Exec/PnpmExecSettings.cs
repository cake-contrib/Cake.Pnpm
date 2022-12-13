using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Exec;

/// <summary>
///     Contains settings used by <see cref="PnpmExec" />.
/// </summary>
public class PnpmExecSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmExecSettings" /> class.
    /// </summary>
    public PnpmExecSettings() : base("exec")
    {
    }

    /// <summary>
    ///     Command to run
    /// </summary>
    public string Command { get; set; }

    /// <summary>
    ///     Run the shell command in every package found in subdirectories or
    ///     every workspace package, when executed inside a workspace.
    ///     For options that may be used with `-r`, see "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    ///     If exist, runs file inside of a shell. Uses /bin/sh on UNIX and
    ///     `cmd.exe` on Windows. The shell should understand the -c switch
    ///     on UNIX or /d /s /c on Windows.
    /// </summary>
    public bool ShellMode { get; set; }

    /// <summary>
    ///     Completely disregard concurrency and topological sorting, running
    ///     a given script immediately in all matching packages with prefixed
    ///     streaming output. This is the preferred flag for long-running
    ///     processes such as watch run over many packages.
    /// </summary>
    public bool Parallel { get; set; }

   /// <inheritdoc />
   protected override void EvaluateCore(ProcessArgumentBuilder args)
   {
       if (string.IsNullOrEmpty(Command)) throw new InvalidOperationException("Command setting is required");
        base.EvaluateCore(args);
        if (Recursive) args.Prepend("-r");
        if (ShellMode) args.Prepend("-c");
        if (Parallel) args.Prepend("--parallel");
        args.Append(Command);
    }
}
