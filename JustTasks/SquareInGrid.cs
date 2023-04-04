using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /*
    Given a 2D grid of 0s and 1s, return the number of elements in the largest square subgrid that has all 1s on its border, 
    or 0 if such a subgrid doesn't exist in the grid.
    Example 1: Input: grid = [[1,1,1],[1,0,1],[1,1,1]] Output: 9 
    Example 2: Input: grid = [[1,1,0,0]] Output: 1
    Example 3: Input: grid = [[1,1,1,1],[1,0,1,1],[1,1,1,1],[1,0,1,1]] Output: 9 
    Example 4: Input: grid = [[1,1,1,1],[1,0,1,1],[1,1,1,1],[1,0,1,1]] Output: 9 
    Example 5: Input: grid = [[1,0,1,0],[0,1,0,1],[1,0,1,0],[0,1,0,1]] Output: 1 
    */
    internal class SquareInGrid
    {
        public static void Run()
        {
            {
                int count = 100;
                List<List<int>> ints = new List<List<int>>();
                foreach (int newDist in Enumerable.Range(0, count))
                {
                    var l = new List<int>(count);
                    foreach (int ii in Enumerable.Range(0, count))
                    {
                        l.Add(0); // all zero
                    }
                    ints.Add(l);
                }
                int num = LongCalculateSquareInGrid(count, count, ints);
                int numQuick = QuickCalculateSquareInGrid(count, count, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 0
            }
            {
                int count = 100;
                List<List<int>> ints = new List<List<int>>();
                foreach (int newDist in Enumerable.Range(0, count))
                {
                    var l = new List<int>(count);
                    foreach (int ii in Enumerable.Range(0, count))
                    {
                        l.Add(0);
                    }
                    ints.Add(l);
                }
                ints[count - 1][count - 1] = 1; // the only one digit
                int num = LongCalculateSquareInGrid(count, count, ints);
                int numQuick = QuickCalculateSquareInGrid(count, count, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 1
            }
            {
                int count = 100;
                List<List<int>> ints = new List<List<int>>();
                foreach (int newDist in Enumerable.Range(0, count))
                {
                    var l = new List<int>(count);
                    foreach (int ii in Enumerable.Range(0, count))
                    {
                        l.Add(((newDist + ii) % 2 == 0) ? 0 : 1); // checkerboard pattern
                    }
                    ints.Add(l);
                }
                int num = LongCalculateSquareInGrid(count, count, ints);
                int numQuick = QuickCalculateSquareInGrid(count, count, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 1
            }
            {
                List<List<int>> ints = new List<List<int>>()
                {
                    new List<int>() { 1,1,1,1 },
                    new List<int>() { 0,0,1,1 },
                    new List<int>() { 1,1,1,1 },
                    new List<int>() { 1,1,1,1 }
                };
                int num = LongCalculateSquareInGrid(4, 4, ints);
                int numQuick = QuickCalculateSquareInGrid(4, 4, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 4
            }
            {
                List<List<int>> ints = new List<List<int>>()
                {
                    new List<int>() { 0,1,1,1,1 },
                    new List<int>() { 0,0,0,1,0 },
                    new List<int>() { 0,0,1,1,1 },
                    new List<int>() { 0,1,1,0,1 },
                    new List<int>() { 0,1,0,0,0 }
                };
                int num = LongCalculateSquareInGrid(5, 5, ints);
                int numQuick = QuickCalculateSquareInGrid(5, 5, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 1
            }
            {
                List<List<int>> ints = new List<List<int>>()
                {
                    new List<int>() { 1,1,1 },
                    new List<int>() { 1,0,1 },
                    new List<int>() { 1,1,1 }
                };
                int num = LongCalculateSquareInGrid(3, 3, ints);
                int numQuick = QuickCalculateSquareInGrid(3, 3, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 9
            }
            {
                List<List<int>> ints = new List<List<int>>()
                {
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,1,1,1,1,1,1 }
                };
                int num = LongCalculateSquareInGrid(4, 7, ints);
                int numQuick = QuickCalculateSquareInGrid(4, 7, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 16
            }
            {
                List<List<int>> ints = new List<List<int>>()
                {
                    new List<int>() { 1,1,1,0,1,1,1 },
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,0,1,1,1,0,1 },
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,1,1,1,1,1,1 },
                    new List<int>() { 1,1,1,1,0,1,1 }
                };
                int num = LongCalculateSquareInGrid(8, 7, ints);
                int numQuick = QuickCalculateSquareInGrid(8, 7, ints);
                Console.WriteLine("LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick); // 25
            }

            for(int i = 0; i < 100; i++)
            {
                TimeRandomTest(5, 5, i, true);
                TimeRandomTest(100, 100, i, true);
            }
            TimeRandomTest(1000, 1000, 5, true);
            TimeRandomTest(1000, 1000, 50, true);
            TimeRandomTest(1000, 1000, 95, true);
        }

        private static int QuickCalculateSquareInGrid(in int szx, in int szy, in List<List<int>> ints)
        {
            bool was1 = false; // for performance not set 1 to HashSet
            // make horizontal section dictionary
            SortedDictionary<int, HashSet<Tuple<int, int>>> dictH = new SortedDictionary<int, HashSet<Tuple<int, int>>>();
            for(int posX = 0; posX < szx; posX++)
            {
                int begY = 0;
                int prev = 0;
                int posY = 0;
                for (; posY < szy; posY++)
                {
                    if (ints[posX][posY] == 1)
                    {
                        was1 = true;
                        if (prev == 0)
                            begY = posY;
                    }
                    if (ints[posX][posY] == 0)
                    {
                        if (prev == 1 && posY - begY != 0)
                            AddToDictH(dictH, posX, begY, posY - begY);
                    }
                    prev = ints[posX][posY];
                }
                if(prev == 1 && posY - begY != 0)
                    AddToDictH(dictH, posX, begY, posY - begY);
            }
            // make vertical section dictionary
            SortedDictionary<int, HashSet<Tuple<int, int>>> dictV = new SortedDictionary<int, HashSet<Tuple<int, int>>>();
            for (int posY = 0; posY < szy; posY++)
            {
                int begX = 0;
                int prev = 0;
                int posX = 0;
                for (; posX < szx; posX++)
                {
                    if (ints[posX][posY] == 1)
                    {
                        if (prev == 0)
                            begX = posX;
                    }
                    if (ints[posX][posY] == 0)
                    {
                        if (prev == 1 && posX - begX != 0)
                            AddToDictV(dictV, begX, posY, posX - begX);
                    }
                    prev = ints[posX][posY];
                }
                if (prev == 1 && posX - begX != 0)
                    AddToDictV(dictV, begX, posY, posX - begX);
            }

            foreach(var pointsV in dictV.Reverse()) // check vertical sections starting from the longest ones
            {
                if (pointsV.Value.Count < 2)
                    continue;
                HashSet<Tuple<int, int>>? pointsH;
                if(dictH.TryGetValue(pointsV.Key, out pointsH)) // pointsV.Key is a section distance
                {
                    if (pointsH != null)
                    {
                        if (pointsH.Count < 2)
                            continue;
                        var dist = pointsV.Key-1;
                        foreach (var point in pointsV.Value) // get through vertical sections
                        {
                            int coordYForSymmetric;
                            // check that we have symmetric vertical section in distance (opposite side)
                            if (pointsV.Value.Contains(new Tuple<int, int>(point.Item1, point.Item2 + dist)))
                                coordYForSymmetric = point.Item2;
                            else
                                if (pointsV.Value.Contains(new Tuple<int, int>(point.Item1, point.Item2 - dist)))
                                    coordYForSymmetric = point.Item2 - dist;
                                else
                                    continue;
                            // check that we have 2 other symmetric sections 
                            if (!pointsH.Contains(new Tuple<int, int>(point.Item1, coordYForSymmetric)))
                                continue;
                            if (!pointsH.Contains(new Tuple<int, int>(point.Item1 + dist, coordYForSymmetric)))
                                continue;
                            return pointsV.Key * pointsV.Key; // elements in square
                        }
                    }
                }
            }
            if (was1)
                return 1;
            return 0;
        }

        private static void AddToDictH(SortedDictionary<int, HashSet<Tuple<int, int>>> dict, int x, int y, int dist)
        {
            if (dist == 0) // for performance
                return;
            for (int newDist = dist; newDist >= 0; newDist--)
                for (int newY = y; newY <= y + dist - newDist; newY++)
                {
                    if (newDist == 0) // for performance
                        continue;
                    HashSet<Tuple<int, int>>? hs;
                    if (dict.TryGetValue(newDist, out hs))
                        hs.Add(new Tuple<int, int>(x, newY));
                    else
                        dict.Add(newDist, new HashSet<Tuple<int, int>>() { new Tuple<int, int>(x, newY) });
                }
        }

        private static void AddToDictV(SortedDictionary<int, HashSet<Tuple<int, int>>> dict, int x, int y, int dist)
        {
            if (dist == 0) // for performance
                return;
            for (int newDist = dist; newDist >= 0; newDist--)
                for (int newX = x; newX <= x + dist - newDist; newX++)
                {
                    if (newDist == 0) // for performance
                        continue;
                    HashSet<Tuple<int, int>>? hs;
                    if (dict.TryGetValue(newDist, out hs))
                        hs.Add(new Tuple<int, int>(newX, y));
                    else
                        dict.Add(newDist, new HashSet<Tuple<int, int>>() { new Tuple<int, int>(newX, y) });
                }
        }

        private static void AddToDict(SortedDictionary<int, HashSet<Tuple<int, int>>> dict, int x, int y, int dist)
        {
            HashSet<Tuple<int, int>>? hs;
            if(dict.TryGetValue(dist, out hs))
                hs.Add(new Tuple<int, int>(x, y));
            else
                dict.Add(dist, new HashSet<Tuple<int, int>>() { new Tuple<int, int>(x, y) });
        }

        private static int LongCalculateSquareInGrid(in int szx, in int szy, in List<List<int>> ints)
        {
            var minsz = Math.Min(szx, szy);
            for(int i=minsz-1; i>=0; i--)
            {
                if (CheckSquare(i, szx, szy, ints))
                    return (i + 1)* (i + 1);
            }
            return 0;
        }

        private static bool CheckSquare(in int width, in int szx, in int szy, in List<List<int>> ints)
        {
            int posX = 0;
            while (posX + width < szx)
            {
                int posY = 0;
                while (posY + width < szy)
                {
                    // check square
                    {
                        int flagY = posY;
                        for (int j = posX; j <= posX + width; j++)
                        {
                            if (ints[j][posY] == 0)
                            {
                                posY++;
                                break;
                            }
                            if (ints[j][posY + width] == 0)
                            {
                                posY++;
                                break;
                            }
                        }
                        if (flagY == posY)
                            for (int j = posY; j <= posY + width; j++)
                            {
                                if (ints[posX][j] == 0)
                                {
                                    posY++;
                                    break;
                                }
                                if (ints[posX + width][j] == 0)
                                {
                                    posY++;
                                    break;
                                }
                            }
                        if(flagY == posY)
                            return true;
                    }
                }
                posX++;
            }
            return false;
        }

        private static void TimeRandomTest(in int szx, in int szy, in int percentOf1, bool calcTime = false)
        {
            var rand = new Random();
            List<List<int>> ints = new List<List<int>>(szx);
            for(var i = 0; i < szx; i++)
            {
                List<int> l = new List<int>(szy);
                for (var ii = 0; ii < szy; ii++)
                {
                    var r = rand.Next(0, 100);
                    l.Add((r < percentOf1) ? 1 : 0);
                }
                ints.Add(l);
            }
            //
            Stopwatch longwatch = new Stopwatch();
            longwatch.Start();
            int num = LongCalculateSquareInGrid(szx, szy, ints);
            longwatch.Stop();
            //
            Stopwatch qwatch = new Stopwatch();
            qwatch.Start();
            int numQuick = QuickCalculateSquareInGrid(szx, szy, ints);
            qwatch.Stop();
            //
            Debug.Assert(num == numQuick);
            if(num != numQuick)
                Console.Write("ALERT ");
            if (calcTime)
                Console.WriteLine("TimeRandomTest times in msec, " + "Long: " + longwatch.ElapsedMilliseconds + ", Quick: " + qwatch.ElapsedMilliseconds);
            Console.WriteLine("TimeRandomTest, LongCalculateSquareInGrid: " + num + ", QuickCalculateSquareInGrid: " + numQuick);
        }
    }
}
