using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Pnpm.Store;

/// <summary>
///     Contains settings used by <see cref="PnpmStore" />.
/// </summary>
public class PnpmStoreSettings : PnpmSettings
{
    /// <summary>
    ///     Keep 'add' string const
    /// </summary>
    public const string AddCommand = "add";

    /// <summary>
    ///     Keep 'path' string const
    /// </summary>
    public const string PathCommand = "path";

    /// <summary>
    ///     Keep 'prune' string const
    /// </summary>
    public const string PruneCommand = "prune";

    /// <summary>
    ///     Keep 'status' string const
    /// </summary>
    public const string StatusCommand = "status";

    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmStoreSettings" /> class.
    /// </summary>
    public PnpmStoreSettings() : base("store")
    {
        Packages = new HashSet<string>();
    }

    /// <summary>
    ///     Command to run
    /// </summary>
    internal string Command { get; set; }

    internal HashSet<string> Packages { get; }

    /// <inheritdoc />
   protected override void EvaluateCore(ProcessArgumentBuilder args)
   {
        if (string.IsNullOrEmpty(Command)) throw new InvalidOperationException("Command is required");

        base.EvaluateCore(args);

        args.Append(Command);

        if (!AddCommand.Equals(Command, StringComparison.OrdinalIgnoreCase)) return;

        if (Packages.Count == 0) throw new InvalidOperationException("Packages is required");
        foreach (var package in Packages)
        {
            args.AppendQuoted(package);
        }
   }
}
