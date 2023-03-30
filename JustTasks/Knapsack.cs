using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Knapsack
    {
        class ProductDescription
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public int Price { get; set; }
        }

        internal static void Run()
        {
            List<ProductDescription> productDescriptions = new List<ProductDescription>()
            {
                new ProductDescription() { Name = "Product 2", Price = 2500, Weight = 1 },
                new ProductDescription() { Name = "Product 1", Price = 4000, Weight = 4 },
                new ProductDescription() { Name = "Product 3", Price = 2000, Weight = 3 }
            };
            var res = CountMax(productDescriptions.Select(x => x.Weight).ToArray(), 
                productDescriptions.Select(x => x.Price).ToArray(), 
                4);
            Console.WriteLine("Max price = " + res);
        }

        public static int CountMax(int[] weights, int[] prices, int maxCapacity)
        {
            int[,] arr = new int[weights.Length + 1, maxCapacity + 1];

            for (int i = 0; i <= weights.Length; i++)
            {
                for (int j = 0; j <= maxCapacity; j++) // go through all knapsacks
                {
                    if (i == 0 || j == 0) // our empty cell
                    {
                        arr[i, j] = 0;
                    }
                    else
                    {
                        var prev = arr[i - 1, j]; // upper cell
                        if (weights[i - 1] > j) // weight of I-product more than J-knapsack
                        {
                            arr[i, j] = prev; // fill cell from upper cell
                        }
                        else
                        {
                            var byFormula = prices[i - 1] + arr[i - 1, j - weights[i - 1]];
                            arr[i, j] = Math.Max(prev, byFormula);
                        }
                    }
                }
            }

            return arr[weights.Length, maxCapacity];
        }
    }
}
