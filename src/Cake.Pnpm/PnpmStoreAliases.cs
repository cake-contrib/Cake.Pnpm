using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Run;
using Cake.Pnpm.Store;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm store` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Store")]
public static class PnpmStoreAliases
{
    /// <summary>
    ///     Adds new packages to the store. Example: pnpm store add express@4 typescript@2.1.0
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packages">Packages to add in store</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Store")]
    public static void PnpmStoreAdd(this ICakeContext context, params string[] packages)
    {
        var pnpmStoreSettings = new PnpmStoreSettings();
        foreach (var package in packages)
        {
            pnpmStoreSettings.Packages.Add(package);
        }
        context.PnpmStore(PnpmStoreSettings.AddCommand, pnpmStoreSettings);
    }

    /// <summary>
    ///     Returns the path to the active store directory.
    /// </summary>
    /// <param name="context">The context.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Store")]
    public static void PnpmStorePath(this ICakeContext context)
    {
        context.PnpmStore(PnpmStoreSettings.PathCommand, new PnpmStoreSettings());
    }

    /// <summary>
    ///     Removes unreferenced (extraneous, orphan) packages from the store.
    ///     Pruning the store is not harmful, but might slow down future installations.
    ///     Visit the documentation for more information on unreferenced packages
    /// </summary>
    /// <param name="context">The context.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Store")]
    public static void PnpmStorePrune(this ICakeContext context)
    {
        context.PnpmStore(PnpmStoreSettings.PruneCommand, new PnpmStoreSettings());
    }

    /// <summary>
    ///     Checks for modified packages in the store. Returns exit code 0 if the
    ///     content of the package is the same as it was at the time of unpacking
    /// </summary>
    /// <param name="context">The context.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Store")]
    public static void PnpmStoreStatus(this ICakeContext context)
    {
        context.PnpmStore(PnpmStoreSettings.StatusCommand, new PnpmStoreSettings());
    }

    private static void PnpmStore(this ICakeContext context, string command, PnpmStoreSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        if (string.IsNullOrEmpty(command)) throw new ArgumentNullException(nameof(command));

        settings.Command = command;
        AddinInformation.LogVersionInformation(context.Log);
        var pnpmStore = new PnpmStore(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmStore.RunCommand(settings);
    }
}
