namespace ConsoleApplication3
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            var keyword = Console.ReadLine();
            var lines = int.Parse(Console.ReadLine());

            var builder = new StringBuilder();
            var text = Enumerable.Range(0, lines).Select(x => builder.Append(Console.ReadLine())).Last().ToString();

            var peshoPos = text.IndexOf(keyword);

            var dot = text.IndexOf('.', peshoPos);
            var questions = text.IndexOf('?', peshoPos);

            var end = Math.Min(dot == -1 ? int.MaxValue : dot, questions == -1 ? int.MaxValue : questions);

            string substring = null; // we

            if (text[end] == '.')
            {
                var start = Math.Max(text.LastIndexOf('.', peshoPos), text.LastIndexOf('?', peshoPos)) + 1;

                substring = text.Substring(start, peshoPos - start);
            }
            else
            {
                var start = text.IndexOfAny(" .?".ToCharArray(), peshoPos);

                substring = text.Substring(start, end - start);
            }

            Console.WriteLine(substring.Where(x => x != ' ').Sum(x => char.ToUpper(x)));
        }
    }
}