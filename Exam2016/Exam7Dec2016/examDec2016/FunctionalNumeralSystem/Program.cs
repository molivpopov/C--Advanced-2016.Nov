namespace FunctionalNumeralSystem
{
    using System;
    using System.Linq;
    using System.Numerics;
    class Program
    {
        static void Main()
        {
            BigInteger prod = 1;
            var digits = new string[] { "ocaml", "haskell", "scala", "f#", "lisp", "rust", "ml", "clojure", "erlang", "standardml", "racket", "elm", "mercury", "commonlisp", "scheme", "curry" };
            ulong baseSystem = (ulong) digits.Length;
            var numbers = Console.ReadLine().Split(',').Select(x => x.Trim()).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                string thisNumber = numbers[i];
                ulong number = 0;

                do
                {
                    int currentDigit = 0;
                    while (thisNumber.IndexOf(digits[currentDigit]) != 0)
                    {
                        currentDigit++;
                    }
                    thisNumber = thisNumber.Remove(0, digits[currentDigit].Length);
                    number = number * baseSystem + (ulong) currentDigit;
                }
                while (thisNumber.Length > 0);
                prod *= (BigInteger) number;
            }
            Console.WriteLine(prod);
        }
    }
}
