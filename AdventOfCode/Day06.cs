using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day06
    {
        public class Node
        {
            public int ClosentKnownCoordinateId;
            public int DistanceToClosestKnownCoordinate;
        }

        public class ChronalMapper
        {
            public Node[,] KnownCoordinates;
            public Node[,] MappedSpace;
        }
        
        public static int Puzzle1(string input)
        {
            var knownCoordinates = new(int, int)[1];
            return 0;
        }
    }
}
