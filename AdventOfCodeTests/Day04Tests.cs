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
        public void ShiftCalendarTest()
        {
            var calendar = new Day04.ShiftCalendar();
            foreach (var rawRecord in inputDay04Example1)
            {
                calendar.AddRecord(new Day04.Record(rawRecord));
            }
            var guardIDs = calendar.GuardIDs;
            // Should have guard #10 and #99
            CollectionAssert.AreEqual(new List<int>() { 10, 99 }, guardIDs);
            // Guard #10 Should have 2 shifts
            var shifts = calendar.GetShiftsForGuard(10);
            Assert.AreEqual(2, shifts.Count);
            Assert.AreEqual(new DateTime(1518, 11, 1), shifts.First().ShiftStart.Date);
            Assert.AreEqual(new DateTime(1518, 11, 3), shifts.Last().ShiftStart.Date);
            // Guard #99 should have 3 shifts
            Assert.AreEqual(3, calendar.GetShiftsForGuard(99).Count);
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
            Assert.Fail();
        }

        // == == == == == Puzzle 2 == == == == ==
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