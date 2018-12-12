using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ILR.FileValidationService.Console.Stubs
{
    public class LoggerStub : ILogger
    {
        public void Dispose()
        {
            
        }

        public void LogFatal(string message, Exception exception = null, object[] parameters = null, string callerMemberName = "",
            string callerFilePath = "", int callerLineNumber = 0)
        {
            System.Console.WriteLine(message);
        }

        public void LogError(string message, Exception exception = null, object[] parameters = null, string callerMemberName = "",
            string callerFilePath = "", int callerLineNumber = 0)
        {
            System.Console.WriteLine(message);
            System.Console.WriteLine(exception.Message);
            System.Console.WriteLine(exception.ToString());
            System.Console.ReadLine();
        }

        public void LogWarning(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "",
            int callerLineNumber = 0)
        {
            System.Console.WriteLine(message);
        }

        public void LogDebug(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "",
            int callerLineNumber = 0)
        {
            System.Console.WriteLine(message);
        }

        public void LogInfo(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "",
            int callerLineNumber = 0)
        {
            System.Console.WriteLine(message);
        }

        public void LogVerbose(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "",
            int callerLineNumber = 0)
        {
            System.Console.WriteLine(message);
        }
    }
}
