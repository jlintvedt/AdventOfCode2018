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
        // == == == == == Common == == == == ==
        [TestMethod()]
        public void RecordInitializeTest()
        {
            var record = new Day04.Record("[1518-11-03 00:05] Guard #10 begins shift");
            Assert.AreEqual(new DateTime(1518, 11, 03, 00, 05, 00), record.Time);
            Assert.AreEqual(Day04.Record.RecordType.ShiftStart, record.Type);
            Assert.AreEqual(10, record.ID);
            // Fall Asleep
            Assert.AreEqual(Day04.Record.RecordType.FallAsleep, new Day04.Record("[1518-11-03 00:24] falls asleep").Type);
            // Wake up
            Assert.AreEqual(Day04.Record.RecordType.WakeUp, new Day04.Record("[1518-11-03 00:29] wakes up").Type);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RecordInvalidEventTest()
        {
            var record = new Day04.Record("[1518-11-03 00:05] Unknown event");
        }

        [TestMethod]
        public void ShiftInfoTest()
        {
            Day04.ShiftInfo shiftInfo = null;
            foreach (var rawRecord in inputDay04Example1)
            {
                var record = new Day04.Record(rawRecord);
                if (record.Type == Day04.Record.RecordType.ShiftStart)
                {
                    if (shiftInfo==null)
                    {
                        shiftInfo = new Day04.ShiftInfo(record);
                    } else
                    {
                        break;
                    }
                } else
                {
                    shiftInfo.AddRecord(record);
                }
            }
            shiftInfo.CalculateTimeAsleep();
            Assert.AreEqual(45, shiftInfo.MinutesAsleep);
            CollectionAssert.AreEqual(new bool[] {false,false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,false,false,false,false,false,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,false,false,false,false,false}, shiftInfo.IsAsleep);
        }

        // == == == == == Puzzle 1 == == == == ==
        [TestMethod()]
        public void Puzzle1ExampleTest()
        {
            Assert.AreEqual(240, Day04.Puzzle1(inputDay04Example1));
        }

        [TestMethod()]
        public void Puzzle1Test()
        {
            Assert.AreEqual(71748, Day04.Puzzle1(inputDay04));
        }

        // == == == == == Puzzle 2 == == == == ==
        [TestMethod()]
        public void Puzzle2ExampleTest()
        {
            Assert.AreEqual(4455, Day04.Puzzle2(inputDay04Example1));
        }

        [TestMethod()]
        public void Puzzle2Test()
        {
            Assert.AreEqual(106850, Day04.Puzzle2(inputDay04));
        }
    }
}