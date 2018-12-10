using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void LoadResourceIntArrayTest()
        {
            var resource = Helper.LoadResourceIntArray("HelperIntArray", Environment.NewLine);
            CollectionAssert.AreEqual(new int[] { -3, -2, -1, 0, 1, 2, 3 }, resource);
        }

        [TestMethod]
        public void LoadResourceStringArrayTest()
        {
            var resource = Helper.LoadResourceStringArray("HelperStringArray", Environment.NewLine);
            CollectionAssert.AreEqual(new string[] { "abcd", "efgh", "jkl" }, resource);
        }
    }
}
