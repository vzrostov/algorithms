using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class SortAlgorithm
    {
        public static void Run()
        {
            int[] arr;
            arr = new int[10] { 2, 5, 7, 6, 10, 8, 3, 9, 1, 4 };
            qsort(arr);
            Console.WriteLine("qsort1 " + check(arr));
            arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            qsort(arr);
            Console.WriteLine("qsort2 " + check(arr));
            arr = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            qsort(arr);
            Console.WriteLine("qsort3 " + check(arr));

            arr = new int[] { 2, 2, 2, 2, 5, 7, 6, 10, 8, 2, 5, 7, 6, 10, 10, 10, 8, 2, 5, 7, 6, 10, 8, 3, 9, 1, 4, 4, 4 };
            qsort(arr);
            Console.WriteLine("qsort4 " + justcheck(arr));
            arr = new int[] { 2, 2, 2, 2, 2, 2, 2, 2 };
            qsort(arr);
            Console.WriteLine("qsort5 " + justcheck(arr));

            int count = 0;
            arr = new int[10] { 2, 5, 7, 6, 10, 8, 3, 9, 1, 4 };
            count = bubblesort(arr);
            Console.WriteLine("bubblesort1 " + check(arr) + ", Moves:" + count);
            arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            count = bubblesort(arr);
            Console.WriteLine("bubblesort2 " + check(arr) + ", Moves:" + count);
            arr = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            count = bubblesort(arr);
            Console.WriteLine("bubblesort3 " + check(arr) + ", Moves:" + count);
            arr = new int[] { 2, 2, 2, 2, 5, 7, 6, 10, 2, 5, 7, 6, 10, 8, 2, 5, 72, 5, 7, 6, 10, 2, 5, 7, 6, 10, 6, 10, 10, 10, 8, 2, 5, 8, 2, 5, 8, 2, 5, 7, 6, 10, 8, 3, 9, 1, 8, 2, 5, 8, 2, 5, 4, 4, 4 };
            count = bubblesort(arr);
            Console.WriteLine("bubblesort4 " + justcheck(arr) + ", Moves:" + count);
            arr = new int[] { 2, 2, 2, 2, 2, 2, 2, 2 };
            count = bubblesort(arr);
            Console.WriteLine("bubblesort5 " + justcheck(arr) + ", Moves:" + count);

            arr = new int[] { 21, 5 };
            mergesort(arr);
            Console.WriteLine("mergesort0 " + justcheck(arr));
            arr = new int[10] { 2, 5, 7, 6, 10, 8, 3, 9, 1, 4 };
            mergesort(arr);
            Console.WriteLine("mergesort1 " + check(arr));
            arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            mergesort(arr);
            Console.WriteLine("mergesort2 " + check(arr));
            arr = new int[10] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            mergesort(arr);
            Console.WriteLine("mergesort3 " + check(arr));
            arr = new int[] { 2, 2, 2, 2, 5, 7, 6, 10, 8, 2, 5, 7, 6, 10, 10, 10, 8, 2, 5, 7, 6, 10, 8, 3, 9, 1, 4, 4, 4 };
            mergesort(arr);
            Console.WriteLine("mergesort4 " + justcheck(arr));
            arr = new int[] { 2, 2, 2, 2, 2, 2, 2, 2 };
            mergesort(arr);
            Console.WriteLine("mergesort5 " + justcheck(arr));
        }

        private static void mergesort(int[] arr) // for threads
        {
            var left = 0;
            var right = arr.Length - 1;
            if(arr.Clone() is int[] buf)
                mergesortr(ref arr, ref buf, left, right);
        }

        private static void mergesortr(ref int[] arr, ref int[] buf, int left, int right)
        {
            if(left < right)
            {
                var m = (right - left) / 2;
                var lstart = left;
                var lend = left + m;
                var rstart = left + m + 1;
                var rend = right;
                mergesortr(ref arr, ref buf, lstart, lend);
                mergesortr(ref arr, ref buf, rstart, rend);

                var k = lstart;
                for(; lstart <= lend || rstart <= rend;)
                {
                    if (lstart <= lend && rstart <= rend)
                    {
                        if(arr[lstart] > arr[rstart])
                        {
                            buf[k] = arr[rstart];
                            rstart++;
                        }
                        else
                        {
                            buf[k] = arr[lstart];
                            lstart++;
                        }
                    }
                    else
                    if (lstart <= lend)
                    {
                        buf[k] = arr[lstart];
                        lstart++;
                    }
                    else
                    if (rstart <= rend)
                    {
                        buf[k] = arr[rstart];
                        rstart++;
                    }
                    k++;
                }
                for (var i = left; i <= right; i++)
                {
                    arr[i] = buf[i];
                }
            }
        }

        private static int bubblesort(int[] arr)
        {
            int count = 0;
            for (int i = arr.Length - 1; i > 0; i--) // first is always not come to end, come to end -1
            {
                bool completed = true;
                for (int ii = arr.Length - 1; ii >= arr.Length - i; ii--) // second - come to 
                {
                    count++;
                    if (arr[ii - 1] > arr[ii])
                    {
                        swap(ref arr[ii - 1], ref arr[ii]);
                        completed = false;
                    }
                }
                if (completed)
                    break;
            }
            return count;
        }

        private static void qsort(int[] arr)
        {
            var left = 0;
            var right = arr.Length - 1;
            qsortr(ref arr, left, right);
        }

        private static void qsortr(ref int[] arr, int left, int right)
        {
            if(right - left <= 0)
                return;
            if (right - left == 1)
            {
                if(arr[left] > arr[right])
                    swap(ref arr[left], ref arr[right]);
                return;
            }
            var pivot = arr[right];
            var less = left;
            for(int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    swap(ref arr[i], ref arr[less]);
                    less++;
                }
            }
            swap(ref arr[less], ref arr[right]);

            qsortr(ref arr, left, less-1);
            qsortr(ref arr, less + 1, right);
        }

        private static void swap(ref int a, ref int b)
        {
            int t = a;
            a = b;
            b = t;
        }

        private static bool justcheck(int[] arr)
        {
            bool f = true;
            for (int ii = 1; ii < arr.Length; ii++)
                if (arr[ii] < arr[ii - 1])
                    f = false;
            return f;
        }

        private static bool check(int[] arr)
        {
            bool f = true;
            for (int ii = 1; ii < arr.Length; ii++)
                if (arr[ii] - arr[ii - 1] != 1)
                    f = false;
            return f;
        }
    }
}
