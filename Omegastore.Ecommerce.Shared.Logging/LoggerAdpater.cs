using Omegastore.Ecommerce.Shared.Common;
using Microsoft.Extensions.Logging;

namespace Omegastore.Ecommerce.Shared.Logging
{
    public class LoggerAdpater<T> : IAppLogger<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdpater(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<T>();
        }
        public void LogInformation(string message, params object[] args) {
            _logger.LogInformation(message, args);
        }

        public void LogWaring(string message, params object[] args){
            _logger.LogWarning(message, args);
        }

        public void LogError(string message, params object[] args) {
            _logger.LogError(message, args);
        }
    }
}
