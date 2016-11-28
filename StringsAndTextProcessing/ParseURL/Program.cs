namespace ParseURL
{
    using System;
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int index = input.IndexOf("://");
            string protokol = "[protocol] = " + input.Substring(0, index);
            Console.WriteLine(protokol);
            input = input.Remove(0, index + 3);
            index = input.IndexOf("/");
            Console.WriteLine("[server] = " + input.Substring(0, index));
            Console.WriteLine("[resource] = " + input.Substring(index, input.Length - index));
        }
    }
}