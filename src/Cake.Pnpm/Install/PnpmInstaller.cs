using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Install;

/// <summary>
///     Installs all dependencies of the project in the current working directory. When executed inside a workspace,
///     installs all dependencies of all projects.
/// </summary>
public class PnpmInstaller : PnpmTool<PnpmInstallSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmInstaller" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmInstaller(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Installs all dependencies of the project in the current working directory. When executed inside a workspace,
    ///     installs all dependencies of all projects.
    /// </summary>
    /// <param name="settings">The settings.</param>
    public void Install(PnpmInstallSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
