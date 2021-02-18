


using System.IO;
using NUnit.Framework;
using System.Linq;

namespace Slantar.Architecture.Tests.Log
{
	public class FileLogTest : ILogTest
	{
		private const string FILE_PATH = "./file.log";

		protected override ILog NewInstance => new FileLog(FILE_PATH, LogLevel.Debug);

		[Test]
		public void TestCreated() => Assert.True(File.Exists(FILE_PATH));

		[Test]
		public void TestTextAppend()
		{
			log.Debug(DEFAULT_MESSAGE);
			var lines = File.ReadAllLines(FILE_PATH);
			Assert.True(lines.Last().Contains(DEFAULT_MESSAGE));
		}

		[TearDown]
		public void DeleteFile()
		{
			File.Delete(FILE_PATH);
		}
	}
}