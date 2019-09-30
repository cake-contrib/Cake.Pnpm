namespace Cake.Pnpm.Commands.Add
{
    using System;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;
    using Cake.Pnpm;

    /// <summary>
    /// Tool for adding npm packages.
    /// </summary>
    public class PnpmAdd : PnpmRunner<PnpmAddSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmAdd"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public PnpmAdd(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
        : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Adds a npm package from the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Install(PnpmAddSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.RunCore(settings);
        }
    }
}
