using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day08
    {
        public class Node
        {
            public List<Node> ChildNodes;
            public int[] Metadata;

            public Node(int numMetadata)
            {
                ChildNodes = new List<Node>();
                Metadata = new int[numMetadata];
            }

        }

        public static int Puzzle1(string input)
        {
            return 0;
        }

        public static int Puzzle2(string input)
        {
            return 0;
        }
    }
}
