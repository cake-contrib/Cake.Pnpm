using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Link;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm link` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Link")]
public static class PnpmLinkAliases
{
    /// <summary>
    ///     Connect the local project to another one
    /// </summary>
    /// <param name="context">The context.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Link")]
    public static void PnpmLink(this ICakeContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.PnpmLink(new PnpmLinkSettings());
    }

    /// <summary>
    ///     Connect the local project to another one using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Install")]
    public static void PnpmLink(this ICakeContext context, Action<PnpmLinkSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmLinkSettings();
        configurator(settings);
        context.PnpmLink(settings);
    }

    /// <summary>
    ///     Connect the local project to another one using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Link")]
    public static void PnpmLink(this ICakeContext context, PnpmLinkSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmInstall = new PnpmLink(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmInstall.Link(settings);
    }
}
