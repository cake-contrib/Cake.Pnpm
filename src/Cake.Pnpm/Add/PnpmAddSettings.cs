using System;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Add;

/// <summary>
///     Contains settings used by <see cref="PnpmAdd" />.
/// </summary>
public class PnpmAddSettings : SharedPnpmSettings
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

    /// <inheritdoc cref="PnpmSettings" />
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (string.IsNullOrEmpty(PackageName)) throw new ArgumentException($"{PackageName} setting is required for that command");
        args.AppendQuoted(PackageName);
        base.EvaluateCore(args);

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
