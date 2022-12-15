using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm;
using Cake.Pnpm.Exec;

namespace Cake.Pnpm;

/// <summary>
///     `pnpm exec` aliases
/// </summary>
[CakeAliasCategory("Pnpm")]
[CakeNamespaceImport("Cake.Pnpm.Exec")]
public static class PnpmExecAliases
{
    /// <summary>
    ///     Run a shell command in the context of a project
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="command">Command to run</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Exec")]
    public static void PnpmExec(this ICakeContext context, string command)
    {
        context.PnpmExec(command, new PnpmExecSettings());
    }

    /// <summary>
    ///     Run a shell command in the context of a project using the specified settings
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="command">Command to run</param>
    /// <param name="settings">The settings</param>
    [CakeMethodAlias]
    [CakeAliasCategory("Exec")]
    public static void PnpmExec(this ICakeContext context, string command, PnpmExecSettings settings)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));

        if (settings == null) throw new ArgumentNullException(nameof(settings));

        settings.Command = command;

        AddinInformation.LogVersionInformation(context.Log);
        var pnpmInstall = new PnpmExec(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        pnpmInstall.Exec(settings);
    }
}
