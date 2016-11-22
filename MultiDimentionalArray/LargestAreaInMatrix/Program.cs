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
            var mattrix = new List<Mattrix>();
            var equalNumber = new List<Mattrix>();

            for (int i = 0; i < n; i++)
            {
                int k = 0;
                Console.ReadLine().Split(' ').Select(x => new Mattrix(int.Parse(x), k++, i)).ToList().ForEach(mattrix.Add);
            }

            int maxSizeNeighbour = int.MinValue;
            foreach (var item in mattrix)
            {
                if (!equalNumber.Exists(x => x.Number == item.Number))
                {
                    equalNumber.Add(item);
                    var pp = mattrix.FindAll(x => x.Number == item.Number);
                    int sizeNeighbour = countOfNeighbour(1, 0, pp);
                    maxSizeNeighbour = sizeNeighbour > maxSizeNeighbour ? sizeNeighbour : maxSizeNeighbour;
                }
            }

            Console.WriteLine(maxSizeNeighbour);
        }
        private static int countOfNeighbour(int count, int firstIndex, List<Mattrix> mattrix)
        {
            var firstItem = mattrix[firstIndex];
            mattrix.RemoveAt(firstIndex);

            if (mattrix.Count == 0)
            {
                return count;
            }

            var firstNeighbour = mattrix.Find(x => (Math.Abs(x.X - firstItem.X) <= 1 && Math.Abs(x.Y - firstItem.Y) <= 1));

            if (firstNeighbour == null)
            {
                firstIndex = 0;
            }
            else
            {
                count++;
                firstIndex = mattrix.IndexOf(firstNeighbour);
            }

            return countOfNeighbour(count, firstIndex, mattrix);
        }
    }
    public class Mattrix
    {
        public Mattrix(int number, int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Number = number;
        }
        public int Number { get; }
        public int X { get; }
        public int Y { get; }
    }
}