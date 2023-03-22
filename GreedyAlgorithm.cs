using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class GreedyAlgorithm
    {
        internal static void Run()
        {
            {
                HashSet<List<int>> resset = new HashSet<List<int>>();
                List<int> list = new List<int>();
                int n = 4;
                SplitSummands(n, list, resset);
                Console.WriteLine("For " + n + ", count = " + resset.Count);
                foreach (var items in resset)
                {
                    foreach (var item in items)
                    {
                        Console.Write(" " + item);
                    }
                    Console.WriteLine("");
                }
            }
            {
                HashSet<List<int>> resset = new HashSet<List<int>>();
                List<int> list = new List<int>();
                int n = 4;
                SplitSummandsExcept(4, 3, list, resset);
                Console.WriteLine("For " + n + ", count = " + resset.Count);
                foreach (var items in resset)
                {
                    foreach (var item in items)
                    {
                        Console.Write(" " + item);
                    }
                    Console.WriteLine("");
                }
            }
            {
                var l = 1680;
                var h = 480;
                int i = FindSmallestQuadRecurse(l, h);
                Console.WriteLine("FindSmallestQuadRecurse (" + l + "," + h + "): " + i);
            }
            {
                var l = 1680;
                var h = 481;
                int i = FindSmallestQuadRecurse(l, h);
                Console.WriteLine("FindSmallestQuadRecurse (" + l + "," + h + "): " + i);
            }
            {
                var l = 1680;
                var h = 500;
                int i = FindSmallestQuadRecurse(l, h);
                Console.WriteLine("FindSmallestQuadRecurse (" + l + "," + h + "): " + i);
            }
            {
                var l = 73*902635; // 65892355
                var h = 73*4158; // 303534
                int i = FindSmallestQuadRecurse(l, h);
                Console.WriteLine("FindSmallestQuadRecurse (" + l + "," + h + "): " + i);
            }
            {
                var l = 73 * 902635; // 65892355
                var h = 73 * 4158; // 303534
                long i = FindLowestCommonMultiple(l, h);
                Console.WriteLine("FindLowestCommonMultiple (" + l + "," + h + "): " + i); // 273980412090
            }
            {
                var l = 789; 
                var h = 90345; 
                long i = FindLowestCommonMultiple(l, h);
                Console.WriteLine("FindLowestCommonMultiple (" + l + "," + h + "): " + i); 
            }
            {
                var l = 7891;
                var h = 90345;
                long i = FindLowestCommonMultiple(l, h);
                Console.WriteLine("FindLowestCommonMultiple (" + l + "," + h + "): " + i);
            }
            {
                var l = 8;
                var h = 80;
                long i = FindLowestCommonMultiple(l, h);
                Console.WriteLine("FindLowestCommonMultiple (" + l + "," + h + "): " + i);
            }
        }

        private static long FindLowestCommonMultiple(long big, long small)
        {
            var l1 = FindAllMultiples(big);
            long nok1 = l1.Aggregate(1, (a, b) => (int)(a * b));

            var l2 = FindAllMultiples(small);
            List<long> nlist = new List<long>();
            foreach(var item in l2)
            {
                if (l1.Contains(item))
                {
                    l1.Remove(item);
                }
                else
                {
                    nlist.Add(item);
                }
            }
            long nok2 = nlist.Aggregate(1, (a, b) => (int)(a * b));

            return nok1 * nok2;
        }

        private static List<long> FindAllMultiples(long n)
        {
            List<long> hs = new List<long>();
            long div = 2;
            while (n > 1)
            {
                while (n % div == 0)
                {
                    hs.Add(div);
                    n = n / div;
                }
                div++;
            }
            return hs;
        }

        private static int FindSmallestQuadRecurse(int l, int h)
        {
            var diff = l % h;
            if (diff == 0)
                return h;
            if (l < 1)
                return -1;
            return FindSmallestQuadRecurse(h, diff);
        }

        private static void SplitSummandsExcept(int sum, int exc, List<int> list, HashSet<List<int>> resset)
        {
            if (sum == 0)
            {
                resset.Add(list);
                return;
            }
            foreach (int item in Enumerable.Range(1, sum))
            {
                if (item == exc)
                    continue;
                var narr = new List<int>(list);
                narr.Add(item);
                SplitSummandsExcept(sum - item, exc, narr, resset);
            }
        }

        private static void SplitSummands(int sum, List<int> list, HashSet<List<int>> resset)
        {
            if(sum == 0)
            {
                resset.Add(list);
                return;
            }
            foreach (int item in Enumerable.Range(1, sum))
            {
                var narr = new List<int>(list);
                narr.Add(item);
                SplitSummands(sum - item, narr, resset);
            }
        }
    }
}
