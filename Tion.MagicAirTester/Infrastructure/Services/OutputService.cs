using System;
using System.Collections.Generic;
using System.ComponentModel;
using log4net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tion.DeviceTester.Properties;
using Tion.MagicAirTester.Contracts;

namespace Tion.MagicAirTester.Infrastructure.Services
{
    public class OutputService : IOutputService, INotifyPropertyChanged
    {
        private readonly ILog _logger;

        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public OutputService(ILog logger)
        {
            _logger = logger;
        }

        public string Data {
            get { return _stringBuilder.ToString(); }
        }

        public void Log(LogType type, string message)
        {
            _stringBuilder.AppendLine(string.Concat(DateTime.Now, "> ", message));
            LogToLogger(type, message);
            OnPropertyChanged(nameof(Data));
        }

        public void Log(LogType type, string message, params object[] args)
        {
            var value = string.Format(message, args);
            _stringBuilder.AppendLine(string.Concat(DateTime.Now, "> ", value));
            LogToLogger(type, value);
            OnPropertyChanged(nameof(Data));
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="exception"></param>
        public void Log(Exception exception)
        {
            _stringBuilder.AppendLine(string.Concat(DateTime.Now, "> ERROR:", exception.Message));
            _logger.Error(exception.Message, exception);
            OnPropertyChanged(nameof(Data));
        }

        private void LogToLogger(LogType type, string message)
        {
            switch (type)
            {
                case LogType.Info:
                    _logger.Info(message);
                    break;
                case LogType.Error:
                    _logger.Error(message);
                    break;
                case LogType.Warning:
                    _logger.Warn(message);
                    break;
                default:
                    _logger.Info(message);
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Clear Logs
        /// </summary>
        public void Clear()
        {
            _stringBuilder.Clear();
            OnPropertyChanged(nameof(Data));
        }
    }
}
