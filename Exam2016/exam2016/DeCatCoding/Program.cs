namespace DeCatCoding
{
    using System;
    class Program
    {
        static void Main()
        {
            var textToDecode = Console.ReadLine().Split();
            var decodedtext = new string[textToDecode.Length];
            for (int i = 0; i < textToDecode.Length; i++)
            {
                decodedtext[i] = WordToDecode(textToDecode[i]);
            }
            Console.WriteLine(string.Join(" ", decodedtext));

        }
        public static string WordToDecode(string input)
        {
            string result = "";
            int zeroCode = 'a';
            ulong intResult = 0;
            int base21 = 21;
            ulong base26 = 26;
            // magic
            // decode from 21 base to binary
            for (int i = 0; i < input.Length; i++)
            {
                intResult = intResult * (ulong) base21 + (ulong) (input[i] - zeroCode);
            }

            // code to base 26
            do
            {
                result = char.ConvertFromUtf32(((int) (intResult % base26) + zeroCode)) + result;
                intResult /= base26;
            }
            while (intResult > 0);

            return result;
        }
    }
}
