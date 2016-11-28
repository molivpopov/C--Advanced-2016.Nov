namespace ReplaceTags
{
    using System;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int pos;

            int startURL = 0, endURL, openTEXT, closeTEXT = -4;
            pos = input.IndexOf("<a");

            if (pos == -1)
            {
                Console.WriteLine("there isn't a tag");
                return;
            }

            var result = new char[input.Length];
            int j = 0;
            while (pos >= 0)
            {
                for (int i = startURL; i < pos; i++) result[j++] = input[i]; // copy the symbols befor tag <a>
                startURL = pos;
                while (input[startURL] != '"') startURL++;
                endURL = startURL + 1;
                while (input[endURL] != '"') endURL++;
                openTEXT = endURL + 1;
                while (input[openTEXT] != '>') openTEXT++;
                closeTEXT = openTEXT + 1;
                while (input[closeTEXT] != '<') closeTEXT++;
                pos = input.IndexOf("<a", closeTEXT + 4); // 4 symbols for tag </a>
                result[j++] = '[';
                for (int i = openTEXT + 1; i < closeTEXT; i++) result[j++] = input[i]; // copy to result the text
                result[j++] = ']';
                result[j++] = '(';
                for (int i = startURL + 1; i < endURL; i++) result[j++] = input[i];
                result[j++] = ')';
                startURL = closeTEXT + 4;
            }
            for (int i = startURL; i < input.Length; i++) result[j++] = input[i];
            string strResult = new string(result).TrimEnd((char) 0);
            Console.WriteLine(strResult);
        }
    }
}