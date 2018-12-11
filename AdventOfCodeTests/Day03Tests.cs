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

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod()]
        public void ClaimInitializeTest()
        {
            var claim = new Day03.Claim("#13 @ 2,3:4x5");
            Assert.AreEqual(13, claim.ID);
            Assert.AreEqual(2, claim.x);
            Assert.AreEqual(3, claim.y);
            Assert.AreEqual(4, claim.width);
            Assert.AreEqual(5, claim.height);
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
            Assert.AreEqual(96569, Day03.Puzzle1(inputDay03));
        }


        // == == == == == Puzzle 2 == == == == ==
    }
}