namespace _06_StringLength
{
    using System;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (input.Length > 20) input = input.Substring(0, 20);
            Console.WriteLine(input.PadRight(20, '*'));
        }
    }
}