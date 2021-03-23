
using System;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace Slantar.Architecture.Tests.Log
{
	[TestFixture]
	public class LogTest
	{
		private const string DEFAULT_MESSAGE = "Hello!";
		private const string FILE_PATH = "./File.txt";

		[DatapointSource] private ILog[] logs =
		{
			new SystemConsoleLog(),
			new FileLog(FILE_PATH),
			new CompositeLog(LogLevel.Debug, new SystemConsoleLog(), new FileLog(FILE_PATH))
		};
		
		[Theory]
		public virtual void TestDebug(ILog log) => TestLog(log.Debug);
		[Theory]
		public virtual void TestInfo(ILog log) => TestLog(log.Info);
		[Theory]
		public virtual void TestNotice(ILog log) => TestLog(log.Notice);
		[Theory]
		public virtual void TestWarning(ILog log) => TestLog(log.Warning);
		[Theory]
		public virtual void TestError(ILog log) => TestLog(log.Error);
		[Theory]
		public virtual void TestMinLogLevelShowing(ILog log) => Assert.True(TestMinLogLevel(log, true), "Message triggered correctly");
		[Theory]
		public virtual void TestMinLogLevelNotShowing(ILog log) => Assert.False(TestMinLogLevel(log, false), "Message not triggered correctly");
		[Theory]
		public virtual void TestOnDebugEvent(ILog log)
		{
			log.MinLogLevel = LogLevel.Debug;
			TestEvent((Action<string> onTriggered) =>
			{
				log.OnDebug += onTriggered;
				log.Debug(DEFAULT_MESSAGE);
				log.OnDebug -= onTriggered;
			});
		}

		[Theory]
		public virtual void TestOnInfoEvent(ILog log) 
		{
			log.MinLogLevel = LogLevel.Info;
			TestEvent((Action<string> onTriggered) =>
			{
				log.OnInfo += onTriggered;
				log.Info(DEFAULT_MESSAGE);
				log.OnInfo -= onTriggered;
			});
		}

		[Theory]
		public virtual void TestOnNoticeEvent(ILog log) 
		{
			log.MinLogLevel = LogLevel.Notice;
			TestEvent((Action<string> onTriggered) =>
			{
				log.OnNotice += onTriggered;
				log.Notice(DEFAULT_MESSAGE);
				log.OnNotice -= onTriggered;
			});
		}

		[Theory]
		public virtual void TestOnWarningEvent(ILog log) 
		{
			log.MinLogLevel = LogLevel.Warning;
			TestEvent((Action<string> onTriggered) =>
			{
				log.OnWarning += onTriggered;
				log.Warning(DEFAULT_MESSAGE);
				log.OnWarning -= onTriggered;
			});
		}

		[Theory]
		public virtual void TestOnErrorEvent(ILog log)
		{
			log.MinLogLevel = LogLevel.Error;
			TestEvent((Action<string> onTriggered) =>
			{
				log.OnError += onTriggered;
				log.Error(DEFAULT_MESSAGE);
				log.OnError -= onTriggered;
			});
		}

		private static void TestLog(Action<string> logMethod)
		{
			logMethod(DEFAULT_MESSAGE);
			Assert.Pass();
		}

		private static bool TestMinLogLevel(ILog log, bool show)
		{
			bool triggered = false;
			log.MinLogLevel = show ? LogLevel.Info : LogLevel.Error;
			log.OnInfo += OnTriggered;

			log.Info(DEFAULT_MESSAGE);

			log.OnInfo -= OnTriggered;
			void OnTriggered(string message) => triggered = true;

			return triggered;
		}

		private void TestEvent(Action<Action<string>> subscribingMethod)
		{
			var triggered = false;
			void OnTriggered(string message) => triggered = true;

			subscribingMethod(OnTriggered);

			Assert.True(triggered, "Event triggered Correctly");
		}
	}
}