namespace FindWord
{
    using System;
    using System.Text;
    using System.Threading;
    class FindWord
    {
        static void Main()
        {
            //Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            int startIndex = 0;
            int endIndex = text.IndexOf('.');
            StringBuilder result = new StringBuilder();
            string Sentence;
            while (endIndex > 0)
            {
                Sentence = text.Substring(startIndex, endIndex - startIndex);

                if (IsContainWord(Sentence.Trim(), word))
                {
                    result.Append(Sentence.Trim());
                    result.Append(". ");
                }

                startIndex = endIndex + 1;
                endIndex = text.IndexOf('.', startIndex);
            }
            Console.WriteLine(result.ToString().Trim());
        }

        static bool IsContainWord(string temp, string word)
        {
            int subStart = temp.IndexOf(word, 0);
            bool print = false;
            int checkStartIndex;
            int checkEndIndex;
            while (!print && subStart >= 0)
            {
                checkStartIndex = subStart - 1;
                checkEndIndex = subStart + word.Length;

                print = (checkStartIndex < 0 || !char.IsLetter(temp[checkStartIndex])) &&
                        (checkEndIndex >= temp.Length || !char.IsLetter(temp[checkEndIndex]));

                subStart = temp.IndexOf(word, checkEndIndex);
            }
            return print;
        }
    }
}