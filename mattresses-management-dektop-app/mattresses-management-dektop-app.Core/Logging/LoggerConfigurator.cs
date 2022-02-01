using Serilog;
using System;
using System.IO;

namespace mattresses_management_dektop_app.Core.Logging
{
    public static class LoggerConfigurator
    {
        private static readonly string _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mattresses-management\\logs.txt");

        public static void Initialization()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(_logFilePath, rollingInterval: RollingInterval.Day, shared: true)
                .WriteTo.Debug()
                .CreateLogger();

            Serilog.Log.Information("Serilog configuration is done.");
            Serilog.Log.Information("The log file is in the " + _logFilePath);
        }
    }
}