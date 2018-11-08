using System;
using ESFA.DC.Logging.Interfaces;

namespace ESFA.DC.ServiceFabric.Common.Stubs
{
    public class LoggerStub : ILogger
    {
        public void Dispose()
        {
        }

        public void LogFatal(string message, Exception exception = null, object[] parameters = null, string callerMemberName = "", string callerFilePath = "", int callerLineNumber = 0)
        {
        }

        public void LogError(string message, Exception exception = null, object[] parameters = null, string callerMemberName = "", string callerFilePath = "", int callerLineNumber = 0)
        {
        }

        public void LogWarning(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "", int callerLineNumber = 0)
        {
        }

        public void LogDebug(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "", int callerLineNumber = 0)
        {
        }

        public void LogInfo(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "", int callerLineNumber = 0)
        {
        }

        public void LogVerbose(string message, object[] parameters = null, string callerMemberName = "", string callerFilePath = "", int callerLineNumber = 0)
        {
        }
    }
}
