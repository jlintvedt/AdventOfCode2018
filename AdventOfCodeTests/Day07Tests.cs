using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public void SleightepCompareToTest()
        {
            var st0 = new Day07.SleighStep(2, 0, 0);
            var st1 = new Day07.SleighStep(2, 1, 0);
            var steps = new List<Day07.SleighStep>() { st0, st1 };
            Assert.AreEqual(st0.Index, steps.Min().Index);
            Assert.AreEqual(st1.Index, steps.Max().Index);
            // Ordering should not matter
            steps = new List<Day07.SleighStep>() { st1, st0 };
            Assert.AreEqual(st0.Index, steps.Min().Index);
            Assert.AreEqual(st1.Index, steps.Max().Index);
        }

        [TestMethod]
        public void SleighBuilderNumStepsTest()
        {
            var sb = new Day07.SleighBuilder(new (int, int)[] { (0, 1), (3, 1), (1, 2) });
            Assert.AreEqual(4, sb.NumSteps);
            sb = new Day07.SleighBuilder(new (int, int)[] { (0, 1), (0, 6), (4, 5) });
            Assert.AreEqual(7, sb.NumSteps);
        }

        [TestMethod]
        public void SleighBuilderIsBlockingTest()
        {
            var sb = new Day07.SleighBuilder(new (int, int)[] { (0, 1), (3, 1), (1, 2) });
            CollectionAssert.AreEqual(new int[] { 1 }, sb.steps[0].Blocking);
            CollectionAssert.AreEqual(new int[] { 2 }, sb.steps[1].Blocking);
        }


        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual("CABDFE", Day07.Puzzle1(inputDay07Example1));
        }

        // Runtime...
        [TestMethod]
        public void Puzzle1Test()
        {
            Assert.AreEqual("IJLFUVDACEHGRZPNKQWSBTMXOY", Day07.Puzzle1(inputDay07));
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            Assert.AreEqual(15, Day07.Puzzle2(inputDay07Example1, 0, 2));
        }

        // Runtime...
        [TestMethod]
        public void Puzzle2Test()
        {
            Assert.AreEqual(1072, Day07.Puzzle2(inputDay07, 60, 5));
        }
    }
}