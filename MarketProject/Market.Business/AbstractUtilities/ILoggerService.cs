namespace MarketProject.Business.AbstractUtilities
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogEvent(string message);
        void LogDebug(string message);
        void LogError(string message);
    }
}

