namespace Workdays
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    class Workdays
    {
        public const int daysInWeek = 7;
        static void Main()
        {
            //Set Up
            var endDate = DateTime.Parse(Console.ReadLine());
            var toDay = DateTime.Today;
            //validate
            if (endDate <= toDay)
            {
                throw new ArgumentException("Period must be positiv!");
            }
            var listOfPublicHolydays = new string[]
            {
                "25-12-2016",
                "26-12-2016",
                "31-12-2016",
                "1-1-2017",
                "3-3-2017",
                "5-5-2017",
                "6-9-2017",
     
                "22-9-2017",
                "25-12-2017",
                "26-12-2017",
                "31-12-2017"
            };
            // find all public hollidays - not sunday and saturday
            var publicHollydays = listOfPublicHolydays.Select(DateTime.Parse).ToList().FindAll(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
            int workDays = endDate.Subtract(toDay).Days + 1; // I suggest include today and End in numbers of days
            if (toDay.DayOfWeek == DayOfWeek.Saturday)
            {
                workDays -= 2;
            }

            if (toDay.DayOfWeek == DayOfWeek.Sunday)
            {
                workDays -= 1;
            }
            if (endDate.DayOfWeek == DayOfWeek.Sunday)
            {
                workDays -= 2;
            }
            if (endDate.DayOfWeek == DayOfWeek.Saturday)
            {
                workDays -= 1;
            }

            workDays -= (workDays / daysInWeek) * 2; // subtract 2 days every week

            var publicHDBetweenDate = publicHollydays.FindAll(x => x >= toDay && x <= endDate);
            workDays -= publicHDBetweenDate.Count;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr"); //I have not cyrilic to set bg
            Console.WriteLine("between {0} and {1} have {2} work days",toDay.ToShortDateString(), endDate.ToShortDateString(), workDays);
        }
    }
}
