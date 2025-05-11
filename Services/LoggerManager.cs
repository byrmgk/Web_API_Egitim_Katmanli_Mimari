using NLog;
using Services.Contracts;

namespace Services
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public class LoggerManager : ILoggerService
    {
        //TODO: ILogger using NLog; üzerinden beslendiğine dikkat edin.
        //TODO: Loger kullanmak için ekle.
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(string message) => logger.Error(message);


        public void LogInfo(string message) => logger.Info(message);

        public void LogWarning(string message) => logger.Warn(message);
    }
}
