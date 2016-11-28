namespace ReverseString
{
    using System;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int length = input.Length;
            var reversed = new char[length];

            for (int i = 0; i <= length / 2; i++)
            {
                reversed[i] = input[length - i - 1];
                reversed[length - i - 1] = input[i];
            }

            Console.WriteLine(reversed);
        }
    }
}