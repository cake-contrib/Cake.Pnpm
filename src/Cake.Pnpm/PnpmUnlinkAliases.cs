using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Link;
using Cake.Pnpm.Unlink;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm link` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Unlink")]
public static class PnpmUnlinkAliases
{
    /// <summary>
    ///     Removes the link created by `pnpm link` and reinstalls package if it is saved in `package.json`
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="path">Path to what to link</param>
    /// <example>
    /// <para>From the pnpm documentation</para>
    /// <code>
    /// <![CDATA[
    ///     pnpm unlink (in package dir)
    ///     pnpm unlink <pkg>...
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Unlink")]
    public static void PnpmUnlink(this ICakeContext context, string path)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.PnpmUnlink(new PnpmUnlinkSettings {Path = path});
    }

    /// <summary>
    ///     Removes the link created by `pnpm link` and reinstalls package if it is saved in `package.json`
    ///     using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <param name="path">Path to what to link</param>
    /// <example>
    /// <para>From the pnpm documentation</para>
    /// <code>
    /// <![CDATA[
    ///     pnpm unlink (in package dir)
    ///     pnpm unlink <pkg>...
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Unlink")]
    public static void PnpmUnlink(this ICakeContext context, string path, Action<PnpmUnlinkSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmUnlinkSettings {Path = path};
        configurator(settings);
        context.PnpmUnlink(settings);
    }

    /// <summary>
    ///     Removes the link created by `pnpm link` and reinstalls package if it is saved in `package.json`
    ///     using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    /// <example>
    /// <para>From the pnpm documentation</para>
    /// <code>
    /// <![CDATA[
    ///     pnpm unlink (in package dir)
    ///     pnpm unlink <pkg>...
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Unlink")]
    public static void PnpmUnlink(this ICakeContext context, PnpmUnlinkSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        if (string.IsNullOrEmpty(settings.Path)) throw new ArgumentNullException(nameof(settings.Path));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmUnlink = new PnpmUnlink(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmUnlink.Unlink(settings);
    }
}
