namespace Cake.Pnpm.Commands.Link
{
    using System;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;
    using Cake.Pnpm;

    /// <summary>
    /// Link webpack from a local directory.
    /// </summary>
    public class PnpmLink : PnpmRunner<PnpmLinkSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmLink"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public PnpmLink(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
        : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Link webpack from a local directory.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Install(PnpmLinkSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.RunCore(settings);
        }
    }
}
