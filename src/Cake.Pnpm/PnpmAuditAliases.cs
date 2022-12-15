using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Audit;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm audit` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Audit")]
public static class PnpmAuditAliases
{
    /// <summary>
    ///     Checks for known security issues with the installed packages.
    /// </summary>
    /// <param name="context">The context.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Audit")]
    public static void PnpmAudit(this ICakeContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.PnpmAudit(new PnpmAuditSettings());
    }

    /// <summary>
    ///     Checks for known security issues with the installed packages using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Audit")]
    public static void PnpmAudit(this ICakeContext context, Action<PnpmAuditSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmAuditSettings();
        configurator(settings);
        context.PnpmAudit(settings);
    }

    /// <summary>
    ///     Checks for known security issues with the installed packages using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Audit")]
    public static void PnpmAudit(this ICakeContext context, PnpmAuditSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmInstall = new PnpmAudit(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmInstall.Audit(settings);
    }
}
