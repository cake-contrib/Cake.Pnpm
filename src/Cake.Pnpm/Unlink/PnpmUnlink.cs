using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Unlink;

/// <summary>
///     Removes the link created by `pnpm link` and reinstalls package if it is saved in `package.json`
///     Visit https://pnpm.io/7.x/cli/unlink for documentation about this command.
/// </summary>
public class PnpmUnlink : PnpmTool<PnpmUnlinkSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmUnlink" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmUnlink(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Removes the link created by `pnpm link` and reinstalls package if it is saved in `package.json`
    ///     Visit https://pnpm.io/7.x/cli/unlink for documentation about this command.
    /// </summary>
    public void Unlink(PnpmUnlinkSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
