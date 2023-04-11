using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class RecurseFactorialAndNot
    {
        internal static void Run()
        {
            // make all string variants from character set
            //MakeAllStringsFactorial("");
            //MakeAllStringsFactorial("a");
            //MakeAllStringsFactorial("ab");
            MakeAllStringsFactorial("abcd"); // abcd dcba cbad ...
            //MakeAllStringsFactorial("ab cdc ey dfxcskq");
            MakeAllStringsByOrder("abcd"); // abcd cd bc bcd a...
            MakeAllStringsByOrderWithGap("abcd"); // abcd cd bc bcd a ac abd ...
        }

        private static void MakeAllStringsByOrderWithGap(string str)
        {
            var res = new List<string>();
            MakeAllStringsByOrderRecurseWithGap(str, res);
            Console.WriteLine("For " + str + ", count = " + res.Count);
        }

        private static void MakeAllStringsByOrderRecurseWithGap(string str, List<string> res, string acc = "")
        {
            if(str.Length == 0)
            {
                if(acc.Length != 0)
                    res.Add(acc);
                return;
            }
            char c = str[0];
            MakeAllStringsByOrderRecurseWithGap(str.Substring(1, str.Length - 1), res, acc + c);
            MakeAllStringsByOrderRecurseWithGap(str.Substring(1, str.Length - 1), res, acc);
        }

        private static void MakeAllStringsByOrder(string str)
        {
            var res = new List<string>();
            MakeAllStringsByOrder(str, res);
            Console.WriteLine("For " + str + ", count = " + res.Count);
        }

        private static void MakeAllStringsByOrder(string str, List<string> res)
        {
            for (int i=0; i < str.Length; i++)
            {
                for (int ii = 0; ii < str.Length - i; ii++)
                {
                    var ss = str.Substring(i, ii + 1); // refactor it to Span using
                    res.Add(new string(ss));
                }
            }
        }

        private static void MakeAllStringsFactorial(string str)
        {
            var res = new List<string>();
            MakeAllStringsRecurse(str.Distinct().Where(c => char.IsLetter(c)).ToList(), res);
            Console.WriteLine("For " + str + ", count = " + res.Count);
        }

        private static void MakeAllStringsRecurse(List<char> str, List<string> res, string acc = "")
        {
            if (str.Count == 0)
            //if(acc.Length == 2) // only 2char strings
            {
                res.Add(acc);
                return;
            }
            foreach (char c in str)
            {
                MakeAllStringsRecurse(str.Where(ch => ch != c).ToList(), res, acc + c);
            }
        }
    }
}
