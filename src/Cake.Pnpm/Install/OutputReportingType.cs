namespace Cake.Pnpm.Install;

/// <summary>
///     Details the pnpm report output type
/// </summary>
public enum OutputReportingType
{
    /// <summary>
    ///     The default reporter when the stdout is TTY
    /// </summary>
    Default,

    /// <summary>
    ///     The output is always appended to the end. No cursor manipulations are performed
    /// </summary>
    AppendOnly,

    /// <summary>
    ///     The most verbose reporter. Prints all logs in ndjson format
    /// </summary>
    Ndjson
}
