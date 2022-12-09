using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Prune;

/// <summary>
///     Removes extraneous packages
///     Visit https://pnpm.io/7.x/cli/prune for documentation about this command.
/// </summary>
public class PnpmPrune : PnpmTool<PnpmPruneSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmPrune" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmPrune(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Removes extraneous packages
    ///     Visit https://pnpm.io/7.x/cli/prune for documentation about this command.
    /// </summary>
    public void Prune(PnpmPruneSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
