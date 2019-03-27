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

            public Node()
            {
                ChildNodes = new List<Node>();
            }

            public int SumMetadataRecursively()
            {
                int sum = Metadata.Sum();
                foreach (var child in ChildNodes)
                {
                    sum += child.SumMetadataRecursively();
                }
                return sum;
            }

            public int GetNodeValueRecursively()
            {
                // Leaf nodes use sum of metadata
                if (ChildNodes.Count==0)
                {
                    return Metadata.Sum();
                }
                // Non-leaf nodes use metadata to reference child-nodes sum
                int sum = 0;
                foreach (var meta in Metadata)
                {
                    if (0 < meta && meta <= ChildNodes.Count)
                    {
                        sum += ChildNodes[meta-1].GetNodeValueRecursively();
                    }
                }

                // Note: Value could be stored for repeated retrieval
                return sum;
            }
        }

        public class NavigationSystem
        {
            public Node RootNode;

            public NavigationSystem(int[] inputData)
            {
                int index = 0;
                RootNode = ParseSubnode(inputData, ref index);
            }

            public int SumMetadata()
            {
                return RootNode.SumMetadataRecursively();
            }

            public int GetRootNodeValue()
            {
                return RootNode.GetNodeValueRecursively();
            }

            private Node ParseSubnode(int[] data, ref int index)
            {
                int numChildnodes = data[index++];
                int numMetadata = data[index++];
                Node node = new Node();
                for (int i = 0; i < numChildnodes; i++)
                {
                    node.ChildNodes.Add(ParseSubnode(data, ref index));
                }
                node.Metadata = new ArraySegment<int>(data, index, numMetadata).ToArray();
                index += numMetadata;
                return node;
            }
        }

        public static int Puzzle1(string input)
        {
            var data = Common.ParseIntArray(input, " ");
            var ns = new NavigationSystem(data);

            return ns.SumMetadata();
        }

        public static int Puzzle2(string input)
        {
            var data = Common.ParseIntArray(input, " ");
            var ns = new NavigationSystem(data);

            return ns.GetRootNodeValue();
        }
    }
}
