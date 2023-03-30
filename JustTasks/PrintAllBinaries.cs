using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class PrintAllBinaries
    {
        internal static void Run()
        {
            PrintAllBinariesOfV(5);
            PrintAllBinariesOfV(16);
        }

        private static void PrintAllBinariesOfV(int v)
        {
            Console.WriteLine("All binaries of " + v);
            for(int i = 1; i <= v; i++)
            {
                var r = i;
                string s = string.Empty;
                while (r > 0)
                {
                    s = r % 2 + s;
                    r = r / 2;
                }
                Console.WriteLine(s);
            }
        }
    }
}
