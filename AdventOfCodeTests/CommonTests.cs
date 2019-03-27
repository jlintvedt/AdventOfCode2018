using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class CommonTests
    {
        // == == == == == Parsing == == == == ==
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

        [TestMethod]
        public void ParseCharSubstringArrayTest()
        {
            var input = "Step C must be finished before step A can begin.\r\nStep C must be finished before step F can begin.";
            var parsed = Common.ParseCharSubstringTupleArray(input, 5, 36);
            CollectionAssert.AreEqual(new (char,char)[] { ('C', 'A'),('C','F') }, parsed);
        }

        // == == == == == Conversion == == == == ==
        [TestMethod]
        public void LetterToIndexTest()
        {
            Assert.AreEqual(0, Common.LetterToIndex('A'));
            Assert.AreEqual(1, Common.LetterToIndex('B'));
            Assert.AreEqual(25, Common.LetterToIndex('Z'));
        }

        [TestMethod]
        public void IndexToLetterTest()
        {
            Assert.AreEqual('A', Common.IndexToLetter(0));
            Assert.AreEqual('B', Common.IndexToLetter(1));
            Assert.AreEqual('Z', Common.IndexToLetter(25));
        }
    }
}
