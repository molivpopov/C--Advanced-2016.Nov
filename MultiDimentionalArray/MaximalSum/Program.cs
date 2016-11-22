namespace MaximalSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            const int sizeOfSquarMatrix = 3;

            // Set up
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var mattrix = new List<int[]>();
            int maxSum = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                mattrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

 
            //Engine
            for (int i = 0; i <= mattrix.Count - sizeOfSquarMatrix; i++)
            {
                for (int j = 0; j <= mattrix[i].Length - sizeOfSquarMatrix; j++)
                {
                    int currentSum = SumMatrix(i, j, sizeOfSquarMatrix, mattrix);
                    maxSum = maxSum > currentSum ? maxSum : currentSum;
                }
            }
            Console.WriteLine(maxSum);
        }

        // Calculations
        private static int SumMatrix(int x, int y, int size, List<int[]> mattrix)
        {
            // x and y must be validated!
            int sum = 0;

            for (int i = x; i < x + size; i++)
            {
                for (int j = y; j < y + size; j++)
                {
                   sum += mattrix[i][j];
                }
            }

            return sum;
        }
    }
}