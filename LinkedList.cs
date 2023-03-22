using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Node
    {
        public string Name { get; set; } = "";

        public Node? Next { get; set; } = null;

        public Node? Prev { get; set; } = null;

        public override string ToString()
        {
            return Name;
        }
    }

    internal class LinkedList
    {
        public static void Run()
        {
            Node root, last;
            CreateLinkedList(6, out root, out last);
            PrintLinkedList(root);
            RotateLinkedList(ref root, ref last);
            PrintLinkedList(root);
        }

        private static void RotateLinkedList(ref Node root, ref Node last)
        {
            Console.WriteLine("Rotate");
            var r = root;
            var l = last;
            bool notAdjacent = true;
            while (notAdjacent)
            {
                notAdjacent = !((r.Prev == l.Next && r.Prev != null) || (r.Next == l.Prev && l.Prev != null)
                    || r.Next == l || r.Prev == l || l.Next == r || l.Prev == r);
                SwapNodes(r, l, ref root, ref last);
                var tmp = r;
                r = l;
                l = tmp;
                r = r.Next;
                l = l.Prev;
            }
        }

        private static void CreateLinkedList(int size, out Node root, out Node last)
        {
            root = new Node() { Name = "root" };
            Node? p = root;
            last = root;
            foreach (var i in Enumerable.Range(0, size))
            {
                Node n = new Node() { Name = i.ToString() };
                p.Next = n;
                n.Prev = p;
                p = n;
                last = n;
            }
            last.Name = "last";
        }

        private static void PrintLinkedList(Node root)
        {
            Node? p;
            Console.Write("Print: ");
            p = root;
            do
            {
                Console.Write(p.Name + " ");
                p = p.Next;
            }
            while (p != null);
            Console.WriteLine("");
        }

        private static void SwapNodes(Node? n1, Node? n2, ref Node root, ref Node last)
        {
            bool n1WasRoot = root == n1;
            bool n2WasRoot = root == n2;
            bool n1WasLast = last == n1;
            bool n2WasLast = last == n2;
            Node tempnode = new Node();
            tempnode.Next = n1.Next;
            tempnode.Prev = n1.Prev;
            n1.Next = (n2.Next == n1) ? n2 : n2.Next;
            n1.Prev = (n2.Prev == n1) ? n2 : n2.Prev;
            if (n1.Prev != null)
                n1.Prev.Next = n1;
            if (n1.Next != null)
                n1.Next.Prev = n1;
            n2.Next = (tempnode.Next == n2) ? n1 : tempnode.Next; //tempnode.Next;
            n2.Prev = (tempnode.Prev == n2) ? n1 : tempnode.Prev; //tempnode.Prev;
            if (n2.Prev != null)
                n2.Prev.Next = n2;
            if (n2.Next != null)
                n2.Next.Prev = n2;
            if (n1WasRoot)
                root = n2;
            if (n2WasRoot)
                root = n1;
            if (n1WasLast)
                last = n2;
            if (n2WasLast)
                last = n1;
            //Node tempnodeR = root;
            //root = last;
            //last = tempnodeR;
        }

        private static Node? FindNode(string n1s, Node root)
        {
            Node? p = root;
            do
            {
                if (n1s == p.Name)
                    return p;
                p = p.Next;
            }
            while (p != null);
            return null;
        }
    }
}
