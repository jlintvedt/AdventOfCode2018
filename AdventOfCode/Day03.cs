using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{

    public static class Day03
    {
        // == == == == == Puzzle 1 == == == == ==
        public static int Puzzle1(string[] rawInput)
        {
            int[,] claimedFabric = new int[1000,1000];   // Not good, makes assumptions about the input
            int overlaps = 0;
            foreach (var claimString in rawInput)
            {
                var claim = new Claim(claimString);
                for (int x = claim.x; x < claim.x+claim.width; x++)
                {
                    for (int y = claim.y; y < claim.y+claim.height; y++)
                    {
                        if (++claimedFabric[x,y] == 2)
                        {
                            overlaps++;
                        }
                    }
                }
            }
            return overlaps;
        }

        public class Claim
        {
            public int ID;
            public int x, y;
            public int width, height;

            public Claim(string input)
            {
                var parts = input.Split('#','@',',',':',':','x');
                ID = int.Parse(parts[1]);
                x = int.Parse(parts[2]);
                y = int.Parse(parts[3]);
                width = int.Parse(parts[4]);
                height = int.Parse(parts[5]);
            }
        }


        // == == == == == Puzzle 2 == == == == ==
        public static int Puzzle2()
        {
            return 0;
        }
    }
}
