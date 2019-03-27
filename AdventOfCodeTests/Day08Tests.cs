using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day08Tests
    {
        string inputDay08;
        string inputDay08Example1;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay08 = InputData.ResourceManager.GetObject("D08_Puzzle").ToString();
            inputDay08Example1 = InputData.ResourceManager.GetObject("D08_E1").ToString();
        }

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(138, Day08.Puzzle1(inputDay08Example1));
        }

        // Runtime...
        [TestMethod]
        public void Puzzle1Test()
        {
            Assert.AreEqual(41555, Day08.Puzzle1(inputDay08));
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            Assert.AreEqual(66, Day08.Puzzle2(inputDay08Example1));
        }

        // Runtime...
        [TestMethod]
        public void Puzzle2Test()
        {
            Assert.AreEqual(16653, Day08.Puzzle2(inputDay08));
        }
    }
}
