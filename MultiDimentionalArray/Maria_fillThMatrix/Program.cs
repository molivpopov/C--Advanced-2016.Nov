namespace Maria_fillThMatrix
{
    using System;
    class HW1_FillTheMatrix
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string c = Console.ReadLine();

            int[,] matrix = new int[n, n];

            if (c == "a")
            {
                int rows = n;
                int cols = n;
                int count = 0;

                for (int row = 0; row < rows; row++)
                {
                    count++;
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = count;
                        count += n;
                    }
                    count -= n * n;
                }
            }

            else if (c == "b")
            {
                int rows = n;
                int cols = n;
                int count = 0;
                int temp = 7;

                for (int row = 0; row < rows; row++)
                {
                    count++;

                    for (int col = 0; col < cols; col++)
                    {
                        if (col == 0)
                        {
                            matrix[row, col] = count;
                        }
                        else if (col % 2 == 0)
                        {
                            matrix[row, col] = matrix[row, col - 1] + count + row;
                        }
                        else
                        {
                            matrix[row, col] = matrix[row, col - 1] + temp;
                        }
                    }
                    temp -= 2;
                }
            }
            else if (c == "c")
            {
                int rows = 0;
                int cols = 0;
                int count = 1;

                for (int i = n - 1; i >= 0; i--)
                {
                    for (cols = 0; cols <= rows; cols++)
                    {
                        matrix[i, cols] = count;
                        count++;
                        i++;
                    }
                    i -= cols;
                    rows++;
                }

                for (cols = 1; cols < n; cols++)
                {
                    int j = cols;
                    for (rows = 0; rows < n - cols; rows++)
                    {
                        matrix[rows, j] = count;
                        count++;
                        j++;
                    }
                    j -= 2;
                }
            }
            else if (c == "d")
            {
                int offset = 0;
                int ROW = 0;
                int COL = 0;
                int digit = 1;
                while (digit <= n * n)            //Filling matrix
                {
                    for (ROW = offset; ROW < n - offset; ROW++)
                    {
                        COL = offset;
                        matrix[ROW, COL] = digit;
                        digit++;
                    }
                    for (COL = 1 + offset; COL < n - offset; COL++)
                    {
                        ROW = n - 1 - offset;
                        matrix[ROW, COL] = digit;
                        digit++;
                    }
                    for (ROW = n - 2 - offset; ROW >= offset; ROW--)
                    {
                        COL = n - 1 - offset;
                        matrix[ROW, COL] = digit;
                        digit++;
                    }
                    for (COL = n - 2 - offset; COL >= offset + 1; COL--)
                    {
                        ROW = offset;
                        matrix[ROW, COL] = digit;
                        digit++;
                    }
                    offset++;
                }

            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0}{1}", matrix[row, col], col == n - 1 ? '\n' : ' ');
                }
            }
        }
    }
}
