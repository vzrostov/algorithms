using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
    Given a sequence $n$ of positive numbers $a_1, a_2, …, a_n$. 
    While there are different ones among them, the following operation is performed: 
    some maximum number is selected and the minimum number is subtracted from it.
    After how many operations will the numbers become the same?
    */
    internal class StepsToMakeAllEqual
    {
        internal static void Run()
        {
            {
                List<long> list = new List<long>() { 10, 6, 3 };
                //List<long> list = new List<long>() { 10000, 10000, 10000, 10000, 10000, 1 };
                //List<long> list = new List<long>() { 10000, 10000, 10000, 10000, 10000 };

                Console.Write("List before: ");
                foreach (long i in list)
                    Console.Write(i + " ");
                Console.WriteLine("");
                long stepcount = 0;
                if(!IsAllEqual(list))
                    CalculateStepCount(list, ref stepcount);
                Console.Write("List after: ");
                foreach (long i in list)
                    Console.Write(i + " ");
                Console.WriteLine("");
                Console.WriteLine("StepCount to make it equal when making max = max-min: " + stepcount);
            }
        }

        private static void CalculateStepCount(List<long> list, ref long stepcount)
        {
            var min = list.Min();
            var max = long.MinValue;
            var maxInd = 0;
            for(int i=0; i < list.Count; i++)
            {
                var localstepcount = list[i] / min - 1;
                stepcount += localstepcount;
                if (localstepcount > 0)
                {
                    list[i] -= localstepcount * min;
                }
                if(max < list[i])
                {
                    max = list[i];
                    maxInd = i;
                }
            }
            if (!IsAllEqual(list))
            {
                list[maxInd] -= min;
                stepcount++;
                CalculateStepCount(list, ref stepcount);
            }
            else
                return;
        }

        static bool IsAllEqual(List<long> list)
        {
            long el = list.Last();
            foreach (int i in list)
                if (el != i)
                    return false;
            return true;
        }
    }
}
