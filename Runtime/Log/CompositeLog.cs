
using System;
using System.Collections.Generic;
using System.Linq;

namespace Slantar.Architecture
{
	public class CompositeLog : ILog
	{
		private readonly List<ILog> logs;

		public event Action<string> OnDebug
		{
			add => logs.Last().OnDebug += value;
			remove => logs.Last().OnDebug -= value;
		}

		public event Action<string> OnInfo
		{
			add => logs.Last().OnInfo += value;
			remove => logs.Last().OnInfo -= value;
		}

		public event Action<string> OnNotice
		{
			add => logs.Last().OnNotice += value;
			remove => logs.Last().OnNotice -= value;
		}

		public event Action<string> OnWarning
		{
			add => logs.Last().OnWarning += value;
			remove => logs.Last().OnWarning -= value;
		}

		public event Action<string> OnError
		{
			add => logs.Last().OnError += value;
			remove => logs.Last().OnError -= value;
		}

		public LogLevel MinLogLevel
		{
			get => logs[0].MinLogLevel;
			set
			{
				foreach (var log in logs)
				{
					log.MinLogLevel = value;
				}
			}
		}

		public CompositeLog(LogLevel minLogLevel, params ILog[] logs)
		{
			this.logs = new List<ILog>(logs);
			MinLogLevel = minLogLevel;
		}

		public void Debug(string message)
		{
			foreach (var log in logs)
			{
				log.Debug(message);
			}
		}

		public void Info(string message)
		{
			foreach (var log in logs)
			{
				log.Info(message);
			}
		}

		public void Notice(string message)
		{
			foreach (var log in logs)
			{
				log.Notice(message);
			}
		}

		public void Warning(string message)
		{
			foreach (var log in logs)
			{
				log.Warning(message);
			}
		}

		public void Error(string message)
		{
			foreach (var log in logs)
			{
				log.Error(message);
			}
		}
	}
}