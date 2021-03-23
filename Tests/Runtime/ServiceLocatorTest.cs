
using NUnit.Framework;

namespace Slantar.Architecture.Tests
{
	[TestFixture]
	public class ServiceLocatorTest
	{
		public static string ID1 = "Class1";
		public static string ID2 = "Class2";

		public interface Interface { }
		public class Implementation : Interface { }
		public class Class { }

		private ServiceLocator container;


		[SetUp]
		public void SetUp()
		{
			container = new ServiceLocator();
		}

		[Test]
		public void ProvideInstancedAndGet()
		{
			container.ProvideInstanced<Class>();
			Class instance = container.Get<Class>();

			Assert.NotNull(instance);
			Assert.IsInstanceOf<Class>(instance);
		}

		[Test]
		public void ProvideAndGet()
		{
			container.Provide<Class>();
			Class instance = container.Get<Class>();

			Assert.NotNull(instance);
			Assert.IsInstanceOf<Class>(instance);
		}

		[Test]
		public void Provide2InstancesFromSameClass()
		{
			var instance1 = new Class();
			var instance2 = new Class();

			container.ProvideInstanced(instance1, ID1);
			container.ProvideInstanced(instance2, ID2);

			var class1 = container.Get<Class>(ID1);
			var class2 = container.Get<Class>(ID2);

			Assert.AreEqual(instance1, class1);
			Assert.AreEqual(instance2, class2);
		}

		[Test]
		public void ProvideInterface()
		{
			container.ProvideInstanced<Interface>(new Implementation());
			Interface instance = container.Get<Interface>();

			Assert.NotNull(instance);
			Assert.IsInstanceOf<Interface>(instance);
		}

		[Test]
		public void RemoveInstance()
		{
			container.Provide<Class>();
			Assert.True(container.Remove<Class>(), "Class hasn't be removed correctly");
		}

		[Test]
		public void Clear()
		{
			container.Provide<Class>();
			container.Clear();

			Assert.False(container.Remove<Class>(), "The container hasn't remove instances correctly");
		}
	}
}
