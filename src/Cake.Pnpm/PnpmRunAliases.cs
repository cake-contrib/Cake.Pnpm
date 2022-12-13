using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Run;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm run` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Run")]
public static class PnpmRunAliases
{
    /// <summary>
    ///     Runs a defined package script.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="command">Command to run</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Run")]
    public static void PnpmRun(this ICakeContext context, string command)
    {
        context.PnpmRun(command, new PnpmRunSettings());
    }

    /// <summary>
    ///     Runs a defined package script using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="command">Command to run</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Run")]
    public static void PnpmRun(this ICakeContext context, string command, PnpmRunSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        if (string.IsNullOrEmpty(command)) throw new ArgumentNullException(nameof(command));

        settings.Command = command;

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmRun = new PnpmRun(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmRun.Run(settings);
    }
}
