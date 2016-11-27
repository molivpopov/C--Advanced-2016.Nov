namespace RandomNumbers
{
    using System;
    class Program
    {
        static void Main()
        {
            var randomNumber = new Random();
            Console.WriteLine(randomNumber.Next(100, 200));
        }
    }
}
