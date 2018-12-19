using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;
using AdventOfCodeTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass()]
    public class Day05Tests
    {
        string inputDay05;
        string inputDay05Example1;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay05 = InputData.ResourceManager.GetObject("D05_Puzzle").ToString();
            inputDay05Example1 = "dabAcCaCBAcCcaDA";
        }

        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(10, Day05.Puzzle1(inputDay05Example1));
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            Assert.AreEqual(10598, Day05.Puzzle1(inputDay05));
        }

        [TestMethod()]
        public void Puzzle2ExampleTest()
        {
            // First test directly on AlchemicalReducer
            var ar = new Day05.AlchemicalReducer(inputDay05Example1);
            Assert.AreEqual(6, ar.ReduceWithSkip('A'));
            Assert.AreEqual(8, ar.ReduceWithSkip('B'));
            Assert.AreEqual(4, ar.ReduceWithSkip('C'));
            Assert.AreEqual(6, ar.ReduceWithSkip('D'));
            // Then test wrapper method
            Assert.AreEqual(4, Day05.Puzzle2(inputDay05Example1));
        }

        [TestMethod()]
        public void Puzzle2Test()
        {
            Assert.AreEqual(5312, Day05.Puzzle2(inputDay05));
        }
    }
}