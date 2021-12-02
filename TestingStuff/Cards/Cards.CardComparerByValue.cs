using System.Collections.Generic;

namespace TestingStuff
{
    partial class Program
    {

        partial class Cards
        {
            class CardComparerByValue : IComparer<Card>
            {
                public int Compare(Card x, Card y)
                {
                    if (x.Suit < y.Suit)
                        return -1;
                    if (x.Suit > y.Suit)
                        return 1;
                    if (x.Value < y.Value)
                        return -1;
                    if (x.Value > y.Value)
                        return 1;
                    return 0;
                }
            }//Fin de la class CardComparerByValue

        }
    }}     //=====================================|| Fin du namespace ||======================================================//


