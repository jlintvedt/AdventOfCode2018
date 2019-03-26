using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class CommonTests
    {
        [TestMethod]
        public void ParseIntArrayTest()
        {
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, Common.ParseIntArray("1\r\n2\r\n3"));
        }

        [TestMethod]
        public void ParseStringArrayTest()
        {
            CollectionAssert.AreEqual(new string[] { "1", "2", "3" }, Common.ParseStringArray("1\r\n2\r\n3"));
        }

        [TestMethod]
        public void ParseIntTupleArrayTest()
        {
            CollectionAssert.AreEqual(new (int, int)[] { (1, 1), (1, 6), (8, 3) }, Common.ParseIntTupleArray("1, 1\r\n1, 6\r\n8, 3"));
        }
    }
}
