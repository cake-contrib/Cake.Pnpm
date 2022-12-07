using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Add;

/// <summary>
/// Installs a package and any packages that it depends on.
/// </summary>
public class PnpmAdd : PnpmTool<PnpmAddSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmAdd" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmAdd(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Installs a package and any packages that it depends on.
    /// </summary>
    /// <param name="settings">The settings.</param>
    public void Add(PnpmAddSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}

