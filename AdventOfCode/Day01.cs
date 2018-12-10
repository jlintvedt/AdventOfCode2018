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
        public static int CalculateFrequency(int[] frequencyChanges)
        {
            return frequencyChanges.Sum();
        }

        public static int FindReccuringFrequency(int[] frequencyChanges)
        {
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
