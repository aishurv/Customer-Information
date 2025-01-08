using Serilog;
namespace CustomerInformation
{
    public static class Logger
    {
        public static void LogInitializer()
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
        }
        public static void LogClose()
        {
            Log.Information("Program is Closing !");
            System.Threading.Thread.Sleep(100);
            Log.CloseAndFlush();
        }
    }

}
