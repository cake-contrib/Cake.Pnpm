using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Link;
using Cake.Pnpm.Prune;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm prune` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Prune")]
public static class PnpmPruneAliases
{
    /// <summary>
    ///     Removes extraneous packages
    /// </summary>
    /// <param name="context">The context.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Prune")]
    public static void PnpmPrune(this ICakeContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.PnpmLink(new PnpmLinkSettings());
    }

    /// <summary>
    ///     Removes extraneous packages using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Prune")]
    public static void PnpmPrune(this ICakeContext context, Action<PnpmPruneSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmPruneSettings();
        configurator(settings);
        context.PnpmPrune(settings);
    }

    /// <summary>
    ///     Removes extraneous packages using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Prune")]
    public static void PnpmPrune(this ICakeContext context, PnpmPruneSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmInstall = new PnpmPrune(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmInstall.Prune(settings);
    }
}
