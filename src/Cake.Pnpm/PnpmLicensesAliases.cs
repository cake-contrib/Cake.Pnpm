using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Licenses;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm licenses` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Licenses")]
public static class PnpmLicensesAliases
{
    /// <summary>
    ///     Check the licenses of the installed packages.
    /// </summary>
    /// <param name="context">The context.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Licenses")]
    public static void PnpmLicenses(this ICakeContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.PnpmLicenses(new PnpmLicensesSettings());
    }

    /// <summary>
    ///     Check the licenses of the installed packages using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Licenses")]
    public static void PnpmLicenses(this ICakeContext context, Action<PnpmLicensesSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmLicensesSettings();
        configurator(settings);
        context.PnpmLicenses(settings);
    }

    /// <summary>
    ///     Check the licenses of the installed packages using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Licenses")]
    public static void PnpmLicenses(this ICakeContext context, PnpmLicensesSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmLicenses = new PnpmLicenses(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmLicenses.List(settings);
    }
}
