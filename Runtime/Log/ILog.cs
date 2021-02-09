
using System;

namespace Slantar.Architecture
{
	public interface ILog
	{
		event Action<string> OnDebug;
		event Action<string> OnInfo;
		event Action<string> OnNotice;
		event Action<string> OnWarning;
		event Action<string> OnError;

		LogLevel MinLogLevel {get; set;}

		void Debug(string message);
		void Info(string message);
		void Notice(string message);
		void Warning(string message);
		void Error(string message);
	}
}