namespace Cake.Pnpm.Commands.Install
{
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="PnpmInstall"/>.
    /// </summary>
    public class PnpmInstallSettings : PnpmSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmInstallSettings"/> class.
        /// </summary>
        public PnpmInstallSettings()
            : base("install")
        {
        }

        /// <summary>
        /// Gets a value indicating whether flag --offline.
        /// </summary>
        public bool OfflineInstall { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether flag --prefer-offline.
        /// </summary>
        public bool PreferOfflineInstall { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether flag --ignore-scripts.
        /// </summary>
        public bool IgnoreScriptsInstall { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether flag --production.
        /// </summary>
        public bool Production { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether flag --lockfile-only.
        /// </summary>
        public bool LockfileOnlyInstall { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether flag  --frozen-lockfile.
        /// </summary>
        public bool FrozenLockfile { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether flag --use-store-server.
        /// </summary>
        public bool UseStoreServerInstall { get; internal set; }

        /// <summary>
        /// Applies the --offline parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmInstallSettings"/> class.</returns>
        public PnpmInstallSettings Offline(bool enabled = true)
        {
            this.OfflineInstall = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --prefer-offline parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmInstallSettings"/> class.</returns>
        public PnpmInstallSettings PreferOffline(bool enabled = true)
        {
            this.PreferOfflineInstall = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --ignore-scripts parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmInstallSettings"/> class.</returns>
        public PnpmInstallSettings IgnoreScripts(bool enabled = true)
        {
            this.IgnoreScriptsInstall = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --production parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmInstallSettings"/> class.</returns>
        public PnpmInstallSettings SetProduction(bool enabled = true)
        {
            this.Production = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --lockfile-only parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmInstallSettings"/> class.</returns>
        public PnpmInstallSettings LockFileOnly(bool enabled = true)
        {
            this.LockfileOnlyInstall = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --frozen-lockfile parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmInstallSettings"/> class.</returns>
        public PnpmInstallSettings WithFrozenLockFile(bool enabled = true)
        {
            this.FrozenLockfile = enabled;
            return this;
        }

        /// <summary>
        /// Applies the --use-store-server parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmInstallSettings"/> class.</returns>
        public PnpmInstallSettings UseStoreServer(bool enabled = true)
        {
            this.UseStoreServerInstall = enabled;
            return this;
        }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            base.EvaluateCore(args);

            if (this.OfflineInstall)
            {
                args.Append("--offline");
            }

            if (this.PreferOfflineInstall)
            {
                args.Append("--prefer-offline");
            }

            if (this.IgnoreScriptsInstall)
            {
                args.Append("--ignore-scripts");
            }

            if (this.LockfileOnlyInstall)
            {
                args.Append("--lockfile-only");
            }

            if (this.FrozenLockfile)
            {
                args.Append("--frozen-lockfile");
            }

            if (this.UseStoreServerInstall)
            {
                args.Append("--use-store-server");
            }

            args.Append($"--production={this.Production.ToString().ToLower()}");
        }
    }
}
