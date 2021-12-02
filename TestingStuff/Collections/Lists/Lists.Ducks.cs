using System.Collections.Generic;
using System.Linq;

namespace TestingStuff
{
    partial class Program
    {

        partial class Lists
        {
            class Ducks : Birds
            {

                public static void DuckBird()
                {
                    List<Ducks> ducks = new List<Ducks>() {
                new Ducks() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Ducks() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Ducks() { Kind = KindOfDuck.Loon, Size = 14 },
                new Ducks() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Ducks() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Ducks() { Kind = KindOfDuck.Loon, Size = 13 }, };
                    IEnumerable<Birds> upcastDucks = ducks;
                    Birds.FlyAway(upcastDucks.ToList(), "Minnesota");
                }

                public int Size { get; set; }
                public KindOfDuck Kind { get; set; }
                public override string ToString()
                {
                    return $"A {Size} inch {Kind}";
                }
            }//Fin de la class Ducks
        }
    }}     //=====================================|| Fin du namespace ||======================================================//


