using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Scrabble
    {
        internal static void Run()
        {
            HashSet<string> vocab = new HashSet<string>()
                    { "moon", "snake", "bus", "word", "star", "mob", "noob"};
            HashSet<string> stopSyllables = new HashSet<string>()
                    { "oo", "bb", "ua", "rr", "nr", "ns", "rk", "rn", "rt",
                    "tsn", "buak", "buan", "atsu", "suan", "tsua" };
            HashSet<string> stopSyllablesEmpty = new HashSet<string>() { };
            {
                List<List<char>> field = new List<List<char>>()
                {
                    new List<char>() { 'r', 'k', 'e','r','r',' ','n' },
                    new List<char>() { 'r', 'a', 'n','r','r',' ','o' },
                    new List<char>() { 'r', 'u', 's','t','a','b','o' },
                    new List<char>() { 'b', 'b', ' ',' ',' ',' ','m' }
                };
                {
                    int countTests = 0;
                    Stopwatch stopwatch = new Stopwatch();
                    stopwatch.Start();
                    HashSet<string> res = new();
                    FindScrabbleWords(4, 7, field, vocab, stopSyllables, ref res, ref countTests);
                    stopwatch.Stop();
                    Console.WriteLine("FindScrabbleWords: " + res.Count + ", Steps: " + countTests + ", Time: " + stopwatch.Elapsed);
                    Console.WriteLine("Finding Words: " + res.Aggregate((x, y) => x + ", " + y));
                }
                {
                    int countTestsNoSyll = 0;
                    Stopwatch stopwatch2 = new Stopwatch();
                    stopwatch2.Start();
                    HashSet<string> res2 = new();
                    FindScrabbleWords(4, 7, field, vocab, stopSyllablesEmpty, ref res2, ref countTestsNoSyll);
                    stopwatch2.Stop();
                    Console.WriteLine("FindScrabbleWords with stopSyllablesEmpty: " + res2.Count + ", Steps: " + countTestsNoSyll + ", Time: " + stopwatch2.Elapsed);
                    Console.WriteLine("Finding Words: " + res2.Aggregate((x, y) => x + ", " + y));
                }
            }
            {
                List<List<char>> field = new List<List<char>>()
                {
                    new List<char>() { 'u', 's' },
                    new List<char>() { 'b', 'r' }
                };
                int countTests = 0;
                Stopwatch stopwatch = Stopwatch.StartNew();
                HashSet<string> res = new();
                FindScrabbleWords(2, 2, field, vocab, stopSyllablesEmpty, ref res, ref countTests);
                stopwatch.Stop();
                Console.WriteLine("FindScrabbleWords with stopSyllablesEmpty and full covering: " + res.Count + ", Steps: " + countTests + ", Time: " + stopwatch.Elapsed);
                Console.WriteLine("Finding Words: " + res.Aggregate((x, y) => x + ", " + y));
            }
        }

        private static void FindScrabbleWords(in int sx, in int sy, 
            in List<List<char>> field, 
            in HashSet<string> vocab, 
            in HashSet<string> stopSyllables,
            ref HashSet<string> res,
            ref int countTests)
        {
            for (int pX=0; pX<sx; pX++)
                for (int pY = 0; pY < sy; pY++) 
                    if (field[pX][pY] != ' ')
                    {
                        HashSet<string> r = new HashSet<string>();
                        FindScrabbleWordsRecurse(in sx, in sy,
                            in field,
                            in vocab,
                            in stopSyllables,
                            pX, pY,
                            new HashSet<Tuple<int, int>>(),
                            "",
                            ref r,
                            ref countTests);
                        res.UnionWith(r);
                    }
        }

        private static void FindScrabbleWordsRecurse(in int sx, in int sy,
            in List<List<char>> field,
            in HashSet<string> vocab,
            in HashSet<string> stopSyllables,
            int x, int y,
            HashSet<Tuple<int, int>> passed, 
            string acc,
            ref HashSet<string> res,
            ref int countTests)
        {
            if (x < 0 || x >= sx || y < 0 || y >= sy || field[x][y] == ' ') ///////
            {
                if(acc.Length >= 2) // we can not have words less than 2 signs
                {
                    countTests++;
                    string stest = new string(acc.ToArray()); 
                    if (vocab.Contains(stest))
                        res.Add(stest);
                }
                return;
            }

            if (acc.Length >= 1) // we can have stop letters in other languages
                if (stopSyllables.Any())
                {
                    if (stopSyllables.Contains(acc))
                        return;
                }

            if (!passed.Contains(new Tuple<int, int>(x, y)))
            {
                {
                    var newpassed = new HashSet<Tuple<int, int>>(passed);
                    newpassed.Add(new Tuple<int, int>(x, y));
                    FindScrabbleWordsRecurse(in sx, in sy,
                        in field,
                        in vocab,
                        in stopSyllables,
                        x + 1, y,
                        newpassed,
                        acc + field[x][y],
                        ref res,
                        ref countTests);
                }
                {
                    var newpassed = new HashSet<Tuple<int, int>>(passed);
                    newpassed.Add(new Tuple<int, int>(x, y));
                    FindScrabbleWordsRecurse(in sx, in sy,
                        in field,
                        in vocab,
                        in stopSyllables,
                        x, y + 1,
                        newpassed,
                        acc + field[x][y],
                        ref res,
                        ref countTests);
                }
                {
                    var newpassed = new HashSet<Tuple<int, int>>(passed);
                    newpassed.Add(new Tuple<int, int>(x, y));
                    FindScrabbleWordsRecurse(in sx, in sy,
                        in field,
                        in vocab,
                        in stopSyllables,
                        x - 1, y,
                        newpassed,
                        acc + field[x][y],
                        ref res,
                        ref countTests);
                }
                {
                    var newpassed = new HashSet<Tuple<int, int>>(passed);
                    newpassed.Add(new Tuple<int, int>(x, y));
                    FindScrabbleWordsRecurse(in sx, in sy,
                        in field,
                        in vocab,
                        in stopSyllables,
                        x, y - 1,
                        newpassed,
                        acc + field[x][y],
                        ref res,
                        ref countTests);
                }
            }
        }
    }
}
