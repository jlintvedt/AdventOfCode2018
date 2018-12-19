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

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay05 = InputData.ResourceManager.GetObject("D05_Puzzle").ToString();
        }

        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(10, Day05.Puzzle1("dabAcCaCBAcCcaDA"));
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            Assert.AreEqual(10598, Day05.Puzzle1(inputDay05));
        }

        [TestMethod()]
        public void Puzzle2ExampleTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void Puzzle2Test()
        {
            Assert.Fail();
        }
    }
}