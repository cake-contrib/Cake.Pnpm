using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Store;

/// <summary>
///     Reads and performs actions on pnpm store that is on the current filesystem.
///     Visit https://pnpm.io/7.x/cli/store for documentation about this command.
/// </summary>
public class PnpmStore : PnpmTool<PnpmStoreSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmStore" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmStore(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Reads and performs actions on pnpm store that is on the current filesystem.
    ///     Visit https://pnpm.io/7.x/cli/store for documentation about this command.
    /// </summary>
    public void RunCommand(PnpmStoreSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
