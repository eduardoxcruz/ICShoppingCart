using Serilog;
using SerilogUtils;

namespace ShoppingCart.Model;

public static class Logger
{
	public static ILogger CreateLogger<T>() where T : new()
	{
		string consoleOutputTemplate = 
			"[{Timestamp:dd/mm/yyyy HH:mm:ss} {Level:u4} {SourceContext}.{MemberName}:{LineNumber}] {Message:lj}{NewLine}{Exception}";

		return new LoggerConfiguration()
			.MinimumLevel.Verbose()
			.Enrich.FromLogContext()
			.WriteTo.Console(outputTemplate: consoleOutputTemplate)
			.WriteTo.File(new CompactJsonFormatter(), "log.txt", rollingInterval: RollingInterval.Day)
			.CreateLogger()
			.ForContext<T>();
	}
}
