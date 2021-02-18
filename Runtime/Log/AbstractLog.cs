

using System;
using System.Collections;

namespace Slantar.Architecture
{
	public abstract class AbstractLog : ILog
	{

		public event Action<string> OnDebug;
		public event Action<string> OnInfo;
		public event Action<string> OnNotice;
		public event Action<string> OnWarning;
		public event Action<string> OnError;

		public LogLevel MinLogLevel { get; set; }

		public AbstractLog() { }
		public AbstractLog(LogLevel minLogLevel) => MinLogLevel = minLogLevel;

		public virtual void Debug(string message) => PrintLog(LogLevel.Debug, message, OnDebug);
		public virtual void Info(string message) => PrintLog(LogLevel.Info, message, OnInfo);
		public virtual void Notice(string message) => PrintLog(LogLevel.Notice, message, OnNotice);
		public virtual void Warning(string message) => PrintLog(LogLevel.Warning, message, OnWarning);
		public virtual void Error(string message) => PrintLog(LogLevel.Error, message, OnError);

		private void PrintLog(LogLevel level, string message, Action<string> logEvent)
		{
			if (level >= MinLogLevel)
			{
				var formartedMessage = $"{level.ToString().ToUpper()}: {message}";
				PrintNative(level, formartedMessage);
				logEvent?.Invoke(formartedMessage);
			}
		}

		protected abstract void PrintNative(LogLevel level, string message);
	}
}