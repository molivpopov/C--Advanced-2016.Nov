namespace FillMatrix
{
    using System;
    public class FillMatrix
    {
        static void Main()
        {
            //Stratup
            int sizeOfMatrix = int.Parse(Console.ReadLine());
            string typeOfMatrix = Console.ReadLine();

            //Engine
            switch (typeOfMatrix)
            {
                case "a":
                    PrintMattrix(MattrixTypeA(sizeOfMatrix));
                    break;
                case "b":
                    PrintMattrix(MattrixTypeB(sizeOfMatrix));
                    break;
                case "c":
                    PrintMattrix(MattrixTypeC(sizeOfMatrix));
                    break;
                case "d":
                    PrintMattrix(MattrixTypeD(sizeOfMatrix));
                    break;
                default:
                    Console.WriteLine("Invalid type of command");
                    break;

            }

        }

        // Factory
        private static int[,] MattrixTypeA(int size)
        {
            var mattrix = new int[size, size];

            // magic
            for (int i = 0; i < size * size; i++)
            {
                int y = i / size;
                int x = i % size;
                mattrix[x, y] = i + 1;
            }

            return mattrix;
        }
        private static int[,] MattrixTypeB(int size)
        {
            var mattrix = new int[size, size];

            // magic
            for (int i = 0; i < size * size; i++)
            {
                int y = i / size;
                int isOdd = (y) % 2;
                int isNegativ = 1 - isOdd * 2;
                int x = (isOdd * (size - 1)) + isNegativ * (i % size);
                mattrix[x, y] = i + 1;
            }

            return mattrix;
        }
        private static int[,] MattrixTypeC(int size)
        {
            var mattrix = new int[size, size];
            int number = 1;

            // magic
            for (int i = 0; i < size; i++)
            {
                int y = size - 1 - i;
                int x = 0;

                for (int j = 0; j <= i; j++)
                {
                    mattrix[y, x] = number;
                    mattrix[size - 1 - y, size - 1 - x] = size * size + 1 - number++;
                    x++; y++;
                }

            }
            return mattrix;
        }
        private static int[,] MattrixTypeD(int size)
        {
            var mattrix = new int[size, size];

            // magic
            int numbers = 1;
            int dx = 0, dy;
            int x = 0, y = 0, step = size - 1;

            for (int i = size * 2 - 1; i >= 1; i--)
            {
                int period = (size * 2 - i) % 4;
                dy = (2 - period) * (period % 2);

                for (int k = 0; k < step; k++)
                {
                    mattrix[y, x] = numbers++;
                    x += dx; y += dy;
                }

                step = i / 2;
                dx = dy;
            }
            mattrix[y, x] = numbers;

            return mattrix;
        }

        //Print
        private static void PrintMattrix(int[,] matrtixToPrint)
        {
            for (int outer = matrtixToPrint.GetLowerBound(0);
                outer <= matrtixToPrint.GetUpperBound(0);
                outer++)
            {
                string result = "";
                for (int inner = matrtixToPrint.GetLowerBound(1);
                    inner <= matrtixToPrint.GetUpperBound(1);
                    inner++)
                {
                    result += matrtixToPrint[outer, inner] + " ";
                    // Console.WriteLine(string.Join());
                }
                Console.WriteLine(result.Trim());

            }

        }
    }
}