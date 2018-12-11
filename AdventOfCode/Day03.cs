using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{

    public static class Day03
    {
        // == == == == == Common == == == == ==
        public class Claim
        {
            public int ID;
            public int x, y;
            public int width, height;

            public Claim(string input)
            {
                var parts = input.Split('#', '@', ',', ':', ':', 'x');
                ID = int.Parse(parts[1]);
                x = int.Parse(parts[2]);
                y = int.Parse(parts[3]);
                width = int.Parse(parts[4]);
                height = int.Parse(parts[5]);
            }
        }

        public class Fabric
        {
            private int[,] area;

            public Fabric(int width, int height)
            {
                area = new int[width, height];
            }

            public int AddClaim(Claim claim)
            {
                int overlaps = 0;
                for (int x = claim.x; x < claim.x + claim.width; x++)
                {
                    for (int y = claim.y; y < claim.y + claim.height; y++)
                    {
                        if (++area[x, y] == 2)
                        {
                            overlaps++;
                        }
                    }
                }
                return overlaps;
            }
        }

        
        public static int Puzzle1(string[] rawInput)
        {
            var fabric = new Fabric(1000, 1000); // Don't like this. Makes assumptions about the input
            int overlaps = 0;
            foreach (var claimString in rawInput)
            {
                var claim = new Claim(claimString);
                overlaps += fabric.AddClaim(claim);
            }
            return overlaps;
        }

        // == == == == == Puzzle 2 == == == == ==
        public static int Puzzle2()
        {
            return 0;
        }
    }
}
