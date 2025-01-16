using Serilog;
namespace CustomerInformation.Helper
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
        public static void LogInformation(string info)
        {
            Log.Information(info);
        }
        public static void LogError(string info)
        {
            Log.Error(info);
        }
    }

}
