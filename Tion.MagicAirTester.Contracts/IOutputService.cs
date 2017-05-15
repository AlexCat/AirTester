using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tion.MagicAirTester.Contracts
{
    public interface IOutputService
    {

        /// <summary>
        /// Output data
        /// </summary>
        string Data { get; }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="exception"></param>
        void Log(Exception exception);

        /// <summary>
        /// Append message
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        void Log(LogType type, string message);

        /// <summary>
        /// Append message with params
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void Log(LogType type, string message, params object[] args);

        /// <summary>
        /// Clear Logs
        /// </summary>
        void Clear();
    }

    public enum LogType
    {
        Info, Error, Warning
    }
}
