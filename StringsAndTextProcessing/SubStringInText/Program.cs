namespace SubStringInText
{
    using System;
    class Program
    {
        static void Main()
        {
            string pattern = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();
            int posIntext = -1;
            int countOftext = -1;

            do
            {
                posIntext = text.IndexOf(pattern, posIntext + 1);
                countOftext++;
            }
            while (posIntext != -1);

            Console.WriteLine(countOftext);
        }
    }
}