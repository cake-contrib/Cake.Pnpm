using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Outdated;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm outdated` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Outdated")]
public static class PnpmOutdatedAliases
{
    /// <summary>
    ///     Check for outdated packages
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packages">Package names to check</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Outdated")]
    public static void PnpmOutdated(this ICakeContext context, params string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        var settings = new PnpmOutdatedSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        context.PnpmOutdated(settings);
    }

    /// <summary>
    ///     Check for outdated packages using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <param name="packages">Package names to check</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Outdated")]
    public static void PnpmOutdated(this ICakeContext context, Action<PnpmOutdatedSettings> configurator, params  string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmOutdatedSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        configurator(settings);
        context.PnpmOutdated(settings);
    }

    /// <summary>
    ///     Check for outdated packages using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Outdated")]
    public static void PnpmOutdated(this ICakeContext context, PnpmOutdatedSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmOutdated = new PnpmOutdated(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmOutdated.Outdated(settings);
    }
}
