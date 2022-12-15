using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Exec;

/// <summary>
///     Run a shell command in the context of a project.
///     Visit https://pnpm.io/7.x/cli/exec for documentation about this command.
/// </summary>
public class PnpmExec : PnpmTool<PnpmExecSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmExec" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmExec(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Run a shell command in the context of a project.
    ///     Visit https://pnpm.io/7.x/cli/exec for documentation about this command.
    /// </summary>
    public void Exec(PnpmExecSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
