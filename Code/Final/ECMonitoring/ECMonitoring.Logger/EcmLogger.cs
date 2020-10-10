using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECMonitoring.Logger
{
    enum DebugLevel
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Fatal,
        NoLog
    }

    public class EcmLogger : IEcmLogger
    {
        private string _loggerName;
        private ILogger _logger;
        private DebugLevel _debugLevel;
        private bool _isConsoleLog;

        public EcmLogger(string loggerName)
        {
            _loggerName = loggerName;
            _logger = LogManager.GetLogger(loggerName);
            _debugLevel = (DebugLevel)Enum.Parse(typeof(DebugLevel), GetConfKeyValue("DebugLevel", "Error").ToString());
            _isConsoleLog = Convert.ToBoolean(GetConfKeyValue("IsConsoleLog", false));
            var t = LogManager.Configuration.FileNamesToWatch;
        }

        object GetConfKeyValue(string keyName, object defaultValue)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(keyName))
            {
                return
                    ConfigurationManager.AppSettings[keyName];
            }
            else
            {
                return defaultValue;
            }
        }

        public void Trace(string message)
        {
            if (_debugLevel > DebugLevel.Trace)
            {
                return;
            }

            message = MessageFormatting(DebugLevel.Trace, message);
            _logger.Trace(message);
            if (_isConsoleLog)
            {
                Console.WriteLine(message);
            }
        }

        public void Debug(string message)
        {
            if (_debugLevel > DebugLevel.Debug)
            {
                return;
            }

            message = MessageFormatting(DebugLevel.Debug, message);
            _logger.Debug(message);
            if (_isConsoleLog)
            {
                Console.WriteLine(message);
            }
        }

        public void Info(string message)
        {
            if (_debugLevel > DebugLevel.Info)
            {
                return;
            }

            message = MessageFormatting(DebugLevel.Info, message);
            _logger.Info(message);
            if (_isConsoleLog)
            {
                Console.WriteLine(message);
            }
        }

        public void Warn(string message)
        {
            if (_debugLevel > DebugLevel.Warn)
            {
                return;
            }

            message = MessageFormatting(DebugLevel.Fatal, message);
            _logger.Warn(message);
            if (_isConsoleLog)
            {
                Console.WriteLine(message);
            }
        }

        public void Error(string message)
        {
            if (_debugLevel > DebugLevel.Error)
            {
                return;
            }

            message = MessageFormatting(DebugLevel.Error, message);
            _logger.Error(message);
            if (_isConsoleLog)
            {
                Console.WriteLine(message);
            }
        }

        public void Fatal(string message)
        {
            if (_debugLevel > DebugLevel.Fatal)
            {
                return;
            }

            message = MessageFormatting(DebugLevel.Fatal, message);
            _logger.Fatal(message);
            if (_isConsoleLog)
            {
                Console.WriteLine(message);
            }
        }

        private string MessageFormatting(DebugLevel level, string message)
        {
            return $"[#| {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)} " +
                $"| {level.ToString().ToUpper()} | {_loggerName} | {message} |#]";
        }
    }
}
