namespace LeapYear
{
    using System;
    class LeapYear
    {
        static void Main()
        {
            int inYear = int.Parse(Console.ReadLine());

            //This is Julian ruls to determining the Leap year
            bool isLeap = inYear % 4 == 0;

            //This is Gregorian ruls to determining the Leap year
            isLeap = isLeap && (!(inYear % 100 == 0) || (inYear % 400 == 0));

            string yearIs = isLeap ? "Leap" : "Common";
            Console.WriteLine(yearIs);
        }
    }
}