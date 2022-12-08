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
    ///     Install package
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packageName">Package name to install</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     context.PnpmAdd("foo@bar");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Add")]
    public static void PnpmAdd(this ICakeContext context, string packageName)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (string.IsNullOrEmpty(packageName)) throw new ArgumentNullException(nameof(packageName));

        context.PnpmAdd(new PnpmAddSettings {PackageName = packageName});
    }

    /// <summary>
    ///     Install package using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="packageName">Package name to install</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Add")]
    public static void PnpmAdd(this ICakeContext context, string packageName, Action<PnpmAddSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (string.IsNullOrEmpty(packageName)) throw new ArgumentNullException(nameof(packageName));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmAddSettings {PackageName = packageName};
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

        if (string.IsNullOrEmpty(settings.PackageName)) throw new ArgumentNullException(nameof(settings.PackageName), $"{nameof(settings.PackageName)} settings property is required");

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmAdd = new PnpmAdd(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmAdd.Add(settings);
    }
}

