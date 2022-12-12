using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.List;

/// <summary>
///     When run as ll or la, it shows extended information by default. All dependencies are printed by default.
///     Search by patterns is supported. For example: pnpm ls babel-* eslint-*
///     Visit https://pnpm.io/7.x/cli/list for documentation about this command.
/// </summary>
public class PnpmList : PnpmTool<PnpmListSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmList" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmList(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Check the licenses of the installed packages.
    ///     Visit https://pnpm.io/7.x/cli/licenses for documentation about this command.
    /// </summary>
    public void List(PnpmListSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
