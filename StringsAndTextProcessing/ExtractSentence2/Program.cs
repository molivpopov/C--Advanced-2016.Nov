namespace ExtractSentence2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main()
        {
            //Setup
            var allSeparators = new List<char>();
            var sentenceConteningWord = new List<string>();
            string word = Console.ReadLine();
            string text = Console.ReadLine();

            // find separators
            text.ToList().ForEach(x => { if (!char.IsLetter(x) && !allSeparators.Contains(x)) { allSeparators.Add(x); }; });
            var separators = allSeparators.ToArray();

            // split sentences
            var sentences = text.Split('.').Select(x => x.Trim() + ".").ToArray();

            foreach (var item in sentences)
            {
                if (item.Split(separators).Contains(word))
                {
                    sentenceConteningWord.Add(item);
                }
            }
            Console.WriteLine(string.Join(" ", sentenceConteningWord));
        }
    }
}