namespace Cake.Pnpm.Commands.Update
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="PnpmUpdate"/>.
    /// </summary>
    public class PnpmUpdateSettings : PnpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmUpdateSettings"/> class.
        /// </summary>
        public PnpmUpdateSettings()
            : base("update")
        {
        }

        /// <summary>
        /// Gets a value indicating whether to update globally installed packages.
        /// </summary>
        public bool Global { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether to run command in all subdirectories.
        /// </summary>
        public bool Recursive { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether to use latest packages.
        /// </summary>
        public bool Latest { get; internal set; }

        /// <inheritdoc />
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            if (this.Global)
            {
                args.Append("--global");
            }

            if (this.Recursive)
            {
                args.Append("--recursive");
            }

            if (this.Latest)
            {
                args.Append("--latest");
            }
        }
    }
}
