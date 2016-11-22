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
            var n = int.Parse(Console.ReadLine().Split(' ')[0]);
            var mattrix = new List<int>();
            var differentNumber = new List<int>();

            for (int i = 0; i < n; i++)
            {
                Console.ReadLine().Split(' ').Select(int.Parse).ToList().ForEach(mattrix.Add);
            }

            int maxSizeNeighbour = int.MinValue;

            for (int i = 0; i < mattrix.Count; i++)
            {
                if (!differentNumber.Exists(x => x == mattrix[i]))
                {
                    var indexes = new List<int>();
                    differentNumber.Add(mattrix[i]);
                    mattrix.FindAll(x => { if (x == mattrix[i]) indexes.Add(mattrix.IndexOf(x)); return x == mattrix[i]; });
                    int sizeNeighbour = countOfNeighbour(1, 0, n, indexes);
                    maxSizeNeighbour = sizeNeighbour > maxSizeNeighbour ? sizeNeighbour : maxSizeNeighbour;
                }
            }

            Console.WriteLine(maxSizeNeighbour);
        }
        private static int countOfNeighbour(int count, int firstIndex, int heigtOfMattrix, List<int> mattrix)
        {
            var firstItem = mattrix[firstIndex];
            mattrix.RemoveAt(firstIndex);

            if (mattrix.Count == 0)
            {
                return count;
            }

            // this statment find the first index of matched 
            firstIndex = mattrix.Find(x => (Math.Abs(x - firstItem) <= heigtOfMattrix && Math.Abs(x - firstItem) % heigtOfMattrix <= 1));

            if (firstIndex != 0)
            {
                count++;
                firstIndex = mattrix.IndexOf(firstIndex);
            }

            return countOfNeighbour(count, firstIndex, heigtOfMattrix, mattrix);
        }
    }
}