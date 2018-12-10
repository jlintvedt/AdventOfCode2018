using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AdventOfCode;
using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass()]
    public class Day01Tests
    {
        int[] inputDay01;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay01 = Helper.LoadResourceIntArray("D01_P1", Environment.NewLine);
        }

        [TestMethod()]
        public void CalculateFrequencyTest_Example()
        {
            // Example 1
            Assert.AreEqual(3, Day01.CalculateFrequency(Helper.LoadResourceIntArray("D01_E1", ",")));
            // Example 2
            Assert.AreEqual(3, Day01.CalculateFrequency(Helper.LoadResourceIntArray("D01_E2", ",")));
            // Example 3
            Assert.AreEqual(0, Day01.CalculateFrequency(Helper.LoadResourceIntArray("D01_E3", ",")));
            // Example 4
            Assert.AreEqual(-6, Day01.CalculateFrequency(Helper.LoadResourceIntArray("D01_E4", ",")));
        }

        [TestMethod()]
        public void CalculateFrequencyTest_Puzzle1()
        {
            var resultingFrequency = Day01.CalculateFrequency(inputDay01);
            Assert.AreEqual(590, resultingFrequency);
        }

        [TestMethod()]
        public void FindReccuringFrequency_Example()
        {
            // Example 1
            Assert.AreEqual(2, Day01.FindReccuringFrequency(Helper.LoadResourceIntArray("D01_E1", ",")));
            // Example 5
            Assert.AreEqual(0, Day01.FindReccuringFrequency(Helper.LoadResourceIntArray("D01_E5", ",")));
            // Example 6
            Assert.AreEqual(10, Day01.FindReccuringFrequency(Helper.LoadResourceIntArray("D01_E6", ",")));
            // Example 7
            Assert.AreEqual(5, Day01.FindReccuringFrequency(Helper.LoadResourceIntArray("D01_E7", ",")));
            // Example 7
            Assert.AreEqual(14, Day01.FindReccuringFrequency(Helper.LoadResourceIntArray("D01_E8", ",")));
        }

        [TestMethod()]
        public void FindReccuringFrequency_Puzzle2()
        {
            var resultingFrequency = Day01.FindReccuringFrequency(inputDay01);
            Assert.AreEqual(83445, resultingFrequency);
        }
    }
}
