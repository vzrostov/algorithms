using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class SumOfDigits
    {
        internal static void Run()
        {
            var numb = 987;
            Console.WriteLine("SumOfDigits of " + numb + ": " + GetSumOfDigits(numb));
            numb = 0;
            Console.WriteLine("SumOfDigits of " + numb + ": " + GetSumOfDigits(numb));
            numb = 1;
            Console.WriteLine("SumOfDigits of " + numb + ": " + GetSumOfDigits(numb));
        }

        private static int GetSumOfDigits(int numb)
        {
            if(numb == 0)
                return 0;
            var pow = 0;
            var orderOfMagn = 0;
            var sum = 0;
            while((orderOfMagn = (int)Math.Pow(10, pow)) <= numb)
            {
                sum += numb / orderOfMagn % 10;
                pow++;
            }
            return sum;
        }
    }
}
