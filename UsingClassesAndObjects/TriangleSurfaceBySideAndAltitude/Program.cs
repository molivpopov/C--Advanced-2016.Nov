using System;

namespace TriangleSurface

{
   class TriangleSurfaceBySA
    {
        static void Main()
        {
            var a = double.Parse(Console.ReadLine());
            var ha = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:f2}", Surface(a, ha));
        }
        public static double Surface(double a, double ha) // by side & altitude
        {
            return (a * ha / 2);
        }
    }
}