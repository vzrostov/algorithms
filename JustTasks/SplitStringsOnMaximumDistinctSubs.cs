using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
    Number $n$ is given. 
    Break the decimal representation of the number $n$ into as many distinct numbers as possible.
    Numbers with leading zeros are not allowed.
    */
    internal class SplitStringsOnMaximumDistinctSubs
    {
        internal static void Run()
        {
            var str = "229999912672";
            {
                HashSet<string> reshs = new HashSet<string>();
                SplitStringsOnMaximumDistinctSubsNonRecurse(str, ref reshs);
                Console.WriteLine("SplitStringsOnMaximumDistinctSubs::SplitStringsOnMaximumDistinctSubsNonRecurse"
                    + "For " + str + ", count = " + reshs.Count);
                foreach (var item in reshs)
                {
                    Console.Write(" " + item);
                }
                Console.WriteLine("");
            }
            {
                HashSet<string> reshs = new HashSet<string>();
                SplitStringsOnMaximumDistinctSubsRecurse(str, new HashSet<string>(), ref reshs);
                Console.WriteLine("SplitStringsOnMaximumDistinctSubs::SplitStringsOnMaximumDistinctSubsRecurse"
                    + "For " + str + ", count = " + reshs.Count);
                foreach (var item in reshs)
                {
                    Console.Write(" " + item);
                }
                Console.WriteLine("");
            }
        }

        private static void SplitStringsOnMaximumDistinctSubsNonRecurse(string str, ref HashSet<string> reshs)
        {
            var N = Math.Pow(2, str.Length-1);
            for (int i = 0; i < N; i++)
            {
                var hs = SplitByDigit(str, i);
                if (hs.Count > reshs.Count)
                    reshs = hs;
            }
        }

        private static HashSet<string> SplitByDigit(string str, int digit)
        {
            HashSet<string> hs = new HashSet<string>();
            {
                var pos = 0;
                int i = 0;
                for (; i < str.Length - 1; i++)
                {
                    if (((digit >> i) & 0x1) == 0x1)
                    {
                        hs.Add(str.Substring(pos, i-pos+1));
                        pos = i+1;
                    }
                }
                hs.Add(str.Substring(pos, i - pos + 1));
            }
            return hs;
        }

        private static void SplitStringsOnMaximumDistinctSubsRecurse(string str,
            HashSet<string> hs, ref HashSet<string> reshs)
        {
            if (0 == str.Length)
            {
                if(hs.Count > reshs.Count)
                    reshs = hs;
                return;
            }
            foreach (int item in Enumerable.Range(1, str.Length))
            {
                var narr = new HashSet<string>(hs);
                narr.Add(str.Substring(0, item));
                SplitStringsOnMaximumDistinctSubsRecurse(str.Substring(item, str.Length-item), narr, ref reshs);
            }
        }
    }
}
