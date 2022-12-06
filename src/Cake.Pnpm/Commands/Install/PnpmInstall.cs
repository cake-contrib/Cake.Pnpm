namespace Cake.Pnpm.Commands.Install
{
    using System;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;
    using Cake.Pnpm;

    /// <summary>
    /// Tool for installing npm packages.
    /// </summary>
    public class PnpmInstall : PnpmRunner<PnpmInstallSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmInstall"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public PnpmInstall(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
        : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Installs a npm package from the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Install(PnpmInstallSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.RunCore(settings);
        }
    }
}