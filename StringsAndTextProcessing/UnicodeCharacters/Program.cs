namespace UnicodeCharacters
{
    using System;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(string.Format("\\u{0:X4}", (int)input[i]));
            }
            Console.WriteLine();
        }
    }
}