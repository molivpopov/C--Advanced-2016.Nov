namespace NumberAsArray
{
    using System;
    class Program
    {
        static void Main()
        {
            // Start Up
            var lenghts = Console.ReadLine();// this is unnecessarily

            var shortNumbers = Console.ReadLine().Split(' ');
            var longNumbers = Console.ReadLine().Split(' ');
            string[] xchngString;

            int shortNumberLength = shortNumbers.Length;
            int longNumberLength = longNumbers.Length;
            char zeroCode = ('0');

            //this if always set shortNumbers be shorter than longNumbers
            if (shortNumberLength > longNumberLength)
            {
                xchngString = shortNumbers;
                shortNumbers = longNumbers;
                longNumbers = xchngString;
                shortNumberLength = shortNumbers.Length;
                longNumberLength = longNumbers.Length;
            }

            int[] result = new int[longNumberLength + 1];

            for (int i = 0; i < longNumberLength; i++)
            {
                result[i] += longNumbers[i][0] - zeroCode;
                if (i < shortNumberLength)
                {
                    result[i] += shortNumbers[i][0] - zeroCode;
                }
                BiggerFromTen(result, i);
            }

            // Print
            Console.WriteLine(string.Join(" ", result).TrimEnd('0', ' '));
           
        }

        //This Method normalize a digits in arr
        static void BiggerFromTen(int[] arr, int pos)
        {
            if (arr[pos] > 9)
            {
                arr[pos] %= 10;
                arr[pos + 1]++;
            }
        }
    }
}