using Serilog;
namespace CustomerInformation
{
    public static class Logger
    {
        /// <summary>
        /// Initialize Log to file logs/log.txt with RollingInterval of 1 day 
        /// </summary>
        public static void LogInitializer()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            Log.Information("Log Initialized !");
        }
        /// <summary>
        /// closing log and Log.CloseAndFlush
        /// </summary>
        public static void LogClose()
        {
            Log.Information("Program is Closing !");
            Log.CloseAndFlush();
        }
    }

}
