namespace CardsDescription
{
    using System;
    using System.Linq;
    class Program
    {
        public const ulong FullDeck = 0xfffffffffffff;
        public static string[] cardsName = new string[] {
                "2c",  "3c",  "4c",  "5c",  "6c",  "7c",  "8c",  "9c",  "Tc",  "Jc",  "Qc",  "Kc",  "Ac",
                "2d",  "3d",  "4d",  "5d",  "6d",  "7d",  "8d",  "9d",  "Td",  "Jd",  "Qd",  "Kd",  "Ad",
                "2h",  "3h",  "4h",  "5h",  "6h",  "7h",  "8h",  "9h",  "Th",  "Jh",  "Qh",  "Kh",  "Ah",
                "2s",  "3s",  "4s",  "5s",  "6s",  "7s",  "8s",  "9s",  "Ts",  "Js",  "Qs",  "Ks",  "As"
            };
        static void Main()
        {

            var numberOfHands = int.Parse(Console.ReadLine());
            var hands = new ulong[numberOfHands].Select(x => x = ulong.Parse(Console.ReadLine())).ToArray();
            // magic
            ulong handOfDeck = 0;
            ulong evenCards = FullDeck;
            for (int i = 0; i < numberOfHands; i++)
            {
                handOfDeck = handOfDeck | hands[i];
                evenCards = evenCards ^ hands[i];
            }
            if (handOfDeck == FullDeck)
            {
                Console.WriteLine("Full deck");
            }
            else
            {
                Console.WriteLine("Wa wa!");
            }
            Console.WriteLine(PrintCards(evenCards));

        }
        public static string PrintCards(ulong finalSet)
        {
            int CardsInDeck = 52;
            string resulte = "";
            for (int i = 0; i < CardsInDeck; i++)
            {
                if (finalSet % 2 == 1)
                {
                    resulte += " " + cardsName[i];
                }
                finalSet /= 2;
            }
            return resulte.Trim();
        }
    }
}
