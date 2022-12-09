using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Add;
using Cake.Pnpm.Update;

namespace Cake.Pnpm;

/// <summary>
///     Pnpm Install aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Update")]
public static class PnpmUpdateAliases
{
    /// <summary>
    ///     Updates packages to their latest version
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packages">Package names to update</param>
    /// <example>
    /// <para>Call for all packages</para>
    /// <code>
    /// <![CDATA[
    ///     context.PnpmUpdate();
    /// ]]>
    /// </code>
    /// <para>Call for specific packages</para>
    /// <code>
    /// <![CDATA[
    ///     context.PnpmUpdate("foo@bar", "baz@v1.0.0");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Update")]
    public static void PnpmUpdate(this ICakeContext context, params string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        var settings = new PnpmUpdateSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        context.PnpmUpdate(settings);
    }

    /// <summary>
    ///     Updates packages using the settings returned by a configurator
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <param name="packages">Package names to update</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Update")]
    public static void PnpmUpdate(this ICakeContext context, Action<PnpmUpdateSettings> configurator, params string[] packages)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmUpdateSettings();
        foreach (var package in packages)
        {
            settings.Packages.Add(package);
        }
        configurator(settings);
        context.PnpmUpdate(settings);
    }

    /// <summary>
    ///     Updates packages using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Update")]
    public static void PnpmUpdate(this ICakeContext context, PnpmUpdateSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmUpdate = new PnpmUpdate(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmUpdate.Update(settings);
    }
}

