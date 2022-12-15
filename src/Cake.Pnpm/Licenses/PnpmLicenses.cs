using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Licenses;

/// <summary>
///     Check the licenses of the installed packages.
///     Visit https://pnpm.io/7.x/cli/licenses for documentation about this command.
/// </summary>
public class PnpmLicenses : PnpmTool<PnpmLicensesSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmLicenses" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmLicenses(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Check the licenses of the installed packages.
    ///     Visit https://pnpm.io/7.x/cli/licenses for documentation about this command.
    /// </summary>
    public void List(PnpmLicensesSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
