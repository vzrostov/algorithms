using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class StackVsHeap
    {
        internal static void Run()
        {
            string s = "abcdefghij";
            var count = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            PrintAllPartsFactorialOnTheHeap(s, ref count, "");
            stopwatch.Stop();
            Console.WriteLine("PrintAllPartsFactorialOnTheHeap: " + count + ", Time: " + stopwatch.Elapsed);
            //
            count = 0;
            stopwatch = Stopwatch.StartNew();
            PrintAllPartsFactorialOnTheStack(s, ref count, "");
            stopwatch.Stop();
            Console.WriteLine("PrintAllPartsFactorialOnTheStack: " + count + ", Time: " + stopwatch.Elapsed);
        }

        private static void PrintAllPartsFactorialOnTheStack(string s, ref int count, string acc)
        {
            if(s.Length == 0)
            {
                count++;
                //Console.WriteLine(acc);
                return;
            }
            foreach(char c in s)
            {
                PrintAllPartsFactorialOnTheStack(new string(s.Where(ch => ch != c).ToArray()), ref count, acc + c);
            }
        }

        private static void PrintAllPartsFactorialOnTheHeap(string s, ref int count, string acc)
        {
            if (s.Length == 0)
            {
                count++;
                //Console.WriteLine(acc);
                return;
            }
            foreach (char c in s)
            {
                PrintAllPartsFactorialOnTheStack(new string(s.Where(ch => ch != c).ToArray()), ref count, acc + c);
            }
        }
    }
}
