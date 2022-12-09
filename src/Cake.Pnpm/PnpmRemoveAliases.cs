using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Add;
using Cake.Pnpm.Remove;

namespace Cake.Pnpm;

/// <summary>
///     Pnpm Remove aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Remove")]
public static class PnpmRemoveAliases
{
    /// <summary>
    ///     Remove package
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packageName">Package name to remove</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     context.PnpmRemove("foo@bar");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Remove")]
    public static void PnpmRemove(this ICakeContext context, string packageName)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (string.IsNullOrEmpty(packageName)) throw new ArgumentNullException(nameof(packageName));

        context.PnpmRemove(new PnpmRemoveSettings() {PackageName = packageName});
    }

    /// <summary>
    ///     Remove package using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packageName">Package name to remove</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Remove")]
    public static void PnpmRemove(this ICakeContext context, string packageName, Action<PnpmRemoveSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (string.IsNullOrEmpty(packageName)) throw new ArgumentNullException(nameof(packageName));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmRemoveSettings() {PackageName = packageName};
        configurator(settings);
        context.PnpmRemove(settings);
    }

    /// <summary>
    ///     Remove package using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Remove")]
    public static void PnpmRemove(this ICakeContext context, PnpmRemoveSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        if (string.IsNullOrEmpty(settings.PackageName)) throw new ArgumentNullException(nameof(settings.PackageName), $"{nameof(settings.PackageName)} settings property is required");

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmRemove = new PnpmRemove(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmRemove.Remove(settings);
    }
}

