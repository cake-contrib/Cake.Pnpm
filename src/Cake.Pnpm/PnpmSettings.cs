namespace Cake.Pnpm
{
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// Pnpm settings.
    /// </summary>
    public abstract class PnpmSettings : ToolSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmSettings"/> class.
        /// </summary>
        /// <param name="command">command to run.</param>
        protected PnpmSettings(string command)
        {
            this.Command = command;
        }

        /// <summary>
        /// Gets the command which should run.
        /// </summary>
        protected string Command { get; private set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(this.Command);
            this.EvaluateCore(args);
        }

        /// <summary>
        /// Evaluate the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
        }
    }
}
