namespace SeriesOfLetters
{
    using System;
    using System.Text;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            char element = input[0];
            StringBuilder result = new StringBuilder(element.ToString());

            for (int i = 1; i < input.Length; i++)
            {
                if (element != input[i])
                {
                    element = input[i];
                    result.Append(element);
                }
            }
            Console.WriteLine(result);
        }
    }
}
