using Cake.Pnpm.Add;

namespace Cake.Pnpm.Import;

/// <summary>
///     Contains settings used by <see cref="PnpmImport" />.
/// </summary>
public class PnpmImportSettings : PnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmAddSettings" /> class.
    /// </summary>
    public PnpmImportSettings() : base("import")
    {
    }
}
