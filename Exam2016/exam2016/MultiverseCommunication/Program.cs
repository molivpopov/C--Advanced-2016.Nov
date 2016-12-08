namespace MultiverseCommunication
{
    using System;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] foreignDigit = { "CHU", "TEL", "OFT", "IVA", "EMY", "VNB", "POQ", "ERI", "CAD", "K-A", "IIA", "YLO", "PLA" };
            ulong baseSystem = (ulong) foreignDigit.Length;
            ulong result = 0;

            while (input.Length > 0)
            {
                string digit = input.Substring(0, 3);
                int p = Array.FindIndex(foreignDigit, x => x == digit);
                result = result * baseSystem + (ulong) p;
                input = input.Remove(0, 3);
            }
            Console.WriteLine(result);
        }
    }
}
