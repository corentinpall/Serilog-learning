﻿using Serilog;
using Serilog.Events;
using System.Configuration;

namespace Logging.Core;

public static class Logger
{
    private static readonly ILogger _perfLogger;
    private static readonly ILogger _usageLogger;
    private static readonly ILogger _errorLogger;
    private static readonly ILogger _diagnosticLogger;

    static Logger()
    {
        _perfLogger = new LoggerConfiguration()
            .WriteTo.File(path: "../logs/performance.txt").CreateLogger();
        
        _usageLogger = new LoggerConfiguration()
            .WriteTo.File(path: "../logs/usage.txt").CreateLogger();
        
        _errorLogger = new LoggerConfiguration()
            .WriteTo.File(path: "../logs/error.txt").CreateLogger();
        
        _diagnosticLogger = new LoggerConfiguration()
            .WriteTo.File(path: "../logs/diagnostic.txt").CreateLogger();
    }

    public static void WritePerf(LogDetail infoToLog)
        => _perfLogger.Write(LogEventLevel.Information, "@{LogDetail}", infoToLog);

    public static void WriteUsage(LogDetail infoToLog)
        => _usageLogger.Write(LogEventLevel.Information, "@{LogDetail}", infoToLog);

    public static void WriteError(LogDetail infoToLog)
        => _errorLogger.Write(LogEventLevel.Information, @"{LogDetail}", infoToLog);

    public static void WriteDiagnostic(LogDetail infoToLog)
    {
        var writeDiagnostics = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);
        if (!writeDiagnostics) return;
        
        _diagnosticLogger.Write(LogEventLevel.Information, @"{LogDetail}", infoToLog);
    }
}