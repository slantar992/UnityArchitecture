
using System;
using NUnit.Framework;

namespace Slantar.Architecture.Tests.Log
{
	public abstract class ILogTest
	{
		private const string DEFAULT_MESSAGE = "Hello!";

		private ILog log;

		protected abstract ILog NewInstance { get; }

		[SetUp]
		public virtual void SetUp() => log = NewInstance;
		[Test]
		public virtual void TestDebug() => TestLog(log.Debug);
		[Test]
		public virtual void TestInfo() => TestLog(log.Info);
		[Test]
		public virtual void TestNotice() => TestLog(log.Notice);
		[Test]
		public virtual void TestWarning() => TestLog(log.Warning);
		[Test]
		public virtual void TestError() => TestLog(log.Error);
		[Test]
		public virtual void TestMinLogLevelShowing() => Assert.True(TestMinLogLevel(true), "Message triggered correctly");
		[Test]
		public virtual void TestMinLogLevelNotShowing() => Assert.False(TestMinLogLevel(false), "Message not triggered correctly");
		[Test]
		public virtual void TestOnDebugEvent() => TestEvent((Action<string> onTriggered) =>
		  {
			  log.OnDebug += onTriggered;
			  log.Debug(DEFAULT_MESSAGE);
			  log.OnDebug -= onTriggered;
		  });

		[Test]
		public virtual void TestOnInfoEvent() => TestEvent((Action<string> onTriggered) =>
		 {
			 log.OnInfo += onTriggered;
			 log.Info(DEFAULT_MESSAGE);
			 log.OnInfo -= onTriggered;
		 });

		[Test]
		public virtual void TestOnNoticeEvent() => TestEvent((Action<string> onTriggered) =>
		 {
			 log.OnNotice += onTriggered;
			 log.Notice(DEFAULT_MESSAGE);
			 log.OnNotice -= onTriggered;
		 });

		[Test]
		public virtual void TestOnWarningEvent() => TestEvent((Action<string> onTriggered) =>
		{
			log.OnWarning += onTriggered;
			log.Warning(DEFAULT_MESSAGE);
			log.OnWarning -= onTriggered;
		});

		[Test]
		public virtual void TestOnErrorEvent() => TestEvent((Action<string> onTriggered) =>
		 {
			 log.OnError += onTriggered;
			 log.Error(DEFAULT_MESSAGE);
			 log.OnError -= onTriggered;
		 });

		[Test]
		public virtual void TestSave()
		{
			log.Save();
			Assert.True(CheckRecorded(), "Log saved correctly!");
		}

		private void TestLog(Action<string> logMethod)
		{
			logMethod(DEFAULT_MESSAGE);
			Assert.Pass();
		}

		private bool TestMinLogLevel(bool show)
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
			bool triggered = false;
			void OnTriggered(string message) => triggered = true;

			subscribingMethod(OnTriggered);

			Assert.True(triggered, "Event triggered Correctly");
		}

		public abstract bool CheckRecorded();
	}
}