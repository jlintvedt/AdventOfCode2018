using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day04
    {
        // == == == == == Common == == == == ==
        public class Record
        {
            public enum RecordType
            {
                ShiftStart,
                FallAsleep,
                WakeUp
            }

            public readonly DateTime Time;
            public readonly RecordType Type;
            public readonly int ID;

            public Record(string input)
            {
                var parts = input.Split('[', ']');
                Time = DateTime.Parse(parts[1]);
                var typeInput = parts[2];
                if (typeInput.StartsWith(" Guard")){
                    Type = RecordType.ShiftStart;
                    ID = Int32.Parse(typeInput.Split('#', ' ')[3]);
                } else if (typeInput.StartsWith(" falls")){
                    Type = RecordType.FallAsleep;
                } else if (typeInput.StartsWith(" wakes")){
                    Type = RecordType.WakeUp;
                } else{
                    throw new ArgumentException($"Invalid input string: Unknown event {typeInput}");
                }
            }
        }

        public class ShiftInfo
        {
            public int ID;
            public DateTime Date;
            public readonly bool[] IsAsleep = new bool[60];
            public int MinutesAsleep;
            private List<Record> records;

            public ShiftInfo(Record record)
            {
                if (record.Type != Record.RecordType.ShiftStart)
                {
                    throw new ArgumentException("Must be initialized with record of type ShiftStart");
                }
                ID = record.ID;
                Date = record.Time.Hour == 0 ? record.Time.Date : record.Time.AddDays(1).Date;
                records = new List<Record>();
            }

            public void AddRecord(Record record)
            {
                if (records.Count%2==0 && record.Type!=Record.RecordType.FallAsleep)
                {
                    throw new ArgumentException("Can't have 2 FallingAsleep events after eachother");
                } else if (records.Count % 2 == 1 && record.Type != Record.RecordType.WakeUp)
                {
                    throw new ArgumentException("WakeUp records must be preceeded by FallingAsleep event");
                }
                records.Add(record);
            }

            public int CalculateTimeAsleep()
            {
                if (records.Count%2 != 0)
                {
                    throw new Exception("Invalid ShiftInfo, uneven amount of Records. Meaning fallingAsleep is not followed by wakingUp");
                }

                var pos = 0;
                foreach (var record in records)
                {
                    if (record.Type == Record.RecordType.FallAsleep)
                    {
                        pos = record.Time.Minute;
                    }
                    else
                    {
                        for (; pos < record.Time.Minute; pos++)
                        {
                            IsAsleep[pos] = true;
                            MinutesAsleep++;
                        }
                    }
                }
                return MinutesAsleep;
            }
        }

        public class GuardStats
        {
            public int ID;
            private List<ShiftInfo> shifts;

            public int MinutesAsleep
            {
                get
                {
                    int min = 0;
                    foreach (var shift in shifts)
                    {
                        min += shift.CalculateTimeAsleep();
                    }
                    return min;
                }
            }

            public GuardStats()
            {
                shifts = new List<ShiftInfo>();
            }

            public void AddShift(ShiftInfo si)
            {
                shifts.Add(si);
            }

            public int FindSleepiestMinute(out int mostTimesAsleep)
            {
                var timesAsleep = new int[60];
                foreach (var shift in shifts)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        timesAsleep[i] += shift.IsAsleep[i]?1:0;
                    }
                }
                mostTimesAsleep = timesAsleep.Max();
                return Array.IndexOf(timesAsleep, mostTimesAsleep);
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static int Puzzle1(string input)
        {
            var records = new List<Record>();
            // Parse input
            foreach (var rawRecord in Common.ParseStringArray(input))
            {
                var record = new Record(rawRecord);
                records.Add(record);
            }
            records.Sort((x, y) => x.Time.CompareTo(y.Time));
            // Create ShiftInfos
            var guardStats = new Dictionary<int, GuardStats>();
            GuardStats gs;
            ShiftInfo si = null;
            foreach (var record in records)
            {
                // Shift Start
                if (record.Type == Record.RecordType.ShiftStart)
                {
                    // Next guard
                    si = new ShiftInfo(record);
                    if (guardStats.TryGetValue(record.ID, out gs))
                    {
                        gs.AddShift(si);
                    } else
                    {
                        gs = new GuardStats();
                        gs.ID = si.ID;
                        gs.AddShift(si);
                        guardStats.Add(gs.ID, gs);
                    }
                }
                // FallAsleep / WakeUp
                else 
                {
                    si.AddRecord(record);
                }
            }
            // Find sleepiest guard
            int maxAsleepMin = 0, maxAsleepID = 0;
            foreach (var guard in guardStats)
            {
                var minSleep = guard.Value.MinutesAsleep;
                if (minSleep > maxAsleepMin)
                {
                    maxAsleepMin = minSleep;
                    maxAsleepID = guard.Value.ID;
                }
            }

            return guardStats[maxAsleepID].FindSleepiestMinute(out int noNeed) * maxAsleepID;
        }

        // == == == == == Puzzle 2 == == == == ==
        public static int Puzzle2(string input)
        {
            // CopyPaste from Puzzle 1
            var records = new List<Record>();
            // Parse input
            foreach (var rawRecord in Common.ParseStringArray(input))
            {
                var record = new Record(rawRecord);
                records.Add(record);
            }
            records.Sort((x, y) => x.Time.CompareTo(y.Time));
            // Create ShiftInfos
            var guardStats = new Dictionary<int, GuardStats>();
            GuardStats gs;
            ShiftInfo si = null;
            foreach (var record in records)
            {
                // Shift Start
                if (record.Type == Record.RecordType.ShiftStart)
                {
                    // Next guard
                    si = new ShiftInfo(record);
                    if (guardStats.TryGetValue(record.ID, out gs))
                    {
                        gs.AddShift(si);
                    }
                    else
                    {
                        gs = new GuardStats();
                        gs.ID = si.ID;
                        gs.AddShift(si);
                        guardStats.Add(gs.ID, gs);
                    }
                }
                // FallAsleep / WakeUp
                else
                {
                    si.AddRecord(record);
                }
            }

            // Puzzle 2 modifications
            int asleepTimesMax = 0, asleepMinuteMax = 0, asleepIDMax = 0;   // Max values
            int asleepTimes, asleepMinute;
            foreach (var guard in guardStats)
            {
                // Need to get this value to populate array on Shift objects
                // Should be rewritten to calculate all stats on GuardStats class, then access as variables
                var noNeed = guard.Value.MinutesAsleep;  

                asleepMinute = guard.Value.FindSleepiestMinute(out asleepTimes);
                if (asleepTimes > asleepTimesMax)
                {
                    asleepTimesMax = asleepTimes;
                    asleepMinuteMax = asleepMinute;
                    asleepIDMax = guard.Value.ID;
                }
            }
            return asleepMinuteMax * asleepIDMax;
        }
    }
}
