

using System.IO;

namespace Slantar.Architecture
{
	public class FileLog : AbstractLog
	{
		//private readonly File file;

		public FileLog(string filePath, LogLevel minLogLevel) : base(minLogLevel)
		{

		}

		public override void Save()
		{

		}

		protected override void PrintNative(LogLevel level, string message)
		{

		}
	}
}