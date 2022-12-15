using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Rebuild;

/// <summary>
///     Rebuild a package.
///     Visit https://pnpm.io/7.x/cli/rebuild for documentation about this command.
/// </summary>
public class PnpmRebuild : PnpmTool<PnpmRebuildSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmRebuild" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmRebuild(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Rebuild a package.
    ///     Visit https://pnpm.io/7.x/cli/rebuild for documentation about this command.
    /// </summary>
    public void Rebuild(PnpmRebuildSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
