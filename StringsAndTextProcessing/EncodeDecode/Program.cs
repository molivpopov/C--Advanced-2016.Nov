namespace EncodeDecode
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            string key = Console.ReadLine();

            if (text.Length == 0 || key.Length == 0)
            {
                throw new ArgumentNullException("Strings must not be null");
            }

            // when code coded text with the same key - you decode it! the process is two-way
            Console.WriteLine("input text:{0}", text);
            string code = CodeDecode(text, key);
            Console.WriteLine("Coded text:{0}", code);
            Console.WriteLine("Decoded text:{0}", CodeDecode(code, key));

        }
        public static string CodeDecode(string text, string key)
        {
            // magic
            var result = new List<char>();

            int index = -1;
            for (int i = 0; i < text.Length; i++)
            {
                index++;
                if (index == key.Length)
                {
                    index = 0;
                }
                
                result.Add((char) (text[i] ^ key[index]));
            }
            return new string(result.ToArray());
        }
    }
}
