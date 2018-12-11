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
    public class Day03Tests
    {
        string[] inputDay03;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay03 = Helper.LoadResourceStringArray("D03_Puzzle", Environment.NewLine);
        }

        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            var input = Helper.LoadResourceStringArray("D03_E1", Environment.NewLine);
            Assert.AreEqual(4, Day03.Puzzle1(input));
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            Assert.Fail();
        }
    }
}