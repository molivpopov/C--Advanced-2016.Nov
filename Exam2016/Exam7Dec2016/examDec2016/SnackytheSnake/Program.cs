namespace SnackytheSnake
{
    using System;
    using System.Linq;
    class Program
    {
        public const string WhenLenghtDropToZero = "Snacky will starve at [{0},{1}]";
        public const string WhenGetOut = "Snacky will get out with length {0}";
        public const string LostInDepth = "Snacky will be lost into the depths with length {0}";
        public const string HitARock = "Snacky will hit a rock at [{0},{1}]";
        public const string StukInTheDen = "Snacky will be stuck in the den at [{0},{1}]";
        static void Main()
        {
            var dimensions = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
            int sizeRow = dimensions[0];
            int sizeCol = dimensions[1];

            var den = new char[sizeRow][].Select(x => x = Console.ReadLine().ToArray()).ToArray();

            int colOfEntrence = -1;
            while (den[0][++colOfEntrence] != 's') { };

            int posOfSnackyR = 0, posOfSnackyC = colOfEntrence;
            int snackyLengt = 3;

            var commands = Console.ReadLine().Split(',').ToArray();

            for (int turn = 0; turn < commands.Length; turn++)
            {
                if ((turn + 1) % 5 == 0)
                {
                    snackyLengt--;  
                };

                if (commands[turn] == "l") { posOfSnackyC--; };
                if (commands[turn] == "r") { posOfSnackyC++; };
                if (commands[turn] == "u") { posOfSnackyR--; };
                if (commands[turn] == "d") { posOfSnackyR++; };

                posOfSnackyC = Check(posOfSnackyC, sizeCol);
                if (posOfSnackyR >= sizeRow || posOfSnackyR < 0)
                {
                    Console.WriteLine(LostInDepth, snackyLengt);
                    return;
                }

                if (den[posOfSnackyR][posOfSnackyC] == '*') // Snacky Eat
                {
                    den[posOfSnackyR][posOfSnackyC] = '.';
                    snackyLengt++;
                }
                if (den[posOfSnackyR][posOfSnackyC] == 's')
                {
                    Console.WriteLine(WhenGetOut, snackyLengt);
                    return;
                }
                if (den[posOfSnackyR][posOfSnackyC] == '#')
                {
                    Console.WriteLine(HitARock, posOfSnackyR, posOfSnackyC);
                    return;
                }
                if (snackyLengt == 0)
                {
                    Console.WriteLine(WhenLenghtDropToZero, posOfSnackyR, posOfSnackyC);
                    return;
                }
            }
            Console.WriteLine(StukInTheDen, posOfSnackyR, posOfSnackyC);
        }
        public static int Check(int number, int lims)
        {
            if (number < 0)
            {
                number += lims;
            }
            if (number >= lims)
            {
                number -= lims;
            }
            return number;
        }
    }
}
