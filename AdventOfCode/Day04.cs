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
            public DateTime ShiftStart, FallsAsleep, WakesUp;
            private int minutesAsleep;

            public ShiftInfo() {}

            public ShiftInfo(Record record)
            {
                AddRecord(record);
            }

            public int MinutesAsleep
            {
                get
                {
                    if (minutesAsleep != 0){
                        return minutesAsleep;
                    }
                    // Validate
                    if (ShiftStart == null || FallsAsleep == null || WakesUp == null){
                        throw new Exception("Need to add all record types to calculate value");
                    }
                    minutesAsleep = (WakesUp - FallsAsleep).Minutes;
                    return minutesAsleep;
                }
            }

            public void AddRecord(Record record)
            {
                switch (record.Type) {
                    case Record.RecordType.ShiftStart:
                        ID = record.ID;
                        ShiftStart = record.Time;
                        break;
                    case Record.RecordType.FallAsleep:
                        FallsAsleep = record.Time;
                        break;
                    case Record.RecordType.WakeUp:
                        WakesUp = record.Time;
                        break;
                    default:
                        break;
                }
            }
        }

        public class ShiftCalendar
        {
            private readonly Dictionary<DateTime, ShiftInfo> shifts;
            private readonly Dictionary<int, List<DateTime>> guardWorkingDays;

            public List<DateTime> DaysWithShifts
            {
                get
                {
                    var daysWithShifts = shifts.Keys.ToList();
                    daysWithShifts.Sort();
                    return daysWithShifts;
                }
            }

            public List<int> GuardIDs
            {
                get
                {
                    var IDs = guardWorkingDays.Keys.ToList();
                    IDs.Sort();
                    return IDs;

                }
            }

            public ShiftCalendar()
            {
                shifts = new Dictionary<DateTime, ShiftInfo>();
                guardWorkingDays = new Dictionary<int, List<DateTime>>();
            }

            public void AddRecord(Record record)
            {
                // Some start their shift just before midnight, so we need to adjust the Date to reflect this
                var adjustedDate = record.Time.Hour <= 0 ? record.Time.Date : (record.Time.AddDays(1).Date);
                // Save new info to record
                if (shifts.TryGetValue(adjustedDate, out ShiftInfo shift))
                {
                    shift.AddRecord(record);
                } else
                {
                    shifts.Add(adjustedDate, new ShiftInfo(record));
                }
                // Add Guard ID to seperate list
                if (record.Type == Record.RecordType.ShiftStart)
                {
                    if (guardWorkingDays.TryGetValue(record.ID, out List<DateTime> shiftDates))
                    {
                        shiftDates.Add(adjustedDate);
                    }
                    else
                    {
                        guardWorkingDays.Add(record.ID, new List<DateTime>() { adjustedDate });
                    }
                }
            }

            public List<ShiftInfo>GetShiftsForGuard(int guardID)
            {
                if (guardWorkingDays.TryGetValue(guardID, out List<DateTime> shiftDates))
                {
                    shiftDates.Sort();
                    List<ShiftInfo> shifts = new List<ShiftInfo>();
                    foreach (var date in shiftDates)
                    {
                        shifts.Add(GetShift(date));
                    }
                    return shifts;
                } else
                {
                    throw new ArgumentException("Invalid GuardID, no shifts registered");
                }
            }

            public ShiftInfo GetShift(DateTime date)
            {
                if (shifts.TryGetValue(date, out ShiftInfo shift))
                {
                    return shift;
                } else
                {
                    throw new ArgumentException("Shift date does not exist");
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static int Puzzle1(string[] input)
        {
            var calendar = new ShiftCalendar();
            foreach (var rawRecord in input)
            {
                calendar.AddRecord(new Record(rawRecord));
            }
            return 0;
        }

        // == == == == == Puzzle 2 == == == == ==
        public static int Puzzle2(string[] input)
        {
            return 0;
        }
    }
}
