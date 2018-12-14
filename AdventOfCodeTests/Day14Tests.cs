using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests
{
    [TestClass()]
    public class Day14Tests
    {
        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual("5158916779", Day14.Puzzle1(9));
            Assert.AreEqual("0124515891", Day14.Puzzle1(5));
            Assert.AreEqual("9251071085", Day14.Puzzle1(18));
            Assert.AreEqual("5941429882", Day14.Puzzle1(2018));
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            Assert.AreEqual("5992684592", Day14.Puzzle1(165061));
        }

    }
}