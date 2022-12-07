namespace Cake.Pnpm.Add;

/// <summary>
///     Contains settings used by <see cref="PnpmAdd" />.
/// </summary>
public class PnpmAddSettings : SharedPnpmSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmAddSettings" /> class.
    /// </summary>
    public PnpmAddSettings() : base("add")
    {

    }

    /// <summary>
    /// Install exact version
    /// </summary>
    public bool? NoSaveExact { get; set; }

    /// <summary>
    /// Save packages from the workspace with a "workspace:" protocol. True by default
    /// </summary>
    public bool? SaveWorkspaceProtocol { get; set; }

}


