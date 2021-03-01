
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Slantar.Architecture.Tests
{
	public class InstancePoolTest
	{
		private IPool<Pooled> pool;

		[SetUp]
		public void SetUp()
		{
			pool = new InstancePool<Pooled>();
		}

		[Test]
		public void IsPickInstanceAnInstanceOfClass()
		{
			var instance = pool.Pick();
			Assert.IsInstanceOf<Pooled>(instance);
		}

		[Test]
		public void IsPickInstanceNotNull()
		{
			var instance = pool.Pick();
			Assert.IsNotNull(instance);
		}

		[Test]
		public void ReleaseInstance()
		{
			var instance = pool.Pick();
			pool.Release(instance);
			Assert.Pass();
		}

		[Test]
		public void ReleaseMultipleInstances()
		{
			var maxInstances = 10;
			var instances = new List<Pooled>();
			var rand = new Random();
			int randValue;

			for (int i = 0; i < maxInstances; i++)
			{
				instances.Add(pool.Pick());
			}

			for (int i = 0; i < maxInstances; i++)
			{
				randValue = rand.Next(0, instances.Count);
				pool.Release(instances[randValue]);
				instances.RemoveAt(randValue);
			}

			Assert.Pass();
		}

		[Test]
		public void ReleaseInstanceNotCreatedInPool()
		{
			var instance = new Pooled();
			try
			{
				pool.Release(instance);
			}
			catch (Exception e)
			{
				Assert.IsInstanceOf<InstanceNotFoundException>(e);
			}
		}

		public class Pooled { }
	}
}
