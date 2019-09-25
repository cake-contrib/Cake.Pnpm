namespace Cake.Pnpm
{
    using System;
    using System.Collections.Generic;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// Base class for all pnpm tools.
    /// </summary>
    /// <typeparam name="TSettings">The settings type.</typeparam>
    public abstract class PnpmRunner<TSettings> : Tool<TSettings>
         where TSettings : PnpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmRunner{TSettings}"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        public PnpmRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        /// <summary>
        /// Runs pnpm.
        /// </summary>
        /// <param name="settings">The settings for pnpm.</param>
        public void RunCore(TSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.Run(settings, GetArguments(settings));
        }

        /// <summary>
        /// Gets the possible names of the tool executable.
        /// </summary>
        /// <returns>The tool executable name.</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "pnpm.cmd";
            yield return "pnpm";
        }

        /// <summary>
        /// Gets the name of the tool.
        /// </summary>
        /// <returns>The name of the tool.</returns>
        protected override string GetToolName()
        {
            return "pnpm";
        }

        /// <summary>
        /// Builds the arguments for pnpm.
        /// </summary>
        /// <param name="settings">Settings used for building the arguments.</param>
        /// <returns>Argument builder containing the arguments based on <paramref name="settings"/>.</returns>
        private static ProcessArgumentBuilder GetArguments(TSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args);

            return args;
        }
    }
}
