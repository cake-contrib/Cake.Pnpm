using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Pnpm.Add;

namespace Cake.Pnpm.Import;

/// <summary>
///     Generates pnpm-lock.yaml from an npm package-lock.json (or npm-shrinkwrap.json, yarn.lock) file.
///     Visit https://pnpm.io/7.x/cli/import for documentation about this command.
/// </summary>
public class PnpmImport : PnpmTool<PnpmImportSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmImport" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmImport(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Generates pnpm-lock.yaml from an npm package-lock.json (or npm-shrinkwrap.json, yarn.lock) file.
    ///     Visit https://pnpm.io/7.x/cli/import for documentation about this command.
    /// </summary>
    /// <param name="settings">The settings.</param>
    public void Import(PnpmImportSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}

