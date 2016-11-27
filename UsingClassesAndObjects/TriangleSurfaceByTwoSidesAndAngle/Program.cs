using System;

namespace TriangleSurface

{
    class TriangleSurfaceByTwoSideAndAngle
    {
        static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var b = double.Parse(Console.ReadLine());
            var alfa = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f2}", Surface(a, b, alfa));
        }
        public static double Surface(double a, double b, double alfa)
        {
            return (a * b * Math.Sin(alfa) / 2 );
        }
    }
}