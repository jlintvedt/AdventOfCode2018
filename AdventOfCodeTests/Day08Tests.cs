using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day08Tests
    {
        string inputDay08;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay08 = InputData.ResourceManager.GetObject("D08_Puzzle").ToString();
        }

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(138, Day08.Puzzle1(inputDay08));
        }

        // Runtime on Surface Book 2 i7: <1 ms
        [TestMethod]
        public void Puzzle1Test()
        {
            
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            
        }

        // Runtime on Surface Book 2 i7: 45 ms
        [TestMethod]
        public void Puzzle2Test()
        {
            
        }
    }
}
