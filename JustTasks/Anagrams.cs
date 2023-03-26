using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Anagrams
    {
        internal static void Run()
        {
            {
                var str1 = "uui iit!@%^)(";
                var str2 = "ui iu it";
                Console.WriteLine("{0} AND {1} IS {2}ANAGRAMS", str1, str2, IsAnagram(str1, str2)? "" : "NOT ");
            }
            {
                var str1 = "uui iitu";
                var str2 = "ui iu itt";
                Console.WriteLine("{0} AND {1} IS {2}ANAGRAMS", str1, str2, IsAnagram(str1, str2) ? "" : "NOT ");
            }
        }

        private static bool IsAnagram(string str1, string str2)
        {
            var arr1 = str1.Where(ch => char.IsLetterOrDigit(ch)).ToLookup(x => x);
            var arr2 = str2.Where(ch => char.IsLetterOrDigit(ch)).ToLookup(x => x);
            if (arr1.Count != arr2.Count)
                return false;
            foreach(var item in arr1)
            {
                if (!arr2.Contains(item.Key))
                    return false;
                if (arr1[item.Key].Count() != arr2[item.Key].Count())
                    return false;
            }
            return true;
        }
    }
}
