using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Dijkstra
    {
        internal class NodeRef
        {
            public Node Node { get; set; }
            public int Cost { get; set; }
        };

        internal class Node
        {
            public string Name { get; set; }
            public int MinCost { get; set; }
            public Node Parent { get; set; }
            public List<NodeRef> Nodes { get; set; }
        }

        internal static void Run()
        {
            //    5 - C - 4
            // A      1      D
            //    3 - B - 7
            var d = new Node()
            {
                Name = "D",
                MinCost = int.MaxValue,
                Parent = null,
                Nodes = new List<NodeRef>
                {
                }
            };
            var c = new Node()
            {
                Name = "C",
                MinCost = int.MaxValue,
                Parent = null,
                Nodes = new List<NodeRef>
                {
                    new NodeRef() { Node = d, Cost = 4 }
                }
            };
            var b = new Node()
            {
                Name = "B",
                MinCost = int.MaxValue,
                Parent = null,
                Nodes = new List<NodeRef>
                {
                    new NodeRef() { Node = c, Cost = 1 },
                    new NodeRef() { Node = d, Cost = 7 }
                }
            };
            var a = new Node()
            {
                Name = "A",
                MinCost = 0,
                Parent = null,
                Nodes = new List<NodeRef>
                {
                    new NodeRef() { Node = b, Cost = 3 },
                    new NodeRef() { Node = c, Cost = 5 }
                }
            };

            int mincost = FindMinCost(a, d);
        }

        private static int FindMinCost(Node start, Node target)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(start);
            Node node;
            while (stack.TryPop(out node))
            {
                foreach (var n in node.Nodes) // go through all paths of node
                {
                    if (n.Cost + node.MinCost < n.Node.MinCost)
                    {
                        n.Node.MinCost = n.Cost + node.MinCost;
                        n.Node.Parent = node;
                    }
                    stack.Push(n.Node);
                }
            }
            return target.MinCost;
        }
    }
}
