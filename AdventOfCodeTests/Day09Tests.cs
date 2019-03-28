using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day09Tests
    {
        //string inputDay09;

        [TestInitialize]
        public void TestInitialize()
        {
            //inputDay09 = InputData.ResourceManager.GetObject("D09_Puzzle").ToString();
        }

        // == == == == == Puzzle 1 == == == == ==
        
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(32, Day09.Puzzle1(9, 25));
            Assert.AreEqual(8317, Day09.Puzzle1(10, 1618));
            Assert.AreEqual(146373, Day09.Puzzle1(13, 7999));
            Assert.AreEqual(2764, Day09.Puzzle1(17, 1104));
            Assert.AreEqual(54718, Day09.Puzzle1(21, 6111));
            Assert.AreEqual(37305, Day09.Puzzle1(30, 5807));
        }

        // Runtime ...
        [TestMethod]
        public void Puzzle1Test()
        {
            Assert.AreEqual(374287, Day09.Puzzle1(468, 71010));
        }

        // == == == == == Puzzle 2 == == == == ==
        // Runtime ...
        [TestMethod]
        public void Puzzle2Test()
        {
            Assert.AreEqual(3083412635, Day09.Puzzle1(468, 7101000));
        }
    }
}