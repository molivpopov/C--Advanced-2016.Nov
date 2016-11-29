using System;


namespace CorrectBrackets
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int brackets = 0;
            string statusOfBrackets = "Correct";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(') brackets++;
                if (input[i] == ')') brackets--;
                if (brackets < 0)
                {
                    statusOfBrackets = "Incorrect";
                    break;
                }

            }
            if (brackets > 0) statusOfBrackets = "Incorrect";
            Console.WriteLine(statusOfBrackets);
        }
    }
}