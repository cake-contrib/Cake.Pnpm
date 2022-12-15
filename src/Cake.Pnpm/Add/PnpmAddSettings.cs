using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Add;

/// <summary>
///     Contains settings used by <see cref="PnpmAdd" />.
/// </summary>
public class PnpmAddSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmAddSettings" /> class.
    /// </summary>
    public PnpmAddSettings() : base("add")
    {
    }

    /// <summary>
    /// Package name to install
    /// </summary>
    public string PackageName { get; set; }

    /// <summary>
    ///     Install exact version
    /// </summary>
    public bool? SaveExact { get; set; }

    /// <summary>
    ///     Save packages from the workspace with a "workspace:" protocol. True by default
    /// </summary>
    public bool? SaveWorkspaceProtocol { get; set; }

    /// <summary>
    ///     Install as a global package
    /// </summary>
    public bool Global { get; set; }

    /// <summary>
    ///     Save package to your `devDependencies`
    /// </summary>
    public bool SaveDev { get; set; }

    /// <summary>
    ///     Save package to your `optionalDependencies`
    /// </summary>
    public bool SaveOptional { get; set; }

    /// <summary>
    ///     Save package to your `peerDependencies` and `devDependencies`
    /// </summary>
    public bool SavePeer { get; set; }

    /// <summary>
    ///     Save package to your `dependencies`. The default behavior
    /// </summary>
    public bool SaveProd { get; set; }

    /// <summary>
    ///     Only adds the new dependency if it is found in the workspace
    /// </summary>
    public bool Workspace { get; set; }

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
    ///     Specify a custom directory to store global packages
    /// </summary>
    public string GlobalDir { get; set; }

    /// <summary>
    ///     Don't run lifecycle scripts
    /// </summary>
    public bool IgnoreScripts { get; set; }

    /// <summary>
    ///     Trigger an error if any required dependencies are not available in local store
    /// </summary>
    public bool Offline { get; set; }

    /// <summary>
    ///     Skip staleness checks for cached data, but request missing data from the server
    /// </summary>
    public bool PreferOffline { get; set; }

    /// <summary>
    ///     Run installation recursively in every package found in subdirectories. For options that may be used with `-r`, see
    ///     "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

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
    ///     The directory with links to the store (default is node_modules/.pnpm). All direct and indirect dependencies of the
    ///     project are linked into this directory
    /// </summary>
    public string VirtualStoreDir { get; set; }

    /// <summary>
    ///     The directory in which all the packages are saved on the disk
    /// </summary>
    public string StoreDir { get; set; }

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
        if (!string.IsNullOrEmpty(GlobalDir)) args.AppendSwitchQuoted("--global-dir", GlobalDir);
        if (IgnoreScripts) args.Append("--ignore-scripts");
        if (Offline) args.Append("--offline");
        if (PreferOffline) args.Append("--prefer-offline");
        if (Recursive) args.Append("--recursive");
        if (Stream) args.Append("--stream");
        if (UseStderr) args.Append("--use-stderr");
        if (WorkspaceRoot) args.Append("--workspace-root");
        if (!string.IsNullOrEmpty(VirtualStoreDir)) args.AppendSwitchQuoted("--virtual-store-dir", VirtualStoreDir);
        if (!string.IsNullOrEmpty(StoreDir)) args.AppendSwitchQuoted("--store-dir", StoreDir);
        if (SaveExact.HasValue) args.Append(SaveExact.Value ? "--save-exact" : "--no-save-exact");
        if (Global) args.Append("--global");
        if (SaveWorkspaceProtocol.HasValue) args.Append(SaveWorkspaceProtocol.Value ? "--save-workspace-protocol" : "--no-save-workspace-protocol");
        if (SaveDev) args.Append("--save-dev");
        if (SaveOptional) args.Append("--save-optional");
        if (SavePeer) args.Append("--save-peer");
        if (SaveProd) args.Append("--save-prod");
        if (Workspace) args.Append("--workspace");
    }
}
