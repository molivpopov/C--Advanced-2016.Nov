namespace DayOfWeek
{
    using System;
    using System.Globalization;
    using System.Threading;
    class Program
    {
        static void Main()
        {
            var toDay = DateTime.Today;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fr-BGR");
            /*
            foreach (var item in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            {
                //Console.WriteLine(item.Name);
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(item.Name);
                Console.WriteLine("Culture Name:{0} Date:{1}",item.Name, toDay.ToLongDateString());

            }
            */
            Console.WriteLine("the day:{0} is {1}", toDay.ToShortDateString(), toDay.DayOfWeek);
        }
    }
}
