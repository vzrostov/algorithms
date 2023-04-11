using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
     * It converts int array [1 2 3 5 6 90] to string like "1-3, 5-6, 90"
     */ 
    internal class IntListToString
    {
        internal static void Run()
        {
            var l = new List<int>() { 1, 2, 3, 5, 6, 90 };
            Console.WriteLine("IntList [{0}] ToStringWithRanges [{1}]", IntListToSimpleString(l), IntListToStringWithRanges(l));
            l = new List<int>() { 1, 2, 3, 5, 6, 90, 100, 110 };
            Console.WriteLine("IntList [{0}] ToStringWithRanges [{1}]", IntListToSimpleString(l), IntListToStringWithRanges(l));
            l = new List<int>() { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("IntList [{0}] ToStringWithRanges [{1}]", IntListToSimpleString(l), IntListToStringWithRanges(l));
            l = new List<int>() { 1, 3, 6, 90 };
            Console.WriteLine("IntList [{0}] ToStringWithRanges [{1}]", IntListToSimpleString(l), IntListToStringWithRanges(l));
        }

        private static string IntListToStringWithRanges(in List<int> l)
        {
            if (l.Count == 0)
                return String.Empty;
            
            var sortedL = l.OrderBy(x => x);

            var acc = String.Empty;
            var prev = -2;
            var end = -2;
            foreach (int i in l)
            {
                if(acc == "")
                {
                    acc = i.ToString();
                }
                else
                if(i-prev == 1)
                {
                    end = i;
                }
                else
                {
                    if(end==prev)
                        acc += "-" + end.ToString();
                    acc += "," + i.ToString();
                }
                prev = i;
            }
            if (end == prev)
                acc += "-" + end.ToString();

            return acc;
        }

        private static string IntListToSimpleString(in List<int> l)
        {
            return l.Select(x => x.ToString()).Aggregate((x1, x2) => x1 + "," + x2);
        }
    }
}
