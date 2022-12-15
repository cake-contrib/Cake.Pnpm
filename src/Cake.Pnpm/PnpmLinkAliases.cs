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
    /// <param name="path">Path to what to link</param>
    /// <example>
    /// <para>From the pnpm documentation</para>
    /// <code>
    /// <![CDATA[
    ///     pnpm link <dir>
    ///     pnpm link --global (in package dir)
    ///     pnpm link --global <pkg>
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Link")]
    public static void PnpmLink(this ICakeContext context, string path)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        context.PnpmLink(new PnpmLinkSettings {Path = path});
    }

    /// <summary>
    ///     Connect the local project to another one using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <param name="path">Path to what to link</param>
    /// <example>
    /// <para>From the pnpm documentation</para>
    /// <code>
    /// <![CDATA[
    ///     pnpm link <dir>
    ///     pnpm link --global (in package dir)
    ///     pnpm link --global <pkg>
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Link")]
    public static void PnpmLink(this ICakeContext context, string path, Action<PnpmLinkSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmLinkSettings {Path = path};
        configurator(settings);
        context.PnpmLink(settings);
    }

    /// <summary>
    ///     Connect the local project to another one using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    /// <example>
    /// <para>From the pnpm documentation</para>
    /// <code>
    /// <![CDATA[
    ///     pnpm link <dir>
    ///     pnpm link --global (in package dir)
    ///     pnpm link --global <pkg>
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Link")]
    public static void PnpmLink(this ICakeContext context, PnpmLinkSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        if (string.IsNullOrEmpty(settings.Path)) throw new ArgumentNullException(nameof(settings.Path));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmLink = new PnpmLink(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmLink.Link(settings);
    }
}
