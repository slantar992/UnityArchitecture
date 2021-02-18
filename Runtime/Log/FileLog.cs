

using System.IO;

namespace Slantar.Architecture
{
	public class FileLog : AbstractLog
	{
		private string path;

		public FileLog(string path, LogLevel minLogLevel = LogLevel.Debug) : base(minLogLevel)
		{
			CreateFileIfNotExist(path);

			this.path = path;
		}

		private static void CreateFileIfNotExist(string path)
		{
			if (!File.Exists(path))
			{
				var directory = Path.GetDirectoryName(path);
				if (!Directory.Exists(directory))
				{
					Directory.CreateDirectory(directory);
				}
				using var file = File.Create(path);
			}
		}

		protected override void PrintNative(LogLevel level, string message)
		{
			File.AppendAllText(path, message + "\n");
		}
	}
}