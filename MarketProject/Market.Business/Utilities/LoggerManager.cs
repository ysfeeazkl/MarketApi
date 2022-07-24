using MarketProject.Business.AbstractUtilities;
using NLog;

namespace MarketProject.Business.Utilities
{
    public class LoggerManager : ILoggerService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => logger.Debug(message);
        public void LogError(string message) => logger.Error(message);
        public void LogInfo(string message) => logger.Info(message);
        public void LogWarning(string message) => logger.Warn(message);
        public void LogEvent(string message) => logger.Trace(message);
    }
}

