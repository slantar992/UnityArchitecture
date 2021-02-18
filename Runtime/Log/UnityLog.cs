
using System;
using System.Collections.Generic;
using UnityDebug = UnityEngine.Debug;
namespace Slantar.Architecture
{
	public class UnityLog : AbstractLog
	{
		private readonly Dictionary<LogLevel, Action<string>> unityLogs = new Dictionary<LogLevel, Action<string>>()
		{
			{LogLevel.Debug, UnityDebug.Log},
			{LogLevel.Info, UnityDebug.Log},
			{LogLevel.Notice, UnityDebug.Log},
			{LogLevel.Warning, UnityDebug.LogWarning},
			{LogLevel.Error, UnityDebug.LogError}
		};

		public UnityLog(LogLevel minLogLevel = LogLevel.Debug) : base(minLogLevel) { }

		protected override void PrintNative(LogLevel level, string message) => unityLogs[level](message);
	}
}