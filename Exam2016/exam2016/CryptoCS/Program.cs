namespace CryptoCS
{
    using System;
    using System.Numerics;
    class Program
    {
        static void Main()
        {
            int baseNine = 9;
            var numberBase26 = Console.ReadLine();
            var action = Console.ReadLine();
            var numberBase7 = Console.ReadLine();

            BigInteger numberBase26Int = FromAnyTobinary(numberBase26, 26);
            BigInteger numberBase7Int = FromAnyTobinary(numberBase7, 7);
            BigInteger resultBinary = action == "+" ? numberBase26Int + numberBase7Int : numberBase26Int - numberBase7Int;
            string resultBase9 = "";
            while (resultBinary > 0)
            {
                resultBase9 = (resultBinary % baseNine).ToString() + resultBase9;
                resultBinary /= baseNine;
            }
            Console.WriteLine(resultBase9);
        }

        public static BigInteger FromAnyTobinary(string input, ulong baseNumber)
        {
            BigInteger result = 0;
            ulong zeroCode = baseNumber > 9 ? zeroCode = 'a' : zeroCode = '0';
            //magic
            foreach (var item in input)
            {
                result = result * baseNumber + item - zeroCode;
            }

            return result;
        }
    }
}