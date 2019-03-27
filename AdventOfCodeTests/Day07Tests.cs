using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day07Tests
    {
        string inputDay07;
        string inputDay07Example1;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay07 = InputData.ResourceManager.GetObject("D07_Puzzle").ToString();
            inputDay07Example1 = InputData.ResourceManager.GetObject("D07_E1").ToString();
        }

        // == == == == == Common == == == == ==
        [TestMethod]
        public void SledgeBuilderNumStepsTest()
        {
            var sb = new Day07.SledgeBuilder(new (int, int)[] { (0, 1), (3, 1), (1, 2) });
            Assert.AreEqual(4, sb.NumSteps);
            sb = new Day07.SledgeBuilder(new (int, int)[] { (0, 1), (0, 6), (4, 5) });
            Assert.AreEqual(7, sb.NumSteps);
        }

        [TestMethod]
        public void SledgeBuilderIsBlockingTest()
        {
            var sb = new Day07.SledgeBuilder(new (int, int)[] { (0, 1), (3, 1), (1, 2) });
            CollectionAssert.AreEqual(new int[] { 1 }, sb.steps[0].Blocking);
            CollectionAssert.AreEqual(new int[] { 2 }, sb.steps[1].Blocking);

        }


        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual("CABDFE", Day07.Puzzle1(inputDay07Example1));
        }

        [TestMethod]
        public void Puzzle1Test()
        {
            Assert.AreEqual("IJLFUVDACEHGRZPNKQWSBTMXOY", Day07.Puzzle1(inputDay07));
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            Assert.AreEqual("ABC", Day07.Puzzle2(inputDay07Example1));
        }

        [TestMethod]
        public void Puzzle2Test()
        {
            Assert.AreEqual("ABC", Day07.Puzzle2(inputDay07));
        }
    }
}