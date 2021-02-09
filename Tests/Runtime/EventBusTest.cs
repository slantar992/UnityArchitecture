
using NUnit.Framework;

namespace Slantar.Architecture.Tests
{
	public class EventBusTest 
	{
		private IEventBus eventBus;
		private EventData1 eventData1;

		public class Class 
		{
			public void MethodFail(EventData1 data) => Assert.Fail("This method must not be triggered");
			public void MethodPass(EventData1 data) => Assert.Pass("This method must be triggered");
			public void MethodData(EventData1 data) => Assert.AreEqual(1, data.i, "EventData1 triggered in class 1 successfully");
		}

		public struct EventData1
		{
			public int i;
		}


		[SetUp]
		public void Setup()
		{
			eventBus = new EventBus();
			eventData1 = new EventData1 { i = 1 };
		}


		[Test]
		public void SubscribeAndTrigger()
		{
			var c = new Class();
			eventBus.Subscribe<EventData1>(c.MethodPass);
			eventBus.Trigger<EventData1>();
		}

		[Test]
		public void SubscribeAndTriggerWithData()
		{
			var c = new Class();
			eventBus.Subscribe<EventData1>(c.MethodData);
			eventBus.Trigger(eventData1);
		}

		[Test]
		public void Unsubscribe()
		{
			var c = new Class();

			eventBus.Subscribe<EventData1>(c.MethodFail);
			Assert.True(eventBus.Unsubscribe<EventData1>(c.MethodFail), "Unsubscribe successfully");
			eventBus.Trigger(eventData1);
		}

		[Test]
		public void ClearAllEvents()
		{
			var c = new Class();

			eventBus.Subscribe<EventData1>(c.MethodFail);
			eventBus.Clear();
			eventBus.Trigger(eventData1);
		}
	}
}