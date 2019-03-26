using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using AdventOfCodeTests;

namespace AdventOfCode.Tests
{
    [TestClass]
    public class Day13Tests
    {
        string inputDay13;
        string inputDay13Example1;
        string inputDay13Example2;

        [TestInitialize]
        public void TestInitialize()
        {
            inputDay13 = InputData.ResourceManager.GetObject("D13_Puzzle").ToString();
            inputDay13Example1 = InputData.ResourceManager.GetObject("D13_E1").ToString();
            inputDay13Example2 = InputData.ResourceManager.GetObject("D13_E2").ToString();
        }
        // == == == == == Common == == == == ==
        [TestMethod]
        public void CartTurningTest()
        {
            var cart = new Day13.Cart(Day13.Directions.south, 0, 0);
            // Clockwise
            cart.TurnRight();
            Assert.AreEqual(Day13.Directions.west, cart.Direction);
            cart.TurnRight();
            Assert.AreEqual(Day13.Directions.north, cart.Direction);
            cart.TurnRight();
            Assert.AreEqual(Day13.Directions.east, cart.Direction);
            // Counter-clockwise
            cart.TurnLeft();
            Assert.AreEqual(Day13.Directions.north, cart.Direction);
            cart.TurnLeft();
            Assert.AreEqual(Day13.Directions.west, cart.Direction);
            cart.TurnLeft();
            Assert.AreEqual(Day13.Directions.south, cart.Direction);
        }

        [TestMethod]
        public void CartMovingTest()
        {
            // Track
            //   0123456789
            // 0 >-\    /\ 
            // 1   +-++ |+-
            // 2      \-/  
            var cart = new Day13.Cart(Day13.Directions.east, 0, 0);
            var tracks = new Day13.Track[] {
                Day13.Track.horizontal,
                Day13.Track.curveBackward,
                Day13.Track.intersection,
                Day13.Track.horizontal,
                Day13.Track.intersection,
                Day13.Track.intersection,
                Day13.Track.curveBackward,
                Day13.Track.horizontal,
                Day13.Track.curveForward,
                Day13.Track.vertical,
                Day13.Track.curveForward,
                Day13.Track.curveBackward,
                Day13.Track.intersection,
                Day13.Track.horizontal };
            var expectedX = new int[] { 1, 2, 2, 3, 4, 5, 5, 6, 7, 7, 7, 8, 8, 9 };
            var expectedY = new int[] { 0, 0, 1, 1, 1, 1, 2, 2, 2, 1, 0, 0, 1, 1 };
            for (int i = 0; i < tracks.Length; i++)
            {
                cart.Move(tracks[i]);
                Assert.AreEqual(expectedX[i], cart.X);
                Assert.AreEqual(expectedY[i], cart.Y);
            }
        }

        [TestMethod]
        public void TrackSystemInitializeTest()
        {
            var ts = new Day13.TrackSystem(new string[] {
                 "/-\\",
                 "| |",
                 "| v",
                "\\-/" });
            Assert.AreEqual(10, ts.NumTracks);
            Assert.AreEqual(1, ts.NumCarts);
        }

        [TestMethod]
        public void TrackSystemMoveTest()
        {
            var ts = new Day13.TrackSystem(new string[] { "->--<-" });
            // Just make sure the system does not crash
            ts.NextTick(out string crashCoordinate);
            Assert.AreEqual("", crashCoordinate);
        }

        [TestMethod]
        public void TrackSystemCrashTest()
        {
            var ts = new Day13.TrackSystem(new string[] {
                "     v",
                "/----/",
                "^     "});
            string crashCoordinate;
            ts.NextTick(out crashCoordinate);
            Assert.AreEqual("", crashCoordinate);
            ts.NextTick(out crashCoordinate);
            Assert.AreEqual("", crashCoordinate);
            ts.NextTick(out crashCoordinate);
            Assert.AreEqual("", crashCoordinate);
            // Crash should happen in 3,1 eventhough 5,0 is the very first cart to move
            ts.NextTick(out crashCoordinate);
            Assert.AreEqual("3,1", crashCoordinate);
        }

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod]
        public void Puzzle1ExampleTest()
        {
            var crashSpace = Day13.Puzzle1(inputDay13Example1);
            Assert.AreEqual("7,3", crashSpace);
        }

        // Runtime on Surface Book 2 i7: <1 ms
        [TestMethod]
        public void Puzzle1Test()
        {
            var crashSpace = Day13.Puzzle1(inputDay13);
            Assert.AreEqual("80,100", crashSpace);
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod]
        public void Puzzle2ExampleTest()
        {
            var crashSpace = Day13.Puzzle2(inputDay13Example2);
            Assert.AreEqual("6,4", crashSpace);
        }

        // Runtime on Surface Book 2 i7: 17 ms
        [TestMethod]
        public void Puzzle2Test()
        {
            var crashSpace = Day13.Puzzle2(inputDay13);
            Assert.AreEqual("16,99", crashSpace);
        }
    }
}