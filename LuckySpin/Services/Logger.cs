using log4net;

namespace LuckySpin.Services
{
    public class Logger : ILogger
    {
        private static readonly ILog Log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Info(string message)
        {
            Log.Info(message);
        }
    }
}