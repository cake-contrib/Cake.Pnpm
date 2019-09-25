namespace Cake.Npm
{
    using System;
    using Cake.Core;
    using Cake.Core.Annotations;
    using Cake.Pnpm.Commands.Install;

    /// <summary>
    /// Npm Install aliases.
    /// </summary>
    [CakeAliasCategory("Pnpm")]
    [CakeNamespaceImport("Cake.Pnpm.Commands.Install")]
    public static class PnpmInstallAliases
    {
        /// <summary>
        /// Installs packages for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     PnpmInstall();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void PnpmInstall(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.PnpmInstall(new PnpmInstallSettings());
        }

        /// <summary>
        /// Installs packages using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void PnnpmInstall(this ICakeContext context, Action<PnpmInstallSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new PnpmInstallSettings();
            configurator(settings);
            context.PnpmInstall(settings);
        }

        /// <summary>
        /// Installs packages using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void PnpmInstall(this ICakeContext context, PnpmInstallSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var installer = new PnpmInstall(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
            installer.Install(settings);
        }
    }
}
