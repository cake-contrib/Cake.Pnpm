using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.List;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm list` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.List")]
public static class PnpmListAliases
{
    /// <summary>
    ///     Connect the local project to another one
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packages">Package names to list</param>
    [CakeMethodAlias]
    [CakeAliasCategory("List")]
    public static void PnpmList(this ICakeContext context, params string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        var settings = new PnpmListSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        context.PnpmList(settings);
    }

    /// <summary>
    ///     Connect the local project to another one using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <param name="packages">Package names to list</param>
    [CakeMethodAlias]
    [CakeAliasCategory("List")]
    public static void PnpmList(this ICakeContext context, Action<PnpmListSettings> configurator, params  string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmListSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        configurator(settings);
        context.PnpmList(settings);
    }

    /// <summary>
    ///     Connect the local project to another one using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("List")]
    public static void PnpmList(this ICakeContext context, PnpmListSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmList = new PnpmList(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmList.List(settings);
    }
}
