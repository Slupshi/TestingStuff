using System.IO;

namespace TestingStuff
{
    partial class Program
    {
        class PineapplePizza
        {
            public static void PizzaFun() => Pineapple.PineappleMain();

            class Pineapple
            {
                const string d = "delivery.txt";
                public enum Fargo { North, South, East, West, Flamingo }
                public static void PineappleMain()
                {
                    StreamWriter o = new StreamWriter("order.txt");
                    var pz = new Pizza(new StreamWriter(d, true));
                    pz.Idaho(Fargo.Flamingo);
                    for (int w = 3; w >= 0; w--)
                    {
                        var i = new Pizza(new StreamWriter(d, false));
                        i.Idaho((Fargo)w);
                        Party p = new Party(new StreamReader(d));
                        p.HowMuch(o);
                    }
                    o.WriteLine("That's all folks!");
                    o.Close();
                }


            }//Fin de la class Pineapple

            class Party
            {
                private StreamReader reader;
                public Party(StreamReader reader)
                {
                    this.reader = reader;
                }
                public void HowMuch(StreamWriter q)
                {
                    q.WriteLine(reader.ReadLine());
                    reader.Close();
                }
            }//Fin de la class Party

            class Pizza
            {
                private StreamWriter writer;
                public Pizza(StreamWriter writer)
                {
                    this.writer = writer;
                }
                public void Idaho(Pineapple.Fargo f)
                {
                    writer.WriteLine(f);
                    writer.Close();
                }

            }//Fin de la class Pizza

        }//Fin de la class PineapplePizza
    }

}
