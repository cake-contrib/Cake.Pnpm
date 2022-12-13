using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Run;

/// <summary>
///     Runs a defined package script.
///     Visit https://pnpm.io/7.x/cli/run for documentation about this command.
/// </summary>
public class PnpmRun : PnpmTool<PnpmRunSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmRun" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmRun(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Runs a defined package script.
    ///     Visit https://pnpm.io/7.x/cli/run for documentation about this command.
    /// </summary>
    public void Exec(PnpmRunSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
