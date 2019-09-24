namespace Cake.Pnpm
{
    using System;
    using System.Collections.Generic;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    public sealed class PnpmRunner : Tool<PnpmSettings>
    {
        public PnpmRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(PnpmSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.Run(settings, GetArguments(settings));
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "Pnpm.exe";
            yield return "Pnpm";
        }

        protected override string GetToolName()
        {
            return "Pnpm";
        }

        private static ProcessArgumentBuilder GetArguments(PnpmSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // TODO: Add the necessary arguments based on the settings class

            return builder;
        }
    }
}
