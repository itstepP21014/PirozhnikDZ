using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            StringBuilder strOne = ApplicationTest.Program.returnStringBilder("123");
            StringBuilder strTwo = ApplicationTest.Program.returnStringBilder("abc");
            StringBuilder strExpected = new StringBuilder("123abc");
            StringBuilder strAppend = strOne.Append(strTwo);
            Assert.AreEqual(strExpected.ToString(), strAppend.ToString());

        }
    }
}
