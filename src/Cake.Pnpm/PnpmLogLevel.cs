namespace Cake.Pnpm;

/// <summary>
///     Details the pnpm log levels
/// </summary>
public enum PnpmLogLevel
{
    /// <summary>
    ///     Uses log level as defined by the running Cake script.
    /// </summary>
    Default,

    /// <summary>
    ///     -s, --silent
    /// </summary>
    Silent,

    /// <summary>
    ///     --loglevel warn
    /// </summary>
    Warn,

    /// <summary>
    ///     --loglevel info
    /// </summary>
    Info,

    /// <summary>
    ///     --loglevel error
    /// </summary>
    Error,

    /// <summary>
    ///     --loglevel debug
    /// </summary>
    Debug
}
