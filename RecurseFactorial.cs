using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class RecurseFactorial
    {
        internal static void Run()
        {
            // make all string variants from character set
            //MakeAllStrings("");
            //MakeAllStrings("a");
            //MakeAllStrings("ab");
            MakeAllStrings("abdc");
            //MakeAllStrings("ab cdc ey dfxcskq");
        }

        private static void MakeAllStrings(string str)
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
