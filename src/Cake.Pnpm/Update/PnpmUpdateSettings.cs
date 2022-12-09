using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Update;

/// <summary>
///     Contains settings used by <see cref="PnpmUpdate" />.
/// </summary>
public class PnpmUpdateSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmUpdateSettings" /> class.
    /// </summary>
    public PnpmUpdateSettings() : base("update")
    {
        Packages = new HashSet<string>();
    }

    /// <summary>
    ///     Controls colors in the output. By default, output is always colored when it goes directly to a terminal
    /// </summary>
    public bool? Color { get; set; }

    /// <summary>
    /// Packages names to update
    /// </summary>
    public HashSet<string> Packages { get; }

    /// <summary>
    ///     How deep should levels of dependencies be inspected.
    ///     Infinity is default. 0 would mean top-level dependencies only
    /// </summary>
    public int Depth { get; set; }

    /// <summary>
    ///     Update packages only in 'devDependencies'
    /// </summary>
    public bool Dev { get; set; }

    /// <summary>
    ///     Change to directory (default: the running dir)
    /// </summary>
    public string Dir { get; set; }

    /// <summary>
    ///     Update globally installed packages
    /// </summary>
    public bool Global { get; set; }

    /// <summary>
    ///     Specify a custom directory to store global packages
    /// </summary>
    public string GlobalDir { get; set; }

    /// <summary>
    ///     Show outdated dependencies and select which ones to update
    /// </summary>
    public bool Interactive { get; set; }

    /// <summary>
    ///     Don't update packages in 'optionalDependencies'
    /// </summary>
    public bool NoOptional { get; set; }

    /// <summary>
    ///     Update packages only in 'dependencies' and 'optionalDependencies'
    /// </summary>
    public bool Prod { get; set; }

    /// <summary>
    ///     Ignore version ranges in package.json
    /// </summary>
    public bool Latest { get; set; }

    /// <summary>
    ///     Update in every package found in subdirectories or every workspace package,
    ///     when executed inside a workspace. For options that may be used with `-r`,
    ///     see "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    ///     Only adds the new dependency if it is found in the workspace
    /// </summary>
    public bool Workspace { get; set; }

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

    /// <inheritdoc cref="PnpmSettings" />
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (Dev && Prod) throw new ArgumentException("Dev conflicting with Prod setting");

        foreach (var package in Packages)
        {
            args.AppendQuoted(package);
        }

        base.EvaluateCore(args);

        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (Depth > 0) args.AppendSwitch("--depth", Depth.ToString());
        if (Dev) args.Append("--dev");
        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (Global) args.AppendSwitchQuoted("--global", Dir);
        if (!string.IsNullOrEmpty(GlobalDir)) args.AppendSwitchQuoted("--global-dir", GlobalDir);
        if (Global) args.Append("--global");
        if (Interactive) args.Append("--interactive");
        if (Latest) args.Append("--latest");
        if (NoOptional) args.Append("--no-optional");
        if (Prod) args.Append("--prod");
        if (Recursive) args.Append("--recursive");
        if (Stream) args.Append("--stream");
        if (UseStderr) args.Append("--use-stderr");
        if (Workspace) args.Append("--workspace");
        if (WorkspaceRoot) args.Append("--workspace-root");
    }
}
