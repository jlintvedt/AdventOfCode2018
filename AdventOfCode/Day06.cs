using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day06
    {
        public struct Coordinate
        {
            public readonly int x;
            public readonly int y;

            public Coordinate(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public class ChronalMapper
        {
            public Coordinate[] KnownCoordinates;
            public int[,] MappedSpace; // Contains ID of closest node
            public int sizeX, sizeY;

            public ChronalMapper((int x,int y)[] coordinates)
            {
                sizeX = coordinates.Max(cord => cord.x)+1;
                sizeY = coordinates.Max(cord => cord.y)+1;

                KnownCoordinates = new Coordinate[coordinates.Length];
                MappedSpace = new int[sizeX, sizeY];

                // First map known coordinates
                for (int i = 0; i < coordinates.Length; i++)
                {
                    KnownCoordinates[i] = new Coordinate(coordinates[i].x, coordinates[i].y);
                }
                // Then map the remaining space
                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        MappedSpace[x, y] = FindClosestNode(x, y);
                    }
                }
                return;
            }

            private int FindClosestNode(int x, int y)
            {
                var distances = new List<int>();
                Coordinate cord;
                for (int i = 0; i < KnownCoordinates.Length; i++)
                {
                    cord = KnownCoordinates[i];
                    distances.Add(Math.Abs(x - cord.x) + Math.Abs(y - cord.y));
                }
                var minDist = distances.Min();
                int index = distances.IndexOf(minDist);
                if (distances.IndexOf(minDist, index+1) != -1)
                {
                    // Multiple nodes at minimum distance
                    return -1;
                }
                // Only one node at minimum distance
                return index;
            }
        }
        
        public static int Puzzle1(string input)
        {
            var knownCoordinates = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Split(new[] { "," }, StringSplitOptions.None))
                .Select(xy => xy.Select(i => Convert.ToInt32(i)).ToArray())
                .Select(xy => (x: xy[0], y: xy[1])).ToArray();

            var cm = new ChronalMapper(knownCoordinates);

            // Find largest safe space
            var area = new int[knownCoordinates.Length];
            foreach (var node in cm.MappedSpace)
            {
                if (node >= 0)
                {
                    area[node]++;
                }
            }
            // Exclude all knownCoordinates that reaches the edge
            for (int x = 0; x < cm.sizeX; x++)
            {
                // First + last column
                if (x == 0 || x == cm.sizeX-1)
                {
                    for (int y = 0; y < cm.sizeY; y++)
                    {
                        if (cm.MappedSpace[x, y] != -1)
                        {
                            area[cm.MappedSpace[x, y]] = 0;
                        }
                        
                    }
                } else {
                    // Columns inbetween
                    if (cm.MappedSpace[x, 0] != -1)
                    {
                        area[cm.MappedSpace[x, 0]] = 0;
                    }
                    if (cm.MappedSpace[x, cm.sizeY-1] != -1)
                    {
                        area[cm.MappedSpace[x, cm.sizeY-1]] = 0;
                    }
                }
            }

            return area.Max();
        }
    }
}
