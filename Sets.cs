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

            {
                // distinct hashsets in list
                HashSet<string> keys = new HashSet<string>() { "11", "22" };
                HashSet<string> keys2 = new HashSet<string>() { "11", "22" };
                HashSet<string> keys3 = new HashSet<string>() { "1", "22" };
                HashSet<string> keys4 = new HashSet<string>() { "1", "22", "23" };
                HashSet<string> keys5 = new HashSet<string>() { "22", "11" };
                HashSet<string> keys6 = new HashSet<string>() { "22" };

                List<HashSet<string>> l = new List<HashSet<string>>() { keys, keys2, keys3, keys4, keys5, keys6 };

                bool mustBeTrueAsSetsAreNotEquals = keys.Intersect(keys2).Count() == keys.Count;
                mustBeTrueAsSetsAreNotEquals = keys.Except(keys2).Count() == 0;
                bool mustBeFalseAsSetsAreNotEquals = keys.Intersect(keys3).Count() == keys.Count;
                mustBeFalseAsSetsAreNotEquals = keys.Except(keys3).Count() == 0;

                var nhs = l.DistinctBy(s => s.Count.GetHashCode() ^ s.Select(s => s.GetHashCode()).Aggregate((q1, q2) => q1 ^ q2));
            }
        }

        private static void GenerateSetsWithTheSameSize(IEnumerable<int> arr, int setsize, HashSet<int> acc, List<HashSet<int>> res)
        {
            if (acc.Count == setsize)
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
