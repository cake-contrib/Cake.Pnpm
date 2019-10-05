namespace Cake.Pnpm.Commands.Link
{
    using Cake.Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="PnpmLink"/>.
    /// </summary>
    public class PnpmLinkSettings : PnpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmLinkSettings"/> class.
        /// </summary>
        public PnpmLinkSettings()
            : base("link")
        {
        }

        /// <summary>
        /// Evaluate options.
        /// </summary>
        /// <param name="args">List of arguments.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);
        }
    }
}
