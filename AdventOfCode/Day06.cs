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

                // First map known coordinates
                for (int i = 0; i < coordinates.Length; i++)
                {
                    KnownCoordinates[i] = new Coordinate(coordinates[i].x, coordinates[i].y);
                }
            }

            public void MapSpace()
            {
                MappedSpace = new int[sizeX, sizeY];
                // Then map the remaining space
                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        MappedSpace[x, y] = FindClosestNode(x, y);
                    }
                }
            }

            private int FindClosestNode(int x, int y)
            {
                Coordinate cord;
                int shortestDist = sizeX+sizeY;
                int shortestIndex = -1;
                for (int i = 0; i < KnownCoordinates.Length; i++)
                {
                    cord = KnownCoordinates[i];
                    int dist = Math.Abs(x - cord.x) + Math.Abs(y - cord.y);
                    // Check if it is shorter than previous distances
                    if (dist < shortestDist)
                    {
                        shortestDist = dist;
                        shortestIndex = i;
                    }
                    else if (dist == shortestDist)
                    {
                        // No longer uniquely shortest
                        shortestIndex = -1;
                    }
                }
                return shortestIndex;
            }

            public int FindLargestSafeSpace(int totalDistance)
            {
                int nodesWithinSafeDistance = 0;
                // Check every node if within safe distance
                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        // Node selected, determine if safe
                        int dist = 0;
                        foreach (var cord in KnownCoordinates)
                        {
                            dist += Math.Abs(x - cord.x) + Math.Abs(y - cord.y);
                            if (dist>=totalDistance)
                            {
                                break;
                            }
                        }
                        if (dist < totalDistance)
                        {
                            nodesWithinSafeDistance++;
                        }
                    }
                }

                return nodesWithinSafeDistance;
            }
        }
        
        public static int Puzzle1(string input)
        {
            var knownCoordinates = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Split(new[] { "," }, StringSplitOptions.None))
                .Select(xy => xy.Select(i => Convert.ToInt32(i)).ToArray())
                .Select(xy => (x: xy[0], y: xy[1])).ToArray();

            var cm = new ChronalMapper(knownCoordinates);
            cm.MapSpace();

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

        public static int Puzzle2(string input, int totalDistance)
        {
            var knownCoordinates = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                .Select(line => line.Split(new[] { "," }, StringSplitOptions.None))
                .Select(xy => xy.Select(i => Convert.ToInt32(i)).ToArray())
                .Select(xy => (x: xy[0], y: xy[1])).ToArray();
            var cm = new ChronalMapper(knownCoordinates);



            return cm.FindLargestSafeSpace(totalDistance);
        }
    }
}
