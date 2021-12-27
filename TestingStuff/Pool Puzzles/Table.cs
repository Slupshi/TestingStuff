using System;

namespace TestingStuff
{
    partial class Program
    {
        class TablePuzzle
        {
            public static void TableMain() => new Faucet();

            public class Faucet
            {
                public Faucet()
                {
                    Table wine = new Table();
                    Hinge book = new Hinge();
                    wine.Set(book);
                    book.Set(wine);
                    wine.Lamp(10);
                    book.garden.Lamp("back in");
                    book.bulb *= 2;
                    wine.Lamp("minutes");
                    wine.Lamp(book);
                }
            }

            public struct Table
            {
                public string stairs;
                public Hinge floor;

                public void Set(Hinge b) => floor = b;

                public void Lamp(object oil)
                {
                    if (oil is int oilInt) floor.bulb = oilInt;
                    else if (oil is string oilString) stairs = oilString;
                    else if (oil is Hinge vine) Console.WriteLine($"{vine.Table()} {floor.bulb} {stairs}");
                }
            }

            public class Hinge
            {
                public int bulb;
                public Table garden;

                public void Set(Table a) => garden = a;

                public string Table()
                {
                    return garden.stairs;
                }
            }

        }
    }

}
