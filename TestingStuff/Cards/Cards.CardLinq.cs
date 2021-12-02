using System;
using System.Linq;

namespace TestingStuff
{
    partial class Program
    {

        partial class Cards
        {
            class CardLinq
            {
                public static void CardLinqMain()
                {
                    while (true)
                    {
                        var deck = new Deck()
                                    .Shuffle()
                                    .Take(16);
                        var grouped =
                        from card in deck
                        group card by card.Suit into suitGroup
                        orderby suitGroup.Key descending
                        select suitGroup;
                        foreach (var group in grouped)
                        {
                            Console.WriteLine(@$"Group: {group.Key}
Count: {group.Count()}
Minimum: {group.Min()}
Maximum: {group.Max()}");
                            Console.WriteLine("");
                        }
                        Console.WriteLine("Press * to reroll, anything else to quit");
                        char input = Console.ReadKey(true).KeyChar;
                        if (input == '*') { Console.Clear(); }
                        else return;
                    }
                }
            }//Fin de la class CardLinq

        }
    }}     //=====================================|| Fin du namespace ||======================================================//


