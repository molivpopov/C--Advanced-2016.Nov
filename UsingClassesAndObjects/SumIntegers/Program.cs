namespace SumIntegers
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            var sum = Console.ReadLine().Split(' ').Select(int.Parse).ToArray().Sum();
            Console.WriteLine(sum);
        }
    }
}
