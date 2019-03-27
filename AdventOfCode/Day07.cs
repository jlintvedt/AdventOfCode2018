using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day07
    {
        public class SleighStep : IComparable
        {
            public int Index;
            private bool[] BlockedBy;
            private bool[] BlockingOthers;
            private int numBlockedBy;
            private int NumBlockingOthers;
            private int remainingBuildTime;

            public bool IsUnBlocked { get { return numBlockedBy == 0; } }
            public int[] Blocking
            {
                get
                {
                    var b = new int[NumBlockingOthers];
                    int index = 0;
                    for (int i = 0; i < BlockingOthers.Length; i++)
                    {
                        if (BlockingOthers[i])
                        {
                            b[index++] = i;
                        }
                    }
                    return b;
                }
            }

            public SleighStep(int uniqueSteps, int index, int buildTime)
            {
                Index = index;
                BlockedBy = new bool[uniqueSteps];
                BlockingOthers = new bool[uniqueSteps];
                remainingBuildTime = buildTime;
            }

            public void SetBlockedBy(int i)
            {
                BlockedBy[i] = true;
                numBlockedBy++;
            }

            public bool RemoveBlockedBy(int i)
            {
                if (BlockedBy[i])
                {
                    BlockedBy[i] = false;
                    numBlockedBy--;
                }
                return numBlockedBy==0;
            }

            public void SetBlocking(int i)
            {
                BlockingOthers[i] = true;
                NumBlockingOthers++;
            }

            public bool PerformConstruction()
            {
                remainingBuildTime--;
                return remainingBuildTime == 0;
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                SleighStep otherStep = obj as SleighStep;
                return Index - otherStep.Index;
            }
        }

        public class SleighBuilder
        {
            public int NumSteps;
            public SleighStep[] steps;
            public List<SleighStep> availableSteps;

            public SleighBuilder((int blocker, int blocked)[] buildOrder, int baseBuildTime=0)
            {
                NumSteps = buildOrder.Max(x => x.blocker > x.blocked ? x.blocker : x.blocked)+1;
                steps = new SleighStep[NumSteps];
                for (int i = 0; i < NumSteps; i++)
                {
                    steps[i] = new SleighStep(NumSteps, i, baseBuildTime+i+1);
                }
                // Create blocking reletionships
                foreach (var (blocker, blocked) in buildOrder)
                {
                    steps[blocker].SetBlocking(blocked);
                    steps[blocked].SetBlockedBy(blocker);
                }
                // Find unblocked steps
                availableSteps = steps.Where(s => s.IsUnBlocked).ToList();
            }

            public string GetCorrectBuildOrder()
            {
                var sb = new StringBuilder();
                
                while (availableSteps.Count > 0)
                {
                    SleighStep s = availableSteps.Min();
                    CompleteStep(s);
                    sb.Append(Common.IndexToLetter(s.Index));
                    availableSteps.Remove(s);
                }

                return sb.ToString();
            }

            public int GetTotalConstructionTime(int numWorkers)
            {
                int totalBuildtime = 0;
                int idleWorkers = numWorkers;
                var activeSteps = new List<SleighStep>();
                var recentlyCompleted = new List<SleighStep>();
                int remainingSteps = NumSteps;

                // Build Sleigh
                while (remainingSteps>0)
                {
                    // Assign work to idle workers
                    while (idleWorkers>0 && availableSteps.Count>0)
                    {
                        var step = availableSteps.Min();
                        activeSteps.Add(step);
                        availableSteps.Remove(step);
                        idleWorkers--;
                    }
                    // Perform work on active steps
                    foreach (var step in activeSteps)
                    {
                        if (step.PerformConstruction())
                        {
                            // Work is complete, queue for completion
                            recentlyCompleted.Add(step);
                        }
                    }
                    foreach (var step in recentlyCompleted)
                    {
                        CompleteStep(step);
                        activeSteps.Remove(step);
                        remainingSteps--;
                        idleWorkers++;
                    }
                    recentlyCompleted.Clear();

                    totalBuildtime++;
                }

                return totalBuildtime;
            }

            private void CompleteStep(SleighStep s)
            {
                foreach (var unblock in s.Blocking)
                {
                    if (steps[unblock].RemoveBlockedBy(s.Index))
                    {
                        availableSteps.Add(steps[unblock]);
                    }
                }
            }
        }

        public static string Puzzle1(string input)
        {
            // Convert to steps representex by index, A=0, B=1 etc.
            var fromTo = Common.ParseCharSubstringTupleArray(input, 5, 36);
            var buildOrder = fromTo.Select(ab => (a: Common.LetterToIndex(ab.a), b: Common.LetterToIndex(ab.b))).ToArray();

            var sb = new SleighBuilder(buildOrder);
            return sb.GetCorrectBuildOrder();
        }

        public static int Puzzle2(string input, int baseBuildTime, int numWorkers)
        {
            // Convert to steps representex by index, A=0, B=1 etc.
            var fromTo = Common.ParseCharSubstringTupleArray(input, 5, 36);
            var buildOrder = fromTo.Select(ab => (a: Common.LetterToIndex(ab.a), b: Common.LetterToIndex(ab.b))).ToArray();

            var sb = new SleighBuilder(buildOrder, baseBuildTime);
            return sb.GetTotalConstructionTime(numWorkers);
        }
    }
}
