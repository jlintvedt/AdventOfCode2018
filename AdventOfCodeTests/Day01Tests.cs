using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day01Tests
    {
        string inputDay01;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay01 = InputData.ResourceManager.GetObject("D01_Puzzle").ToString();
        }

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            // Example 1
            Assert.AreEqual(3, Day01.Puzzle1(InputData.ResourceManager.GetObject("D01_E1").ToString().Replace(",", Environment.NewLine)));
            // Example 2
            Assert.AreEqual(3, Day01.Puzzle1(InputData.ResourceManager.GetObject("D01_E2").ToString().Replace(",", Environment.NewLine)));
            // Example 3
            Assert.AreEqual(0, Day01.Puzzle1(InputData.ResourceManager.GetObject("D01_E3").ToString().Replace(",", Environment.NewLine)));
            // Example 4
            Assert.AreEqual(-6, Day01.Puzzle1(InputData.ResourceManager.GetObject("D01_E4").ToString().Replace(",", Environment.NewLine)));
        }

        [TestMethod]
        public void Puzzle1Test()
        {
            Assert.AreEqual(590, Day01.Puzzle1(inputDay01));
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            // Example 1
            Assert.AreEqual(2, Day01.Puzzle2(InputData.ResourceManager.GetObject("D01_E1").ToString().Replace(",", Environment.NewLine)));
            // Example 5
            Assert.AreEqual(0, Day01.Puzzle2(InputData.ResourceManager.GetObject("D01_E5").ToString().Replace(",", Environment.NewLine)));
            // Example 6
            Assert.AreEqual(10, Day01.Puzzle2(InputData.ResourceManager.GetObject("D01_E6").ToString().Replace(",", Environment.NewLine)));
            // Example 7
            Assert.AreEqual(5, Day01.Puzzle2(InputData.ResourceManager.GetObject("D01_E7").ToString().Replace(",", Environment.NewLine)));
            // Example 7
            Assert.AreEqual(14, Day01.Puzzle2(InputData.ResourceManager.GetObject("D01_E8").ToString().Replace(",", Environment.NewLine)));
        }

        [TestMethod]
        public void Puzzle2Test()
        {
            var resultingFrequency = Day01.Puzzle2(inputDay01);
            Assert.AreEqual(83445, resultingFrequency);
        }
    }
}
