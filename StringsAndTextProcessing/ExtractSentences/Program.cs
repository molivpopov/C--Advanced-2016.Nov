namespace ExtractSentences
{
    using System;
    using System.Text;
    class Program
    {
        static int FindEnd(string text, int indexOfInWord)
        {
            while (indexOfInWord < text.Length && text[indexOfInWord] != '.') indexOfInWord++;
            return indexOfInWord;
        }
        static int FindeStart(string text, int indexOfInWord)
        {
            while (indexOfInWord > 0 && text[indexOfInWord] != '.')
                indexOfInWord--;
            while (!char.IsLetter(text[indexOfInWord]))
                indexOfInWord++;
            return indexOfInWord;
        }

        static bool FindWord(string text, string word, ref int index)
        // return true if find real word
        // (separated by non-letter symbols)
        {
            int symbolAfterWord;
            index = text.IndexOf(word, index + word.Length);
            if (index == -1)
                return false;
            bool isWord = true;
            symbolAfterWord = index + word.Length;
            if (index > 0)
                isWord = !char.IsLetter(text[index - 1]);
            if (symbolAfterWord >= text.Length)
                return isWord;
            isWord = isWord && (!char.IsLetter(text[symbolAfterWord]));
            if (!isWord)
                return FindWord(text, word, ref index);
            return true;
        }

        static void Main()
        {
            string word = Console.ReadLine();
            string wordToLower = word.ToLower();
            string text = Console.ReadLine();
            string textToLower = text.ToLower();
            StringBuilder sentensToPrint = new StringBuilder();
            int startIndex = 0;
            int endIndex;
            int pos = -1;

            while (FindWord(textToLower, wordToLower, ref pos))
            {
                startIndex = FindeStart(textToLower, pos);
                endIndex = FindEnd(textToLower, pos);
                pos = endIndex - 1;
                sentensToPrint.Append(text, startIndex, endIndex - startIndex);
                sentensToPrint.Append(". ");
            }
        }
    }
}