namespace Cake.Pnpm.Commands.Update
{
    using System;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;
    using Cake.Pnpm;

    /// <summary>
    /// Tool for installing all npm packages for a project from package-lock.json.
    /// </summary>
    public class PnpmUpdate : PnpmRunner<PnpmUpdateSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmUpdate"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public PnpmUpdate(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Updates all npm packages.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Update(PnpmUpdateSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.RunCore(settings);
        }
    }
}
