using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventOfCode;
using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass()]
    public class Day02Tests
    {
        // == == == == == Puzzle 1 == == == == ==
        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            var checksum = Day02.Puzzle1(Helper.LoadResourceStringArray("D02_E1", ","));
            Assert.AreEqual(12, checksum);
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            var checksum = Day02.Puzzle1(Helper.LoadResourceStringArray("D02_P1", Environment.NewLine));
            Assert.AreEqual(8610, checksum);
        }

        [TestMethod()]
        public void FindDoublesAndTriplesTest()
        {
            var boxIDs = Helper.LoadResourceStringArray("D02_E1", ",");
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
        [TestMethod()]
        public void Puzzle2ExampleTest()
        {
            var commonCharacters = Day02.Puzzle2(Helper.LoadResourceStringArray("D02_E2", ","));
            Assert.AreEqual("fgij", commonCharacters);
        }

        [TestMethod()]
        public void Puzzle2Test()
        {
            var commonCharacters = Day02.Puzzle2(Helper.LoadResourceStringArray("D02_P1", Environment.NewLine));
            Assert.AreEqual("iosnxmfkpabcjpdywvrtahluy", commonCharacters);
        }

        [TestMethod()]
        public void FindNumDifferentCharactersTest()
        {
            Assert.AreEqual(0, Day02.FindNumDifferentCharacters("abcdef", "abcdef"));
            Assert.AreEqual(1, Day02.FindNumDifferentCharacters("abcdef", "Xbcdef"));
            Assert.AreEqual(1, Day02.FindNumDifferentCharacters("abcdef", "abcdeX"));
            Assert.AreEqual(2, Day02.FindNumDifferentCharacters("abcdef", "abcdXX"));
        }

        [TestMethod()]
        public void FindCommonCharactersTest()
        {
            Assert.AreEqual("abcefg", Day02.FindCommonCharacters("abcdefg","abcXefg"));
            Assert.AreEqual("cde", Day02.FindCommonCharacters("abcdefg", "XXcdeXX"));
        }
    }
}