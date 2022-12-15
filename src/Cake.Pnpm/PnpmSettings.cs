using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Pnpm;

/// <summary>
///     Pnpm tool settings.
/// </summary>
public abstract class PnpmSettings : ToolSettings
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PnpmSettings" /> class.
    /// </summary>
    /// <param name="command"></param>
    protected PnpmSettings(string command)
    {
        Command = command;
        RedirectStandardError = false;
        RedirectStandardOutput = false;
    }

    /// <summary>
    ///     Gets the command which should be run.
    /// </summary>
    private string Command { get; }

    /// <summary>
    ///     What level of logs to report. Any logs at or higher than the given level will be shown. Levels (lowest to highest):
    ///     debug, info, warn, error.
    /// </summary>
    public PnpmLogLevel PnpmLogLevel { get; set; }

    /// <summary>
    ///     Gets or sets the process option to redirect standard error output.
    /// </summary>
    /// <remarks>
    ///     To retrieve and process the standard error output
    ///     <see cref="StandardErrorAction" /> needs to be set.
    /// </remarks>
    public bool RedirectStandardError { get; set; }

    /// <summary>
    ///     Gets or sets an action to retrieve and process standard error output.
    /// </summary>
    /// <remarks>
    ///     Setting a standard error action implicitely set <see cref="RedirectStandardError" />.
    /// </remarks>
    public Action<string> StandardErrorAction { get; set; }

    /// <summary>
    ///     Gets or sets the process option to redirect standard output.
    /// </summary>
    /// <remarks>
    ///     To retrieve and process the standard error output
    ///     <see cref="StandardOutputAction" /> needs to be set.
    /// </remarks>
    public bool RedirectStandardOutput { get; set; }

    /// <summary>
    ///     Gets or sets an action to retrieve and process standard output.
    /// </summary>
    /// <remarks>
    ///     Setting a standard error action implicitely set <see cref="RedirectStandardOutput" />.
    /// </remarks>
    public Action<string> StandardOutputAction { get; set; }

    /// <summary>
    ///     Gets or sets the Log level set by Cake.
    /// </summary>
    public Verbosity? CakeVerbosityLevel { get; set; }

    /// <summary>
    ///     Evaluates the settings and writes them to <paramref name="args" />.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    internal void Evaluate(ProcessArgumentBuilder args)
    {
        args.Append(Command);
        EvaluateCore(args);
        AppendLogLevel(args, PnpmLogLevel);
    }

    /// <summary>
    ///     Evaluates the settings and writes them to <paramref name="args" />.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    protected virtual void EvaluateCore(ProcessArgumentBuilder args)
    {
    }

    private void AppendLogLevel(ProcessArgumentBuilder args, PnpmLogLevel logLevel)
    {
        if (logLevel == PnpmLogLevel.Default && CakeVerbosityLevel.HasValue)
            logLevel = CakeToPnpmLogLevelConverter(CakeVerbosityLevel.Value);

        switch (logLevel)
        {
            case PnpmLogLevel.Silent:
                args.Append("--silent");
                break;
            case PnpmLogLevel.Warn:
                args.Append("--loglevel warn");
                break;
            case PnpmLogLevel.Info:
                args.Append("--loglevel info");
                break;
            case PnpmLogLevel.Debug:
                args.Append("--loglevel debug");
                break;
            case PnpmLogLevel.Error:
                args.Append("--loglevel error");
                break;
            case PnpmLogLevel.Default:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
        }
    }

    private static PnpmLogLevel CakeToPnpmLogLevelConverter(Verbosity cakeVerbosityLevel)
    {
        return cakeVerbosityLevel switch
        {
            Verbosity.Quiet => PnpmLogLevel.Silent,
            Verbosity.Minimal => PnpmLogLevel.Warn,
            Verbosity.Verbose => PnpmLogLevel.Info,
            Verbosity.Diagnostic => PnpmLogLevel.Debug,
            _ => PnpmLogLevel.Default
        };
    }
}
