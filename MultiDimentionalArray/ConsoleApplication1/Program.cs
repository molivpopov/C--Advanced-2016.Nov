namespace LargestAreaInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main()
        {
            // set Up
            var rows = int.Parse(Console.ReadLine().Split(' ')[0]);
            var maxSizeNeighbour = int.MinValue;
            var mattrix = new List<int[]>();

            for (int i = 0; i < rows; i++)
            {
                mattrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

            var cols = mattrix[0].Length;
            var isPassed = new bool[rows, cols];

            //Engine
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var localMax = FindNeighbour(j, i, isPassed, mattrix);
                    maxSizeNeighbour = maxSizeNeighbour > localMax ? maxSizeNeighbour : localMax;
                }
            }

            Console.WriteLine(maxSizeNeighbour);
        }

        // Factory
        private static int FindNeighbour(int x, int y, bool[,] isPassed, List<int[]> mattrix)
        {
            int col = mattrix[0].Length;
            int row = mattrix.Count;

            //rules to be Neighbour  - ?????
            var dx = new int[] { 0, 1, 0, -1 };
            var dy = new int[] { -1, 0, 1, 0 };

            int numberToCheck = mattrix[y][x];
            int depth = 1;
            isPassed[y, x] = true;

            for (int i = 0; i < dx.Length; i++)
            {
                int xx = x + dx[i]; int yy = y + dy[i];
                if (xx >= 0 && yy >= 0 && xx < col && yy < row)
                {
                    if (!isPassed[yy, xx] && mattrix[yy][xx] == numberToCheck)
                    {
                        isPassed[yy, xx] = true;
                        depth += FindNeighbour(xx, yy, isPassed, mattrix);
                    }
                }
            }
            return depth;
        }
    }
}