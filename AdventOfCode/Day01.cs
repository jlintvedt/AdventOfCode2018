using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2018/day/1
    /// </summary>
    public static class Day01
    {
        // == == == == == Puzzle 1 == == == == ==
        public static int Puzzle1(string input)
        {
            var frequencyChanges = Common.ParseIntArray(input);
            return frequencyChanges.Sum();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static int Puzzle2(string input)
        {
            var frequencyChanges = Common.ParseIntArray(input);
            int currentFrequency = 0;
            var previousFrequencies = new HashSet<int>();
            while (true)
            {
                for (int i = 0; i < frequencyChanges.Length; i++)
                {
                    if (previousFrequencies.Contains(currentFrequency))
                    {
                        return currentFrequency;
                    }
                    previousFrequencies.Add(currentFrequency);
                    currentFrequency += frequencyChanges[i];
                }
            }
        }
    }
}
