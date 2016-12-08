namespace MagicWords
{
    using System;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            var words = new string[number].Select(x => x = Console.ReadLine()).ToArray();
            var indexes = new int[number];
            for (int i = number - 1; i >= 0; i--)
            {
                indexes[i] = (words[i].Length % (number + 1)) * (number + 1) + i;
            }

            Array.Sort(indexes);

            string toPrint = "";
            int pos = 0;
            bool hasWord = true;
            while (hasWord)
            {
                hasWord = false;
                for (int i = 0; i < number; i++)
                {
                    int index = indexes[i] % (number + 1);
                    //hasWord = false;
                    if (pos < words[index].Length)
                    {
                        toPrint += words[index][pos];
                        hasWord = true;
                    }

                }
                pos++;
            }
            Console.WriteLine(toPrint);

        }
    }
}
