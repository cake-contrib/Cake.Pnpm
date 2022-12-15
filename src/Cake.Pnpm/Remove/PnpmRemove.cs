using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Remove;

/// <summary>
///     Removes packages from `node_modules` and from the project's `package.json`.
///     Visit https://pnpm.io/7.x/cli/remove for documentation about this command.
/// </summary>
public class PnpmRemove : PnpmTool<PnpmRemoveSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmRemove" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmRemove(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Removes packages from `node_modules` and from the project's `package.json`.
    ///     Visit https://pnpm.io/7.x/cli/remove for documentation about this command.
    /// </summary>
    /// <param name="settings">The settings.</param>
    public void Remove(PnpmRemoveSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        if (settings.PackageName == null) throw new ArgumentNullException(nameof(settings.PackageName));

        RunCore(settings);
    }
}
