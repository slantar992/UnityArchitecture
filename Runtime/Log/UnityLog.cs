
using UnityDebug = UnityEngine.Debug;

namespace Slantar.Architecture
{
	public class UnityLog : AbstractLog
	{
		protected override void PrintNative(LogLevel level, string message)
		{
			switch (level)
			{
				case LogLevel.Debug:
				case LogLevel.Info:
				case LogLevel.Notice:
					UnityDebug.Log(message);
					break;
				case LogLevel.Warning:
					UnityDebug.LogWarning(message);
					break;
				case LogLevel.Error:
					UnityDebug.LogError(message);
					break;
			}
		}
	}
}