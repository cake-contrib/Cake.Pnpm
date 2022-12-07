using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Install;

/// <summary>
///     Contains settings used by <see cref="PnpmInstaller" />.
/// </summary>
public class PnpmInstallSettings : PnpmSettings
{
    /// <summary>
    /// </summary>
    public PnpmInstallSettings() : base("install")
    {
    }

    /// <summary>
    ///     Controls colors in the output. By default, output is always colored when it goes directly to a terminal
    /// </summary>
    public bool? Color { get; set; }

    /// <summary>
    ///     Don't generate a lockfile and fail if an update is needed. This setting is on by default in CI environments, so use
    ///     --no-frozen-lockfile if you need to disable it for some reason
    /// </summary>
    public bool? FrozenLockfile { get; set; }

    /// <summary>
    ///     If false, doesn't check whether packages in the store were mutated
    /// </summary>
    public bool? VerifyStoreIntegrity { get; set; }

    /// <summary>
    ///     Aggregate output from child processes that are run in parallel, and only print output when child process is
    ///     finished. It makes reading large logs after running `pnpm recursive` with `--parallel` or with
    ///     `--workspace-concurrency` much easier (especially on CI). Only `--reporter=append-only` is supported.
    /// </summary>
    public bool AggregateOutput { get; set; }

    /// <summary>
    ///     Only `devDependencies` are installed regardless of the `NODE_ENV`
    /// </summary>
    public bool Dev { get; set; }

    /// <summary>
    ///     Fix broken lockfile entries automatically
    /// </summary>
    public bool FixLockfile { get; set; }

    /// <summary>
    ///     Force reinstall dependencies: refetch packages modified in store, recreate a lockfile and/or modules directory
    ///     created by a non-compatible version of pnpm
    /// </summary>
    public bool Force { get; set; }

    /// <summary>
    ///     Specify a custom directory to store global packages
    /// </summary>
    public string GlobalDir { get; set; }

    /// <summary>
    ///     Disable pnpm hooks defined in .pnpmfile.cjs
    /// </summary>
    public bool IgnorePnpmfile { get; set; }

    /// <summary>
    ///     Don't run lifecycle scripts
    /// </summary>
    public bool IgnoreScripts { get; set; }

    /// <summary>
    ///     Dependencies are not downloaded. Only `pnpm-lock.yaml` is updated
    /// </summary>
    public bool LockfileOnly { get; set; }

    /// <summary>
    ///     Merge lockfiles were generated on git branch
    /// </summary>
    public bool MergeGitBranchLockfiles { get; set; }

    /// <summary>
    ///     Dependencies inside the modules directory will have access only to their listed dependencies
    /// </summary>
    public bool NoHoist { get; set; }

    /// <summary>
    ///     Don't read or generate a `pnpm-lock.yaml` file
    /// </summary>
    public bool NoLockfile { get; set; }

    /// <summary>
    ///     `optionalDependencies` are not installed
    /// </summary>
    public bool NoOptional { get; set; }

    /// <summary>
    ///     Trigger an error if any required dependencies are not available in local store
    /// </summary>
    public bool Offline { get; set; }

    /// <summary>
    ///     If the available `pnpm-lock.yaml` satisfies the `package.json` then perform a headless installation
    /// </summary>
    public bool PreferFrozenLockfile { get; set; }

    /// <summary>
    ///     Skip staleness checks for cached data, but request missing data from the server
    /// </summary>
    public bool PreferOffline { get; set; }

    /// <summary>
    ///     Packages in `devDependencies` won't be installed
    /// </summary>
    public bool Prod { get; set; }

    /// <summary>
    ///     Run installation recursively in every package found in subdirectories. For options that may be used with `-r`, see
    ///     "pnpm help recursive"
    /// </summary>
    public bool Recursive { get; set; }

    /// <summary>
    ///     All the subdeps will be hoisted into the root node_modules. Your code will have access to them
    /// </summary>
    public bool ShamefullyHoist { get; set; }

    /// <summary>
    ///     Use or cache the results of (pre/post)install hooks
    /// </summary>
    public bool SideEffectsCache { get; set; }

    /// <summary>
    ///     Only use the side effects cache if present, do not create it for new packages
    /// </summary>
    public bool SideEffectsCacheReadonly { get; set; }

    /// <summary>
    ///     Stream output from child processes immediately, prefixed with the originating package directory. This allows output
    ///     from different packages to be interleaved.
    /// </summary>
    public bool Stream { get; set; }

    /// <summary>
    ///     Fail on missing or invalid peer dependencies
    /// </summary>
    public bool StrictPeerDependencies { get; set; }

    /// <summary>
    ///     Only allows installation with a store server. If no store server is running, installation will fail
    /// </summary>
    public bool UseRunningStoreServer { get; set; }

    /// <summary>
    ///     Divert all output to stderr
    /// </summary>
    public bool UseStderr { get; set; }

    /// <summary>
    ///     Starts a store server in the background. The store server will keep running after installation is done. To stop the
    ///     store server, run `pnpm server stop`
    /// </summary>
    public bool UseStoreServer { get; set; }

    /// <summary>
    ///     Run the command on the root workspace project
    /// </summary>
    public bool WorkspaceRoot { get; set; }

    /// <summary>
    ///     Controls the number of child processes run parallelly to build node modules
    /// </summary>
    public int ChildConcurrency { get; set; }

    /// <summary>
    ///     Change to directory (default: the running dir)
    /// </summary>
    public string Dir { get; set; }

    /// <summary>
    ///     Hoist all dependencies matching the pattern to `node_modules/.pnpm/node_modules`. The default pattern is * and
    ///     matches everything. Hoisted packages can be required by any dependencies, so it is an emulation of a flat
    ///     node_modules
    /// </summary>
    public string HoistPattern { get; set; }

    /// <summary>
    ///     The directory in which the pnpm-lock.yaml of the package will be created. Several projects may share a single
    ///     lockfile.
    /// </summary>
    public string LockfileDir { get; set; }

    /// <summary>
    ///     The directory in which dependencies will be installed (instead of node_modules)
    /// </summary>
    public string ModulesDir { get; set; }

    /// <summary>
    ///     Maximum number of concurrent network requests
    /// </summary>
    public int NetworkConcurrency { get; set; }

    /// <summary>
    ///     Clones/hardlinks or copies packages. The selected method depends from the file system
    /// </summary>
    public PackageImportMethodType? PackageImportMethod { get; set; }


    /// <summary>
    ///     Hoist all dependencies matching the pattern to the root of the modules directory
    /// </summary>
    public string PublicHoistPattern { get; set; }

    /// <summary>
    ///     The directory in which all the packages are saved on the disk
    /// </summary>
    public string StoreDir { get; set; }

    /// <summary>
    ///     The directory with links to the store (default is node_modules/.pnpm). All direct and indirect dependencies of the
    ///     project are linked into this directory
    /// </summary>
    public string VirtualStoreDir { get; set; }

    /// <summary>
    ///     Define the output reporting type
    /// </summary>
    public OutputReportingType OutputReportingType { get; set; }

    /// <summary>
    ///     Evaluates the settings and writes them to <paramref name="args" />.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        base.EvaluateCore(args);

        if (Color.HasValue) args.Append(Color.Value ? "--color" : "--no-color");
        if (FrozenLockfile.HasValue) args.Append(FrozenLockfile.Value ? "--frozen-lockfile" : "--no-frozen-lockfile");
        if (FrozenLockfile.HasValue)
            args.Append(FrozenLockfile.Value ? "--verify-store-integrity" : "--no-verify-store-integrity");

        if (AggregateOutput) args.Append("--aggregate-output");
        if (ChildConcurrency > 0) args.AppendSwitch("--aggregate-output", ChildConcurrency.ToString());

        if (Dev)
        {
            if (Prod) throw new ArgumentException("Dev conflicting with Prod setting");
            args.Append("--dev");
        }

        if (!string.IsNullOrEmpty(Dir)) args.AppendSwitchQuoted("--dir", Dir);
        if (FixLockfile) args.Append("--fix-lockfile");
        if (Force) args.Append("--force");
        if (!string.IsNullOrEmpty(GlobalDir)) args.AppendSwitchQuoted("--global-dir", GlobalDir);
        if (!string.IsNullOrEmpty(HoistPattern)) args.AppendSwitchQuoted("--hoist-pattern", HoistPattern);
        if (IgnorePnpmfile) args.Append("--ignore-pnpmfile");
        if (IgnoreScripts) args.Append("ignore-scripts");
        if (!string.IsNullOrEmpty(LockfileDir)) args.AppendSwitchQuoted("--lockfile-dir", LockfileDir);
        if (LockfileOnly) args.Append("--lockfile-only");
        if (MergeGitBranchLockfiles) args.Append("--merge-git-branch-lockfiles");
        if (!string.IsNullOrEmpty(ModulesDir)) args.AppendSwitchQuoted("--modules-dir", ModulesDir);
        if (NetworkConcurrency > 0) args.AppendSwitch("--network-concurrency", NetworkConcurrency.ToString());
        if (NoHoist) args.Append("--no-hoist");
        if (NoLockfile) args.Append("--no-lockfile");
        if (NoOptional) args.Append("--no-optional");
        if (Offline) args.Append("--offline");

        if (PackageImportMethod.HasValue)
            switch (PackageImportMethod.Value)
            {
                case PackageImportMethodType.Auto:
                    args.AppendSwitch("--package-import-method", "auto");
                    break;
                case PackageImportMethodType.Clone:
                    args.AppendSwitch("--package-import-method", "clone");
                    break;
                case PackageImportMethodType.Copy:
                    args.AppendSwitch("--package-import-method", "copy");
                    break;
                case PackageImportMethodType.Hardlink:
                    args.AppendSwitch("--package-import-method", "hardlink");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        if (PreferFrozenLockfile) args.Append("--prefer-frozen-lockfile");
        if (PreferOffline) args.Append("--prefer-offline");
        if (Prod) args.Append("--prod");

        if (!string.IsNullOrEmpty(PublicHoistPattern))
            args.AppendSwitchQuoted("--public-hoist-pattern", PublicHoistPattern);

        if (Recursive) args.Append("--recursive");
        if (ShamefullyHoist) args.Append("--shamefully-hoist");

        if (SideEffectsCache)
        {
            if (SideEffectsCacheReadonly)
                throw new ArgumentException("SideEffectsCache conflicting with SideEffectsCacheReadonly setting");
            args.Append("--side-effects-cache");
        }

        if (SideEffectsCacheReadonly) args.Append("--side-effects-cache-readonly");
        if (!string.IsNullOrEmpty(StoreDir)) args.AppendSwitchQuoted("--store-dir", StoreDir);
        if (Stream) args.Append("--stream");
        if (StrictPeerDependencies) args.Append("--strict-peer-dependencies");
        if (UseRunningStoreServer) args.Append("--use-running-store-server");
        if (UseStderr) args.Append("--use-stderr");
        if (UseStoreServer) args.Append("--use-store-server");
        if (!string.IsNullOrEmpty(VirtualStoreDir)) args.AppendSwitchQuoted("--virtual-store-dir", VirtualStoreDir);
        if (WorkspaceRoot) args.Append("--workspace-root");

        if (PnpmLogLevel != PnpmLogLevel.Silent)
            switch (OutputReportingType)
            {
                case OutputReportingType.Default:
                    args.AppendSwitch("--reporter", "default");
                    break;
                case OutputReportingType.AppendOnly:
                    args.AppendSwitch("--reporter", "append-only");
                    break;
                case OutputReportingType.Ndjson:
                    args.AppendSwitch("--reporter", "ndjson");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
    }
}
