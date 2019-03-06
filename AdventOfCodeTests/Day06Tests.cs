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
    public class Day06Tests
    {
        string inputDay06;
        string inputDay06Example1;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay06 = InputData.ResourceManager.GetObject("D06_Puzzle").ToString();
            inputDay06Example1 = InputData.ResourceManager.GetObject("D06_E1").ToString();
        }

        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(10, Day06.Puzzle1(inputDay06Example1));
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            Assert.AreEqual(10598, Day06.Puzzle1(inputDay06));
        }

        //[TestMethod()]
        //public void Puzzle2ExampleTest()
        //{
        //    // First test directly on AlchemicalReducer
        //    var ar = new Day05.AlchemicalReducer(inputDay05Example1);
        //    Assert.AreEqual(6, ar.ReduceWithSkip('A'));
        //    Assert.AreEqual(8, ar.ReduceWithSkip('B'));
        //    Assert.AreEqual(4, ar.ReduceWithSkip('C'));
        //    Assert.AreEqual(6, ar.ReduceWithSkip('D'));
        //    // Then test wrapper method
        //    Assert.AreEqual(4, Day05.Puzzle2(inputDay05Example1));
        //}

        //[TestMethod()]
        //public void Puzzle2Test()
        //{
        //    Assert.AreEqual(5312, Day05.Puzzle2(inputDay05));
        //}
    }
}