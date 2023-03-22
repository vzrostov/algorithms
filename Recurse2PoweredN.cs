using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Recurse2PoweredN
    /// MakeAllBinaries
    /// MakeAllBinariesWhereLevelNotZero
    /// MakeBracketVariants
    /// </summary>
    internal class Recurse2PoweredN
    {
        internal static void Run()
        {
            //MakeAllBinaries(2);
            MakeAllBinaries(4);
            //MakeAllBinaries(12);
            //MakeAllBinaries(22);
            MakeAllBinariesWhereLevelNotZero(4, 2);
            MakeAllBinariesWhereLevelNotZero(5, 4);
            MakeBracketVariants(3);
        }

        private static void MakeAllBinaries(int n)
        {
            var res = new List<string>();
            MakeAllBinariesRecurse(n, res);
            Console.WriteLine("For " + n + ", count = " + res.Count);
            //foreach (var item in res)
            //    Console.WriteLine(" " + item);
        }

        private static void MakeAllBinariesWhereLevelNotZero(int n, int level)
        {
            var res = new List<string>();
            MakeAllBinariesWhereLevelNotZeroRecurse(n, res, level);
            Console.WriteLine("For " + n + ", count = " + res.Count);
            //foreach (var item in res)
            //    Console.WriteLine(" " + item);
        }

        private static void MakeBracketVariants(int n)
        {
            var res = new List<string>();
            MakeBracketVariantsRecurse(n, n, res);
            Console.WriteLine("For " + n + ", count = " + res.Count);
            foreach (var item in res)
                Console.WriteLine(" " + item);
        }

        /* RECURSE */

        private static void MakeAllBinariesRecurse(int n, List<string> res, string acc = "")
        {
            if (n == 0)
            {
                res.Add(acc);
                return;
            }
            {
                MakeAllBinariesRecurse(n - 1, res, acc + '0');
                MakeAllBinariesRecurse(n - 1, res, acc + "1");
            }
        }

        private static void MakeAllBinariesWhereLevelNotZeroRecurse(int n, List<string> res, 
            int levelWithoutZero, string acc = "")
        {
            if (n == 0)
            {
                res.Add(acc);
                return;
            }
            {
                if (n-1 != levelWithoutZero)
                    MakeAllBinariesWhereLevelNotZeroRecurse(n - 1, res, levelWithoutZero, acc + '0');
                MakeAllBinariesWhereLevelNotZeroRecurse(n - 1, res, levelWithoutZero, acc + "1");
            }
        }

        private static void MakeBracketVariantsRecurse(int nopen, int nclose, List<string> res, string acc = "")
        {
            if (nopen == 0 && nclose == 0)
            {
                res.Add(acc);
                return;
            }
            {
                if (nopen > 0)
                    MakeBracketVariantsRecurse(nopen - 1, nclose, res, acc + '{');
                if (nclose > 0 && nclose > nopen)
                    MakeBracketVariantsRecurse(nopen, nclose - 1, res, acc + "}");
            }
        }
    }
}
