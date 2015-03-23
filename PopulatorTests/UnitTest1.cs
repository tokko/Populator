using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Populator;
namespace PopulatorTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestPopulator()
		{
			var a = new A {a = "a", b = 1};

			var b = new B();
			b = b.PopulateWith(a);

			Assert.AreEqual(a.a, b.a);
			Assert.AreEqual(a.b, b.b);
		}
	}

	public class A
	{
		public string a { get; set; }
		public int b { get; set; }
	}

	public class B
	{
		public string a { get; set; }
		public int b { get; set; }
	}
}
