namespace Kitty
{
    using System;
    using System.Linq;

    class Program
    {
        public const string PatternToPrintFree = "Coder souls collected: {0}\nFood collected: {1}\nDeadlocks: {2}";
        public const string PatternToPrintLocked = "You are deadlocked, you greedy kitty!\nJumps before deadlock: {0}";
        public const char SoulSymbol = '@';
        public const char FoodSymbol = '*';
        public const char DeadlockSymbol = 'x';
        public const char NullSymbol = '0';
        static void Main()
        {
            var commands = Console.ReadLine().ToCharArray();
            var jumps = ("0 " + Console.ReadLine()).Split(' ').Select(int.Parse).ToArray();
            int soul = 0, food = 0, index = 0;

            int countOfDeadlocks = 0;

            for (int jump = 0; jump < jumps.Length; jump++)
            {
                index = Check(index + jumps[jump] % commands.Length, commands.Length);

                if (commands[index] == SoulSymbol)
                {
                    soul++;
                    commands[index] = NullSymbol;
                }

                if (commands[index] == FoodSymbol)
                {
                    food++;
                    commands[index] = NullSymbol;
                }

                if (commands[index] == DeadlockSymbol) // deadLock
                {
                    if (index % 2 == 0)
                    {
                        if (soul == 0) //If no soul to leave
                        {
                            Console.WriteLine(PatternToPrintLocked, jump);
                            return;
                        }
                        soul--;
                        commands[index] = SoulSymbol;
                    }
                    else
                    {
                        if (food == 0) //If no food to leave
                        {
                            Console.WriteLine(PatternToPrintLocked, jump);
                            return;
                        }
                        food--;
                        commands[index] = FoodSymbol;
                    }
                    countOfDeadlocks++;
                }
            }
            Console.WriteLine(PatternToPrintFree, soul, food, countOfDeadlocks);
        }
        public static int Check(int number, int lims)
        {
            if (number < 0)
            {
                number += lims;
            }
            if (number >= lims)
            {
                number -= lims;
            }
            return number;
        }
    }
}