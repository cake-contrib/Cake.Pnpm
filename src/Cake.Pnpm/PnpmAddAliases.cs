using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Add;

namespace Cake.Pnpm;

/// <summary>
///     Pnpm Install aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Add")]
public static class PnpmAddAliases
{
    /// <summary>
    ///     Install package using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Add")]
    public static void PnpmAdd(this ICakeContext context, Action<PnpmAddSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmAddSettings();
        configurator(settings);
        context.PnpmAdd(settings);
    }

    /// <summary>
    ///     Install package using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Add")]
    public static void PnpmAdd(this ICakeContext context, PnpmAddSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));


        AddinInformation.LogVersionInformation(context.Log);
        var pnpmInstall = new PnpmAdd(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmInstall.Add(settings);
    }
}

