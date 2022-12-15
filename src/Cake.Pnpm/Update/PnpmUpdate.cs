using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Update;

/// <summary>
///     Updates packages to their latest version based on the specified range.
///     You can use "*" in package name to update all packages with the same pattern.
/// </summary>
public class PnpmUpdate : PnpmTool<PnpmUpdateSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmUpdate" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmUpdate(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Updates packages to their latest version based on the specified range.
    ///     You can use "*" in package name to update all packages with the same pattern.
    /// </summary>
    /// <param name="settings">The settings.</param>
    public void Update(PnpmUpdateSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
