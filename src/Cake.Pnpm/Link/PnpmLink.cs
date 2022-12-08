using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Link;

/// <summary>
///     Connect the local project to another one
///     Visit https://pnpm.io/7.x/cli/link for documentation about this command.
/// </summary>
public class PnpmLink : PnpmTool<PnpmLinkSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmLink" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmLink(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Connect the local project to another one
    ///     Visit https://pnpm.io/7.x/cli/link for documentation about this command.
    /// </summary>
    public void Link(PnpmLinkSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
