using System;

namespace Slantar.Architecture
{
    public class TimestampLogFormatter : ILogFormatter
    {
        public readonly string dateFormat;
        private BasicLogFormatter basicFormatter;

        public TimestampLogFormatter(string dateFormat)
        {
            this.dateFormat = dateFormat;
            basicFormatter = new BasicLogFormatter();
        }

        public string Format(LogLevel level, string message)
            => $"[{DateTime.Now.ToString(dateFormat)}] {basicFormatter.Format(level, message)}";
    }
}