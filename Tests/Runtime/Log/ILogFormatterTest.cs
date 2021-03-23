using NUnit.Framework;

namespace Slantar.Architecture.Tests.Log
{
    [TestFixture]
    public class ILogFormatterTest
    {
        private const string DEFAULT_MESSAGE = "Hello world!!";
        
        [DatapointSource]
        private ILogFormatter[] formatters =
        {
            new BasicLogFormatter(),
            new TimestampLogFormatter("MM/dd/yyyy HH:mm:ss")
        };

        [DatapointSource] private LogLevel level;

        [Theory]
        public void TestFormatter(ILogFormatter formatter, LogLevel level)
        {
            formatter.Format(level, DEFAULT_MESSAGE);
            Assert.Pass();
        }
    }
}