using Serilog;

namespace TD.CitizenAPI.Infrastructure.Common.Extensions;

public static class SerilogExtensions
{
    public static void Refresh(this ILogger? logger)
    {
        if (logger is { } and not Serilog.Core.Logger) Log.Logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console().CreateLogger();
    }
}