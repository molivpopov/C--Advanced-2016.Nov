using System;

namespace TriangleSurface

{
    class TriangleSurfaceBtTreeSide
    {
        static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());
            var c = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f2}", Surface(a, b, c));
        }
        public static double Surface(double a, double b, double c)
        {
            // Must Validate
            double p = (a + b + c) / 2;
            return Math.Sqrt((double) ((p - a) * (p - b) * (p - c)));
        }
    }
}