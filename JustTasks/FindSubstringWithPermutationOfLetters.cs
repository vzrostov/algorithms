using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
    Given text T and string S.
    It is required to find a substring S' in T such that it coincides with S up to a permutation of letters.
    The answer is to return the index of the first occurrence, or -1 if no such substring S' was found.
    ("reebok", "bee") -> 1
    */
    internal class FindSubstringWithPermutationOfLetters
    {
        internal static void Run()
        {
            {
                var source = "reebok";
                var substr = "bee";
                int ind = GetFirstIndexOfSubstring(source, substr);
                Console.WriteLine("FindSubstringWithPermutationOfLetters [{0} <- {1}]: {2}", source, substr, ind); // 1
            }
            {
                var source = "reebok";
                var substr = "beef";
                int ind = GetFirstIndexOfSubstring(source, substr);
                Console.WriteLine("FindSubstringWithPermutationOfLetters [{0} <- {1}]: {2}", source, substr, ind); // -1
            }
            {
                var source = "FindSubstringWithPermutationOfLetters";
                var substr = "mutation";
                int ind = GetFirstIndexOfSubstring(source, substr);
                Console.WriteLine("FindSubstringWithPermutationOfLetters [{0} <- {1}]: {2}", source, substr, ind); // 20
            }
        }

        static int GetFirstIndexOfSubstring(string source, string substr)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(substr) || source.Length < substr.Length)
                return -1;

            Dictionary<char, int> substrDict = new Dictionary<char, int>();
            Dictionary<char, int> sourceDict = new Dictionary<char, int>();
            int matchCount = 0;

            for (int i = 0; i < substr.Length; i++)
            {
                int v;
                if (substrDict.TryGetValue(substr[i], out v))
                {
                    substrDict[substr[i]] = v + 1;
                }
                else
                {
                    substrDict.Add(substr[i], 1);
                }
            }

            for (int i = 0; i < substr.Length; i++)
            {
                int v;
                if (sourceDict.TryGetValue(source[i], out v))
                {
                    sourceDict[source[i]] = v + 1;
                }
                else
                {
                    sourceDict.Add(source[i], 1);
                }
            }

            foreach (var dict in sourceDict)
            {
                int v;
                if (substrDict.TryGetValue(dict.Key, out v))
                    if (dict.Value == v)
                        matchCount++;
            }

            if (matchCount == substrDict.Count)
                return 0;

            for (int i = 1; i <= source.Length - substr.Length; i++)
            {
                char cdel = source[i - 1];
                char cadd = source[i + substr.Length - 1];

                int v;
                if (sourceDict.TryGetValue(cdel, out v))
                {
                    if (v != 0)
                        sourceDict[cdel] = v - 1;
                }

                int vadd;
                if (sourceDict.TryGetValue(cadd, out vadd))
                {
                    sourceDict[cadd] = vadd + 1;
                }
                else
                {
                    sourceDict.Add(cadd, 1);
                }


                int vaddSubstr;
                if (substrDict.TryGetValue(cadd, out vaddSubstr))
                {
                    if (vaddSubstr == vadd)
                        matchCount--;
                    if (vaddSubstr == vadd + 1)
                        matchCount++;
                }

                int vdelSubstr;
                if (substrDict.TryGetValue(cdel, out vdelSubstr))
                {
                    if (vdelSubstr == v)
                        matchCount--;
                    if (vdelSubstr == v - 1)
                        matchCount++;
                }
                if (matchCount == substrDict.Count)
                    return i;
            }
            return -1;
        }
    }
}
