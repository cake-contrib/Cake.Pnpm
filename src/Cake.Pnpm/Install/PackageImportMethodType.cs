namespace Cake.Pnpm.Install;

/// <summary>
/// Define the packages copy method. By default depends on filesystem
/// </summary>
public enum PackageImportMethodType
{
    /// <summary>
    ///     Clones/hardlinks or copies packages. The selected method depends from the file system
    /// </summary>
    Auto,

    /// <summary>
    ///     Clone (aka copy-on-write) packages from the store
    /// </summary>
    Clone,

    /// <summary>
    ///     Copy packages from the store
    /// </summary>
    Copy,

    /// <summary>
    ///     Hardlink packages from the store
    /// </summary>
    Hardlink
}
