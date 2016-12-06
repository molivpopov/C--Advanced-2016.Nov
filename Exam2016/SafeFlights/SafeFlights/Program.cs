namespace SafeFlights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        public const string ReachEnd = "-1 -1";
        public static int numberOfIslands;
        public const int numberOfIputs = 15000; // Constraints
        public static bool[] isIncluded = new bool[numberOfIputs];

        static void Main()
        {
            numberOfIslands = int.Parse(Console.ReadLine());

            //isIncluded = new bool[numberOfIputs];

            var listOfAllFlights = new List<int>();

            string newFlight;

            while ((newFlight = Console.ReadLine()) != ReachEnd)
            {
                var p = newFlight.Split().Select(int.Parse).ToArray();
                listOfAllFlights.Add(Code(p[0], p[1]));
            }

            var listArray = listOfAllFlights.ToArray();
            var listOfDifferentFlights = new List<int>();

            Array.Sort(listArray);
            ClearEquals(listOfDifferentFlights, listArray);

            //var listOfDifferentFlights = RemoveEqualFlight(listOfAllFlights, 0);
            //listOfDifferentFlights.Sort();
            //AddShortCuts(listOfDifferentFlights, 0, listOfDifferentFlights.Count);
            //var nextArray = listOfDifferentFlights.ToArray();
            //Array.Sort(nextArray);
            //listOfDifferentFlights = new List<int>();
            //ClearEquals(listOfDifferentFlights, nextArray);


            AddShortCuts(listOfDifferentFlights, 0, listOfDifferentFlights.Count);
            //AddShortCuts(listOfDifferentFlights, 0, listOfDifferentFlights.Count);
            //AddShortCuts(listOfDifferentFlights, 0, listOfDifferentFlights.Count);

            //Console.WriteLine(string.Join("\n", PrintFlights(redusedList)));
            //Console.WriteLine("-------------------");
            Console.WriteLine(listOfDifferentFlights.Count);
            Console.WriteLine(string.Join("\n", PrintFlights(listOfDifferentFlights)));

        }
        public static int findIndexOfEquals(int[] flights, int start, int end)
        {
            // magic

            int firstElement = flights[start];
            int indexOfLast = start + 1;
            bool reachEnd = false;

            while (!reachEnd && firstElement == flights[indexOfLast])
            {

                indexOfLast++;
                reachEnd = indexOfLast == end;
            }

            return indexOfLast; // last index of equal area
        }
        public static void AddShortCuts(List<int> list, int start, int end)
        {
            //int firstCount;
            //do
            //{
            //firstCount = list.Count;
            for (int j = start; j < end - 1; j++)
            {
                int kLeft = list[j] / numberOfIslands;
                int kRight = list[j] % numberOfIslands;

                for (int i = j + 1; i < end; i++)
                {
                    if (list[i] / numberOfIslands == kLeft)
                    {
                        IncludList(list, list[i] % numberOfIslands, kRight);
                        return;
                    }
                    if (list[i] / numberOfIslands == kRight)
                    {
                        IncludList(list, kLeft, list[i] % numberOfIslands);
                        return;
                    }

                    if (list[i] % numberOfIslands == kRight)
                    {
                        IncludList(list, kLeft, list[i] / numberOfIslands);
                        return;
                    }
                    if (list[i] % numberOfIslands == kLeft)
                    {
                        IncludList(list, kRight, list[i] / numberOfIslands);
                        return;
                    }
                }
            }
            //} while (list.Count  firstCount);
        }
        public static int Code(int l, int r)
        {
            int code = l * numberOfIslands + r;
            code = l > r ? code : r * numberOfIslands + l;
            return code;
        }
        public static void IncludList(List<int> list, int l, int r)
        {
            int code = Code(l, r);

            if (!list.Contains(code)) //!list.Contains(code)
            {
                list.Add(code);
            }
        }
        public static List<int> RemoveEqualFlight(List<int> flights, int elementToCheck)
        {
            if (flights.Count <= 1 || flights.Count == elementToCheck)
            {
                return flights;
            }

            int flight = flights[elementToCheck];
            //int flightReversed = SwapIsland(flight);

            var listOfFlights = flights.FindAll(x => (x != flight));

            if (flights.Count - listOfFlights.Count > 1)
            {
                return RemoveEqualFlight(listOfFlights, 0);
            }

            return RemoveEqualFlight(flights, ++elementToCheck);
        }
        public static List<string> PrintFlights(List<int> intList)
        {
            var finalList = intList.Select(x => (x / numberOfIslands).ToString() + " <-> " + (x % numberOfIslands).ToString()).ToList();

            return finalList;
        }

        public static void ClearEquals(List<int> list, int[] arr)
        {
            int i = 0;
            int listLengtMinusOne = arr.Length - 1;

            do
            {
                int lastIndex = findIndexOfEquals(arr, i, arr.Length);
                if (lastIndex - i == 1)
                {
                    list.Add(arr[i]);
                    if (lastIndex == listLengtMinusOne)
                    {
                        list.Add(arr[listLengtMinusOne]);
                    }
                }

                i = lastIndex;
            } while (i < listLengtMinusOne);
        }
    }
}
