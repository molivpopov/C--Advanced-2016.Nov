namespace FunctionalNumeralSystem
{
    using System;
    using System.Linq;
    using System.Numerics;
    class Program
    {
        static void Main()
        {
            var separators = new char[] { ',', ' ' };
            BigInteger prod = 1;
            ulong baseSystem = 16;
            var digits = new string[] { "ocaml", "haskell", "scala", "f#", "lisp", "rust", "ml", "clojure", "erlang", "standardml", "racket", "elm", "mercury", "commonlisp", "scheme", "curry" };
            var numbers = Console.ReadLine().Split(',').Select(x => x.Trim()).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                string thisNumber = numbers[i];
                ulong number = 0;

                do
                {
                    int p = 0;
                    while (thisNumber.IndexOf(digits[p]) != 0)
                    {
                        p++;
                    }
                    thisNumber = thisNumber.Remove(0, digits[p].Length);
                    number = number * baseSystem + (ulong)p;

                }
                while (thisNumber.Length > 0);
                prod *= (BigInteger) number;
                //int number = Array.FindIndex(digits, x => x == numbers[i]);
            }
            Console.WriteLine(prod);
        } 
    }
}
