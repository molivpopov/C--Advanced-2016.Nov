namespace PeshoCode
{
    using System;

    class Program
    {
        static void Main()
        {
            string word = Console.ReadLine();
            int numberOfLine = int.Parse(Console.ReadLine());
            string text = "";
            for (int i = 0; i < numberOfLine; i++)
            {
                text += Console.ReadLine() + " ";
            }
            text = text.Trim();
            int posOfWord = text.IndexOf(word);
            int posOfDot = text.IndexOf(".", posOfWord);
            int posOfWapros = text.IndexOf("?", posOfWord);
            int endPos = posOfDot < posOfWapros ? posOfDot : posOfWapros;
            if (posOfDot < 0) { endPos = posOfWapros; };
            if (posOfWapros < 0) { endPos = posOfDot; };
            int startPos = posOfWord;

            while (startPos >= 0 && text[startPos] != '.' && text[startPos] != '?')
            {
                startPos--;
            }
            startPos++;
            //Console.WriteLine(text.Substring(startPos, endPos - startPos));
            int begin = startPos, end = posOfWord;
            if (text[endPos] == '?')
            {
                begin = posOfWord + word.Length;
                end = endPos;
            }
            string textToSum = text.Substring(begin, end - begin).ToUpper();
            int sumOfASC = 0;
            for (int i = 0; i < textToSum.Length; i++)
            {
                if (textToSum[i] != ' ') { sumOfASC += textToSum[i]; };
            }
            Console.WriteLine(sumOfASC);
        }
    }
}
