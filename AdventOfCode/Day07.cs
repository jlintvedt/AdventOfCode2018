using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day07
    {
        public class SledgeStep
        {
            private bool[] BlockedBy;
            private bool[] BlockingOthers;
            public int NumBlockedBy;
            private int NumBlockingOthers;

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

            public SledgeStep(int uniqueSteps, int buildTime=0)
            {
                BlockedBy = new bool[uniqueSteps];
                BlockingOthers = new bool[uniqueSteps];
            }

            public void SetBlockedBy(int i)
            {
                BlockedBy[i] = true;
                NumBlockedBy++;
            }

            public bool RemoveBlockedBy(int i)
            {
                if (BlockedBy[i])
                {
                    BlockedBy[i] = false;
                    NumBlockedBy--;
                }
                return NumBlockedBy==0;
            }

            public void SetBlocking(int i)
            {
                BlockingOthers[i] = true;
                NumBlockingOthers++;
            }
        }

        public class SledgeBuilder
        {
            public int NumSteps;
            public SledgeStep[] steps;

            public SledgeBuilder((int blocker, int blocked)[] buildOrder)
            {
                NumSteps = buildOrder.Max(x => x.blocker > x.blocked ? x.blocker : x.blocked)+1;
                steps = new SledgeStep[NumSteps];
                for (int i = 0; i < NumSteps; i++)
                {
                    steps[i] = new SledgeStep(NumSteps);
                }
                // Create blocking reletionships
                foreach (var (blocker, blocked) in buildOrder)
                {
                    steps[blocker].SetBlocking(blocked);
                    steps[blocked].SetBlockedBy(blocker);
                }
            }

            public string GetCorrectBuildOrder()
            {
                var sb = new StringBuilder();
                var unblockedSteps = new List<int>();
                for (int i = 0; i < NumSteps; i++)
                {
                    if (steps[i].NumBlockedBy==0)
                    {
                        unblockedSteps.Add(i);
                    }
                }
                // Iterate until all steps have been found
                while (unblockedSteps.Count > 0)
                {
                    var i = unblockedSteps.Min();
                    foreach (var un in steps[i].Blocking)
                    {
                        if(steps[un].RemoveBlockedBy(i))
                        {
                            unblockedSteps.Add(un);
                        }
                    }
                    sb.Append(Common.IndexToLetter(i));
                    unblockedSteps.Remove(i);
                }

                return sb.ToString();
            }

            public int GetTotalConstructionTime(int numWorkers)
            {
                int totalBuildtime = 0;

                return totalBuildtime;
            }
        }

        public static string Puzzle1(string input)
        {
            var fromTo = Common.ParseCharSubstringTupleArray(input, 5, 36);
            // Convert steps to indicies, where A=0, B=1, etc
            var buildOrder = fromTo.Select(ab => (a: Common.LetterToIndex(ab.a), b: Common.LetterToIndex(ab.b))).ToArray();
            var sb = new SledgeBuilder(buildOrder);
            return sb.GetCorrectBuildOrder();
        }

        public static string Puzzle2(string input)
        {
            return "NYI";
        }
    }
}
