namespace SquareRoot
{
    using System;
    class Program
    {
        public const string invalidNumber = "Invalid number";
        public const string goodBye = "Good bye";
        static void Main()
        {
            try
            {
                var inputNumber = double.Parse(Console.ReadLine());
                if (inputNumber < 0)
                {
                    throw new ArgumentException(invalidNumber);
                }
                Console.WriteLine("{0:f3}", Math.Sqrt(inputNumber));
            }
            catch 
            {
                Console.WriteLine(invalidNumber);
            }

            Console.WriteLine(goodBye);
    
        }
    }
}
