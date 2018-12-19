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
                    // First make sure unreacted is not empty, then check for reaction
                    if (readLeft>=0 && ShouldReact(unreacted[readLeft], units[readRight]))
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

            public int ReduceWithSkip(char skipUnit)
            {
                byte[] unreacted = new byte[units.Length];
                int readLeft = -1, readRight = 0;
                byte skipUpper = (byte)skipUnit;
                byte skipLower = (byte)(skipUpper + 32);

                do
                {
                    // Check if next unit should be skipped
                    if ((units[readRight] == skipUpper || units[readRight] == skipLower))
                    {
                        readRight++;
                        continue;
                    }
                    // First make sure unreacted is not empty, then check for reaction
                    if (readLeft >= 0 && ShouldReact(unreacted[readLeft], units[readRight]))
                    {
                        readLeft--;
                        readRight++;
                    }
                    else
                    {
                        unreacted[++readLeft] = units[readRight++];
                    }
                } while (readRight < units.Length);

                // Need to add 1 as the read head is 1 lower than the length of unreacted units
                return readLeft + 1;
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
            var ar = new AlchemicalReducer(input);
            int shortestPolymer = input.Length;
            foreach (var unit in "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray())
            {
                var reducedLength = ar.ReduceWithSkip(unit);
                shortestPolymer = shortestPolymer > reducedLength ? reducedLength : shortestPolymer;
            }
            return shortestPolymer;
        }
    }
}
