namespace Cake.Pnpm.Commands.Add
{
    using System;
    using System.Collections.Generic;
    using Cake.Core;
    using Cake.Core.IO;

    /// <summary>
    /// Contains settings used by <see cref="PnpmAdd"/>.
    /// </summary>
    public class PnpmAddSettings : PnpmSettings
    {
        private readonly ISet<string> packages = new HashSet<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PnpmAddSettings"/> class.
        /// </summary>
        public PnpmAddSettings()
            : base("add")
        {
        }

        /// <summary>
        /// Gets list of packages to install.
        /// </summary>
        public IEnumerable<string> Packages { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether 'global' option.
        /// </summary>
        public bool Global { get; internal set; }

        /// <summary>
        /// Install a package from the given url
        /// </summary>
        /// <param name="url">Url to directory containing package.json (see pnpm docs).</param>
        /// <returns>Instance of <see cref="PnpmAddSettings"/> class.</returns>
        public PnpmAddSettings Package(Uri url)
        {
            if (!url.IsAbsoluteUri)
            {
                throw new UriFormatException("You must provide an absolute url to a package");
            }

            this.packages.Clear();
            this.packages.Add(url.AbsoluteUri);
            return this;
        }

        /// <summary>
        /// install a package by name, with optional version/tag and scope
        /// </summary>
        /// <param name="package">Package name.</param>
        /// <param name="versionOrTag">Package version or tag.</param>
        /// <param name="scope">Package scope.</param>
        /// <returns>Instance of <see cref="PnpmAddSettings"/> class.</returns>
        public PnpmAddSettings Package(string package, string versionOrTag = null, string scope = null)
        {
            var packageName = package;
            if (!string.IsNullOrWhiteSpace(versionOrTag))
            {
                var versionOrTagValue = versionOrTag;
                if (versionOrTagValue.Contains(" "))
                {
                    versionOrTagValue = versionOrTag.Quote();
                }

                packageName = $"{package}@{versionOrTagValue}";
            }

            if (!string.IsNullOrWhiteSpace(scope))
            {
                if (!scope.StartsWith("@"))
                {
                    throw new ArgumentException("The scope should start with @");
                }

                packageName = !string.IsNullOrWhiteSpace(scope) ? $"{scope}/{packageName}" : packageName;
            }

            this.packages.Add(packageName);
            return this;
        }

        /// <summary>
        /// Applies the --global parameter.
        /// </summary>
        /// <param name="enabled"><c>true</c> to apply the parameter.</param>
        /// <returns>Instance of <see cref="PnpmAddSettings"/> class.</returns>
        public PnpmAddSettings Globally(bool enabled = true)
        {
            this.Global = enabled;
            return this;
        }

        /// <summary>
        /// Evaluate options.
        /// </summary>
        /// <param name="args">List of packages.</param>
        protected override void EvaluateCore(ProcessArgumentBuilder args)
        {
            foreach (var package in this.Packages)
            {
                args.Append(package);
            }
        }
    }
}
