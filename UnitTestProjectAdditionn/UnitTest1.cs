using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;

namespace UnitTestProjectAdditionn
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            AdditionClass a = new AdditionClass();
            Assert.AreEqual(30, a.Add(10, 15));
        }

        [TestMethod]
        public void TestMethod2()
        {
            AdditionClass a = new AdditionClass();
            Assert.AreEqual(5, a.Sub(15, 10));
        }
    }
}
