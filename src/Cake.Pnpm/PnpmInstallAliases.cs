using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Install;

namespace Cake.Pnpm;

/// <summary>
///     Pnpm Install aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Install")]
public static class PnpmInstallAliases
{
    /// <summary>
    ///     Install packages using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Install")]
    public static void PnpmInstall(this ICakeContext context, Action<PnpmInstallSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmInstallSettings();
        configurator(settings);
        context.PnpmInstall(settings);
    }

    /// <summary>
    ///     Install packages using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Install")]
    public static void PnpmInstall(this ICakeContext context, PnpmInstallSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));


        AddinInformation.LogVersionInformation(context.Log);
        var pnpmInstall = new PnpmInstaller(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmInstall.Install(settings);
    }
}
