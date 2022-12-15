using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Link;
using Cake.Pnpm.List;
using Cake.Pnpm.Rebuild;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm rebuild` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Rebuild")]
public static class PnpmRebuildAliases
{
    /// <summary>
    ///     Rebuild a package(s)
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packages">Package names to rebuild</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Rebuild")]
    public static void PnpmRebuild(this ICakeContext context, params string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        var settings = new PnpmRebuildSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        context.PnpmRebuild(settings);
    }

    /// <summary>
    ///     Rebuild a package(s) using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <param name="packages">Package names to rebuild</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Rebuild")]
    public static void PnpmRebuild(this ICakeContext context, Action<PnpmRebuildSettings> configurator, params  string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmRebuildSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        configurator(settings);
        context.PnpmRebuild(settings);
    }

    /// <summary>
    ///     Rebuild a package(s) using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("List")]
    public static void PnpmRebuild(this ICakeContext context, PnpmRebuildSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmRebuild = new PnpmRebuild(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmRebuild.Rebuild(settings);
    }
}
