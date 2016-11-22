namespace NFactorial
{
    using System;
    class Program
    {
        const int numberOfDigit = 160; //1<n<100 - need of 160 decimal digits
        static void Main()
        {
            int n = int.Parse(Console.ReadLine()); // 1<n<100 - need of 160 decimal digits

            int[] result = new int[numberOfDigit];
            result[numberOfDigit - 1] = 1; // init first number

            for (int i = 1; i <= n; i++)
            {
                product(result, i);
                NormalizNumber(result);
            }

            Console.WriteLine(string.Join("", result).TrimStart('0'));
        }
        static void product(int[] arr, int numToprod)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] *= numToprod;
            }
        }
        static void NormalizNumber(int[] arr)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i] > 9)
                {
                    arr[i - 1] += arr[i] / 10;
                    arr[i] %= 10;
                }
            }
        }
    }
}