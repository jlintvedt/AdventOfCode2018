using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day05
    {
        public class AlchemicalReducer
        {
            private readonly byte[] units;

            public AlchemicalReducer(string polymer)
            {
                units = Encoding.ASCII.GetBytes(polymer);
            }

            public int Reduce()
            {
                byte[] unreacted = new byte[units.Length];
                int readLeft = -1, readRight = 0;
                do
                {
                    // Unreacted is empty, need to copy next unit over
                    if (readLeft < 0)
                    {
                        unreacted[++readLeft] = units[readRight++];
                    }
                    if (ShouldReact(unreacted[readLeft], units[readRight]))
                    {
                        readLeft--;
                        readRight++;
                    } else {
                        unreacted[++readLeft] = units[readRight++];
                    }
                } while (readRight < units.Length);
                // Need to add 1 as the read head is 1 lower than the length of unreacted units
                return readLeft+1;
            }

            private bool ShouldReact(byte a, byte b)
            {
                if (a+32 == b || a == b+32)
                {
                    return true;
                }
                return false;
            }
        }
        
        // == == == == == Puzzle 1 == == == == ==
        public static int Puzzle1(string input)
        {
            var ar = new AlchemicalReducer(input);
            return ar.Reduce();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static int Puzzle2(string input)
        {
            return 0;
        }
    }
}
