namespace AnimalPlanet
{
    using System;
    using System.Linq;
    class Program
    {
        public const string ReachEnd = "END";
        public const char TopSymbol = 'T';
        public const char BottomSymbol = 'B';
        public const char LeftSymbol = 'L';
        public const char RightSymbol = 'R';
        public static int baseColumnCount;
        public const string PorcupinWon = "The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.";
        public const string RabbitWon = "The rabbit WON with {1} points. The porcupine scored {0} points only.";
        public const string SameScore = "Both units scored {0} points. Maybe we should play again?";
        static void Main()
        {
            //Setup
            baseColumnCount = int.Parse(Console.ReadLine());
            var totalRowCount = int.Parse(Console.ReadLine());
            //Setup Map and fill
            var map = new int[totalRowCount][];
            for (int i = 0; i < totalRowCount / 2; i++)
            {
                map[i] = new int[(i + 1) * baseColumnCount];
                int last = totalRowCount - i - 1;
                map[last] = new int[(i + 1) * baseColumnCount];

                for (int j = 0; j < map[i].Length; j++)
                {
                    map[i][j] = (i + 1) * (j + 1);
                    map[last][j] = (last + 1) * (j + 1);
                }
            }
 
            // [0] - row, [1] - col
            var CoordOfP = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var CoordOfR = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rabbitScore = map[CoordOfR[0]][CoordOfR[1]];
            map[CoordOfR[0]][CoordOfR[1]] = -1;
            int porcupineScore = map[CoordOfP[0]][CoordOfP[1]];
            map[CoordOfP[0]][CoordOfP[1]] = -1;

            //Engine
            string commands = "";
            while ((commands = Console.ReadLine()) != ReachEnd)
            {
                // Magic
                var parameter = commands.Split();
                var step = int.Parse(parameter[2]);

                if (parameter[0] == "R")
                {                   
                    rabbitScore += MoveTo(parameter[1][0], CoordOfR, map, step);
                }
                else
                {
                    for (int i = 0; i < step; i++)
                    {
                        porcupineScore += MoveTo(parameter[1][0], CoordOfP, map, 1);
                    }
                }
            }
            if (rabbitScore > porcupineScore)
            {
                Console.WriteLine(RabbitWon, porcupineScore, rabbitScore);
                return;
            }
            if (rabbitScore < porcupineScore)
            {
                Console.WriteLine(PorcupinWon, porcupineScore, rabbitScore);
                return;
            }
            Console.WriteLine(SameScore, rabbitScore);


        }
        public static int CheckPos(int number, int addStep, int start, int end)
        {
            //magic
            int lim = end - start;
            number += addStep % lim;
            //number %= lim;
            if (number < start)
            {
                number += lim;
                return number;
            }
            if (number >= end)
            {
                number -= lim;
            }

            return number;
        }
        public static int MoveTo(char direction, int[] pos, int[][] map, int sizeOfstep)
        {
            // magic
            int score = 0;
            int row = pos[0];
            int col = pos[1];
            map[row][col] = 0;
            int drow = 0, dcol = 0;

            if (direction == TopSymbol)
            {
                drow = -sizeOfstep;
            }
            if (direction == BottomSymbol)
            {
                drow = sizeOfstep;
            }
            if (direction == LeftSymbol)
            {
                dcol = -sizeOfstep;
            }
            if (direction == RightSymbol)
            {
                dcol = sizeOfstep;
            }

            do
            {
                int k = col / baseColumnCount;
                row = CheckPos(row, drow, k, map.Length - k);
                col = CheckPos(col, dcol, 0, map[row].Length);
                drow = -Math.Sign(drow);
                dcol = -Math.Sign(dcol);
            }
            while (map[row][col] == -1);

            pos[0] = row;
            pos[1] = col;
            score = map[row][col];
            map[row][col] = -1;

            return score;
        }
    }
}
