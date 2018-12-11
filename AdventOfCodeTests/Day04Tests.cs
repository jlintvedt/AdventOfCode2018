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
    public class Day04Tests
    {
        string[] inputDay04;
        string[] inputDay04Example1;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay04 = Helper.LoadResourceStringArray("D04_Puzzle", Environment.NewLine);
            inputDay04Example1 = Helper.LoadResourceStringArray("D04_E1", Environment.NewLine);
        }

        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(240, Day04.Puzzle1(inputDay04));
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            Assert.Fail();
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