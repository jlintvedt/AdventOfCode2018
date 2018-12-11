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

            public int CheckNumberOfOverlaps(Claim claim)
            {
                var highestOverlap = 0;
                for (int x = claim.x; x < claim.x + claim.width; x++)
                {
                    for (int y = claim.y; y < claim.y + claim.height; y++)
                    {
                        if (area[x, y]>highestOverlap)
                        {
                            highestOverlap = area[x, y];
                        }
                    }
                }
                return highestOverlap;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static int Puzzle1(string[] rawInput)
        {
            var fabric = new Fabric(1000, 1000); // Don't like this. Makes assumptions about the input
            int overlaps = 0;
            foreach (var claimString in rawInput)
            {
                overlaps += fabric.AddClaim(new Claim(claimString));
            }
            return overlaps;
        }

        // == == == == == Puzzle 2 == == == == ==
        /// <summary>
        /// Finds the claim that does not overlap with anyone elses
        /// Another way to solve this one would be to store the parsed Claims objcts to avoid parsing twice
        /// But this would consume more memory. It's a tradeoff either way
        /// </summary>
        /// <param name="rawInput"></param>
        /// <returns>Returns the first claim that </returns>
        public static int Puzzle2(string[] rawInput)
        {
            var fabric = new Fabric(1000, 1000); // Don't like this. Makes assumptions about the input
            // First add all claims
            foreach (var claimString in rawInput)
            {
                fabric.AddClaim(new Claim(claimString));
            }
            // Then check if a claim is alone in it's area
            foreach (var claimString in rawInput)
            {
                var claim = new Claim(claimString);
                // If there exists only 1 claim in the same area, it only overlaps with itself
                if(fabric.CheckNumberOfOverlaps(new Claim(claimString)) == 1){
                    return claim.ID;
                }
            }
            throw new Exception("Could not find any claim that did not overlap");
        }
    }
}
