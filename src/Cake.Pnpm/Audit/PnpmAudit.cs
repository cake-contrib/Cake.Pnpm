using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm.Audit;

/// <summary>
///     Checks for known security issues with the installed packages.
///     Visit https://pnpm.io/7.x/cli/audit for documentation about this command.
/// </summary>
public class PnpmAudit : PnpmTool<PnpmAuditSettings>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmAudit" /> class.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public PnpmAudit(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
        IToolLocator tools, ICakeLog log) : base(fileSystem, environment, processRunner, tools, log)
    {
    }

    /// <summary>
    ///     Checks for known security issues with the installed packages.
    ///     Visit https://pnpm.io/7.x/cli/audit for documentation about this command.
    /// </summary>
    public void Audit(PnpmAuditSettings settings)
    {
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        RunCore(settings);
    }
}
