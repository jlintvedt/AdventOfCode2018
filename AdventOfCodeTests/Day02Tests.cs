using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day02Tests
    {
        string inputDay02;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay02 = InputData.ResourceManager.GetObject("D02_Puzzle").ToString();
        }

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            var checksum = Day02.Puzzle1(InputData.ResourceManager.GetObject("D02_E1").ToString().Replace(",", Environment.NewLine));
            Assert.AreEqual(12, checksum);
        }

        // Runtime on Surface Book 2 i7: <1 ms
        [TestMethod]
        public void Puzzle1Test()
        {
            var checksum = Day02.Puzzle1(inputDay02);
            Assert.AreEqual(8610, checksum);
        }

        [TestMethod]
        public void FindDoublesAndTriplesTest()
        {
            var boxIDs = Common.ParseStringArray(InputData.ResourceManager.GetObject("D02_E1").ToString().Replace(",", Environment.NewLine));
            Assert.AreEqual(7, boxIDs.Length);
            var expectedDoubles = new int[] { 0, 1, 1, 0, 1, 1, 0 };
            var expectedTriples = new int[] { 0, 1, 0, 1, 0, 0, 1 };

            int doubles, triples;
            for (int i = 0; i < 7; i++)
            {
                Day02.FindDoublesAndTriples(boxIDs[i], out doubles, out triples);
                Assert.AreEqual(expectedDoubles[i], doubles);
                Assert.AreEqual(expectedTriples[i], triples);
            }
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            var commonCharacters = Day02.Puzzle2(InputData.ResourceManager.GetObject("D02_E2").ToString().Replace(",", Environment.NewLine));
            Assert.AreEqual("fgij", commonCharacters);
        }

        // Runtime on Surface Book 2 i7: 1 ms
        [TestMethod]
        public void Puzzle2Test()
        {
            var commonCharacters = Day02.Puzzle2(inputDay02);
            Assert.AreEqual("iosnxmfkpabcjpdywvrtahluy", commonCharacters);
        }

        [TestMethod]
        public void FindNumDifferentCharactersTest()
        {
            Assert.AreEqual(0, Day02.FindNumDifferentCharacters("abcdef", "abcdef"));
            Assert.AreEqual(1, Day02.FindNumDifferentCharacters("abcdef", "Xbcdef"));
            Assert.AreEqual(1, Day02.FindNumDifferentCharacters("abcdef", "abcdeX"));
            Assert.AreEqual(2, Day02.FindNumDifferentCharacters("abcdef", "abcdXX"));
        }

        [TestMethod]
        public void FindCommonCharactersTest()
        {
            Assert.AreEqual("abcefg", Day02.FindCommonCharacters("abcdefg", "abcXefg"));
            Assert.AreEqual("cde", Day02.FindCommonCharacters("abcdefg", "XXcdeXX"));
        }
    }
}