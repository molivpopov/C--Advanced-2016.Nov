namespace SafeFlights
{
    using System;
    using System.Collections.Generic;

    class Startup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var A = new List<int>[n];
            for (int i = 0; i < n; ++i)
            {
                A[i] = new List<int>();
                A[i].Add(-42);
                A[i].Add(n + 42);
            }

            while (true)
            {
                string[] ab = Console.ReadLine().Split(' ');
                int a = int.Parse(ab[0]);
                int b = int.Parse(ab[1]);

                if (a < 0)
                {
                    break;
                }

                A[a].Add(b);
                A[b].Add(a);
            }

            var disjointSet = new int[n];
            for (int i = 0; i < n; ++i)
            {
                disjointSet[i] = -1;
            }

            for (int i = 0; i < n; ++i)
            {
                A[i].Sort();

                for (int j = 1; j < A[i].Count - 1; ++j)
                {
                    if (A[i][j] != A[i][j - 1] && A[i][j] != A[i][j + 1])
                    {
                        Unite(disjointSet, i, A[i][j]);
                    }
                }
            }

            int sum = 0;

            var component = new int[n];

            for (int i = 0; i < n; ++i)
            {
                ++component[Find(disjointSet, i)];
            }

            for (int i = 0; i < n; ++i)
            {
                sum += component[i] * (component[i] - 1) / 2;
            }

            Console.WriteLine(sum);
        }

        static int Find(int[] ds, int x)
        {
            if (ds[x] < 0)
            {
                return x;
            }

            ds[x] = Find(ds, ds[x]);
            return ds[x];
        }

        static void Unite(int[] ds, int x, int y)
        {
            x = Find(ds, x);
            y = Find(ds, y);
            if (x != y)
            {
                ds[x] = y;
            }
        }
    }
}
