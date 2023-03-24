using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.Dijkstra;

namespace Algorithms
{
    class TreeAvlNode
    {
        internal int Value { get; set; }
        internal TreeAvlNode Left { get; set; }
        internal TreeAvlNode Right { get; set; }
        internal int Height { get; set; }
        internal int BFactor { get; set; }
        public override string ToString() { return Value.ToString(); }
    }

    internal class TreeAvl
    {
        internal static void Run()
        {
            var treeAvl = new TreeAvl();
            TreeAvlNode? root = null;
            // full rotate left
            root = treeAvl.Insert(root, 3);
            root = treeAvl.Insert(root, 33);
            root = treeAvl.Insert(root, 32);
            // removing
            root = treeAvl.Remove(root, 32);
            root = treeAvl.Remove(root, 33);
            // full rotate right
            root = treeAvl.Insert(root, 2);
            root = treeAvl.Insert(root, 1);

            treeAvl.Print(root);

            // removing all
            root = treeAvl.Remove(root, 2);
            root = treeAvl.Remove(root, 1);
            root = treeAvl.Remove(root, 3);
        }

        public void Print(TreeAvlNode? root)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            var st = new Queue<TreeAvlNode>();
            st.Enqueue(root);
            TreeAvlNode? p;
            while(st.TryDequeue(out p))
            {
                Console.WriteLine("{0} h={1} bf={2}", p.Value, p.Height, p.BFactor);
                if (p.Left != null)
                    st.Enqueue((TreeAvlNode)p.Left);
                if (p.Right != null)
                    st.Enqueue((TreeAvlNode)p.Right);
            }
        }

        public TreeAvlNode Insert(TreeAvlNode? p, int value)
        {
            if (p == null)
                return new TreeAvlNode() { Value = value, Height = 1 };
            if (p.Value > value)
                p.Left = Insert(p.Left, value);
            else
                p.Right = Insert(p.Right, value);

            return Balance(p);
        }

        public TreeAvlNode? Remove(TreeAvlNode p, int value) 
        {
            if (p==null) 
                return null;
            if (p.Value > value)
                p.Left = Remove(p.Left, value);
            else 
            if (value > p.Value)
                p.Right = Remove(p.Right, value);
            else 
            {
                TreeAvlNode q = p.Left;
                TreeAvlNode r = p.Right;
                if (r==null) 
                    return q;
                TreeAvlNode min = FindMin(r);
                min.Right = RemoveMin(r);
                min.Left = q;
                return Balance(min);
            }
            return Balance(p);
        }

        TreeAvlNode FindMin(TreeAvlNode p)
        {
            return p.Left!=null ? FindMin(p.Left) : p;
        }

        TreeAvlNode RemoveMin(TreeAvlNode p)
        {
            if (p.Left == null)
                return p.Right;
            p.Left = RemoveMin(p.Left);
            return Balance(p);
        }

        private TreeAvlNode Balance(TreeAvlNode p)
        {
            FixHeight(p);
            if (p.BFactor == 2)
            {
                if (p.Right != null)
                    if (p.Right.BFactor < 0)
                        p.Right = RotateRight(p.Right);
                return RotateLeft(p);
            }
            if (p.BFactor == -2)
            {
                if (p.Left != null)
                    if (p.Left.BFactor > 0)
                        p.Left = RotateLeft(p.Left);
                return RotateRight(p);
            }
            return p;
        }

        TreeAvlNode RotateRight(TreeAvlNode p) 
        {
            TreeAvlNode q = p.Left;
            p.Left = q.Right;
            q.Right = p;
            FixHeight(p);
            FixHeight(q);
            return q;
        }

        TreeAvlNode RotateLeft(TreeAvlNode q) 
        {
            TreeAvlNode p = q.Right;
            q.Right = p.Left;
            p.Left = q;
            FixHeight(q);
            FixHeight(p);
            return p;
        }

        void FixHeight(TreeAvlNode p)
        {
            int hl = GetHeight(p.Left);
            int hr = GetHeight(p.Right);
            p.Height = (hl > hr ? hl : hr) + 1;
            p.BFactor = hr - hl;
        }

        int GetHeight(TreeAvlNode p)
        {
            return (p == null) ? 0 : p.Height;
        }
    }
}
