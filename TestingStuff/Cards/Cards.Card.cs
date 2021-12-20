using System;

namespace TestingStuff
{
    partial class Program
    {

        partial class Cards
        {
            class Card : IComparable<Card>
            {
                public int CompareTo(Card other)
                {
                    return new CardComparerByValue().Compare(this, other);
                }

                public Values Value { get; private set; }
                public Suits Suit { get; private set; }
                public string Name { get { return $"{Value} of {Suit}"; } }
                public Card(Values value, Suits suit)
                {
                    this.Value = value;
                    this.Suit = suit;

                }

                private static readonly Random random = new Random();

                public static void EnumCard()
                {
                    Console.WriteLine("Press Q to quit, any other key to continue");
                    int numberOfLine = 1;
                    while (true)
                    {
                        int numberBetween0and3 = random.Next(4);
                        int numberBetween1and13 = random.Next(1, 14);
                        int anyRandomInteger = random.Next();

                        Card myCard = new Card((Values)numberBetween1and13, (Suits)numberBetween0and3);
                        Console.WriteLine(myCard.Name);

                        numberOfLine += 1;
                        if (numberOfLine >= 30) { Console.Clear(); Console.WriteLine("Press Q to quit, any other key to continue"); numberOfLine = 1; }
                        char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                        if ((input == 'Q')) return;
                    }


                }

                public override string ToString()
                {
                    return $"{Value} of {Suit}";
                }
            }//Fin de la class Card

        }
    }
}     //=====================================|| Fin du namespace ||======================================================//


