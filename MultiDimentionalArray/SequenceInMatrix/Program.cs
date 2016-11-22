namespace SequenceInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        const int NumberOfAxis = 4;
        static void Main()
        {
            // Set up
            var input = Console.ReadLine().Split(' ');
            var n = int.Parse(input[0]);
            var mattrix = new List<int[]>();
            int longestLine = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                mattrix.Add(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }


            //This Loops scan all element of the mattrix
            for (int i = 0; i < mattrix.Count; i++)
            {
                for (int j = 0; j < mattrix[i].Length; j++)
                {
                    int currentLineLengt = LongestLine(i, j, mattrix);
                    longestLine = longestLine > currentLineLengt ? longestLine : currentLineLengt;
                }
            }
            Console.WriteLine(longestLine);
        }

        // This method finde the longest line starting from point x,y at all axis
        private static int LongestLine(int x, int y, List<int[]> mattrix)
        {
            // x and y must be validated!
            int lineLengt = 0;
            // Magic

            int[] dx = new int[] { 1, 1, 1, 0 };
            int[] dy = new int[] { 1, 0, -1, -1 };
            int startValue = mattrix[x][y];

            for (int i = 0; i < NumberOfAxis; i++)
            {
                int xx = x, yy = y;
                int count = 0;

                //this loop scan the
                do
                {
                    xx += dx[i]; yy += dy[i];
                    count++;
                }
                while (xx < mattrix.Count && xx >= 0 && yy < mattrix[i].Length && yy >= 0 && startValue == mattrix[xx][yy]);

                xx = x - dx[i]; yy = y - dy[i];

                while (xx < mattrix.Count && xx >= 0 && yy < mattrix[i].Length && yy >= 0 && startValue == mattrix[xx][yy])
                {
                    xx -= dx[i]; yy -= dy[i];
                    count++;
                }

                lineLengt = lineLengt > count ? lineLengt : count;
            }

            return lineLengt;
        }
    }
}