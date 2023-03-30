using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Sets
    {
        internal static void Run()
        {
            List<HashSet<int>> res = new();
            HashSet<int> acc = new();
            GenerateSetsWithTheSameSize(Enumerable.Range(1, 5), 2, acc, res);
        }

        private static void GenerateSetsWithTheSameSize(IEnumerable<int> arr, int setsize, HashSet<int> acc, List<HashSet<int>> res)
        {
            if(acc.Count == setsize)
            {
                res.Add(acc);
                return;
            }
            foreach(int i in arr)
            {
                HashSet<int> nacc = new(acc);
                nacc.Add(i);
                GenerateSetsWithTheSameSize(arr.Where(x => x != i), setsize, nacc, res);
            }
        }
    }
}
