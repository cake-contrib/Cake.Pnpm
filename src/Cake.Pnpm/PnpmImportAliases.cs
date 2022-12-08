using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Import;

namespace Cake.Pnpm;

/// <summary>
///     Pnpm Import aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Import")]
public static class PnpmImportAliases
{
    /// <summary>
    ///     Generates pnpm-lock.yaml from an npm package-lock.json (or npm-shrinkwrap.json, yarn.lock) file.
    ///     Visit https://pnpm.io/7.x/cli/import for documentation about this command.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Import")]
    public static void PnpmImport(this ICakeContext context, Action<PnpmImportSettings> configurator)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (configurator == null) throw new ArgumentNullException(nameof(configurator));

        var settings = new PnpmImportSettings();
        configurator(settings);
        context.PnpmImport(settings);
    }

    /// <summary>
    ///     Generates pnpm-lock.yaml from an npm package-lock.json (or npm-shrinkwrap.json, yarn.lock) file.
    ///     Visit https://pnpm.io/7.x/cli/import for documentation about this command.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Import")]
    public static void PnpmImport(this ICakeContext context, PnpmImportSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));


        AddinInformation.LogVersionInformation(context.Log);
        var pnpmImport = new PnpmImport(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmImport.Import(settings);
    }
}
