using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Outdated;

/// <summary>
///     Check for outdated packages. The check can be limited to a subset of the
///     installed packages by providing arguments (patterns are supported).
///     Visit https://pnpm.io/7.x/cli/outdated for documentation about this command.
/// </summary>
public class PnpmOutdated : PnpmTool<PnpmOutdatedSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmOutdated" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmOutdated(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Check for outdated packages. The check can be limited to a subset of the
    ///     installed packages by providing arguments (patterns are supported).
    ///     Visit https://pnpm.io/7.x/cli/outdated for documentation about this command.
    /// </summary>
    public void Outdated(PnpmOutdatedSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
