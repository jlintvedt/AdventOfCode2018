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
        [DebuggerDisplay("{ClosentKnownCoordinateId}")]
        public class Coordinate
        {
            public int ClosentKnownCoordinateId;
            public int DistanceToClosestKnownCoordinate;

            public Coordinate(int id)
            {
                ClosentKnownCoordinateId = id;
            }
        }

        public class ChronalMapper
        {
            public Coordinate[,] KnownCoordinates;
            public Coordinate[,] MappedSpace;
            public int sizeX, sizeY;

            public ChronalMapper((int x,int y)[] coordinates)
            {
                sizeX = coordinates.Max(cord => cord.x)+1;
                sizeY = coordinates.Max(cord => cord.y)+1;

                KnownCoordinates = new Coordinate[sizeX, sizeY];
                MappedSpace = new Coordinate[sizeX, sizeY];

                // First map known coordinates
                for (int i = 0; i < coordinates.Length; i++)
                {
                    KnownCoordinates[coordinates[i].x, coordinates[i].y] = new Coordinate(i);
                }
                // Then map the remaining space
                for (int x = 0; x < sizeX; x++)
                {
                    for (int y = 0; y < sizeY; y++)
                    {
                        MappedSpace[x, y] = new Coordinate(FindClosestNode(x, y));
                    }
                }
                return;
            }

            private int FindClosestNode(int initialX, int initialY)
            {
                // First check self
                if (KnownCoordinates[initialX,initialY] != null)
                {
                    return KnownCoordinates[initialX, initialY].ClosentKnownCoordinateId;
                }
                // Increase radius until one or more nodes are found
                // Searches in this order (for radius=2)
                //   4  
                //  2 6 
                // 1 x 8
                //  3 7 
                //   5  
                int? nodeId = null;
                int x, y;
                for (int r = 1; r < 400; r++) // Arbitary limit
                {
                    // Position 1
                    x = initialX - r;
                    if (x >= 0 && KnownCoordinates[x, initialY] != null)
                    {
                        nodeId = KnownCoordinates[initialX - r, initialY].ClosentKnownCoordinateId;
                    }
                    // Positions 2-7
                    for (int dX = -r+1; dX < r; dX++)
                    {
                        x = initialX + dX;
                        if (x < 0)
                        {
                            continue;
                        } 
                        if (x >= sizeX)
                        {
                            break;
                        }
                        // Check above horizontal
                        int dY = dX < 0 ? -dX : dX;
                        y = initialY -r + dY;
                        if (y > 0 && KnownCoordinates[x, y] != null)
                        {
                            if (nodeId != null){
                                return -1;
                            }
                            nodeId = KnownCoordinates[x, y].ClosentKnownCoordinateId;
                        }
                        // Check below horizontal
                        y = initialY + r - dY;
                        if (y < sizeY && KnownCoordinates[x, y] != null)
                        {
                            if (nodeId != null){
                                return -1;
                            }
                            nodeId = KnownCoordinates[x, y].ClosentKnownCoordinateId;
                        }
                    }
                    // Position 8
                    x = initialX + r;
                    if (x < sizeX &&  KnownCoordinates[initialX+r, initialY] != null)
                    {
                        if (nodeId != null){
                            return -1;
                        }
                        nodeId = KnownCoordinates[initialX+r, initialY].ClosentKnownCoordinateId;
                    }
                    // Check if node was found in range
                    if (nodeId != null)
                    {
                        return (int)nodeId;
                    }
                }
                throw new Exception("Out of arbitrary array");
                // Alternative approach: Calculate Manhattan distance to all known nodes, and pick lowest
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
                if (node.ClosentKnownCoordinateId >= 0)
                {
                    area[node.ClosentKnownCoordinateId]++;
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
                        if (cm.MappedSpace[x, y].ClosentKnownCoordinateId != -1)
                        {
                            area[cm.MappedSpace[x, y].ClosentKnownCoordinateId] = 0;
                        }
                        
                    }
                } else {
                    // Columns inbetween
                    if (cm.MappedSpace[x, 0].ClosentKnownCoordinateId != -1)
                    {
                        area[cm.MappedSpace[x, 0].ClosentKnownCoordinateId] = 0;
                    }
                    if (cm.MappedSpace[x, cm.sizeY-1].ClosentKnownCoordinateId != -1)
                    {
                        area[cm.MappedSpace[x, cm.sizeY-1].ClosentKnownCoordinateId] = 0;
                    }
                }
            }

            return area.Max();
        }
    }
}
