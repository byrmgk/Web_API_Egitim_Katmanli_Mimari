using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    //TODO:internal erişim belirleyicini public olarak değiştirin.
    public interface ILoggerService
    {
        //TODO: Information, Warning, Error ve Debug logları için ayrı ayrı metotlar oluşturduk.
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
}
