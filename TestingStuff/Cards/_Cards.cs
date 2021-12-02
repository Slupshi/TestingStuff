using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                                    Cards                                      //
        //===============================================================================//

        partial class Cards
        {
            public static void ChooseCard()
            {
                Console.WriteLine("Press 1 for EnumCard, 2 for CardsList, 3 for CardLinq");
                Console.WriteLine("Any other key to quit");
                char cardKey = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (cardKey)
                {
                    case '1':
                        Console.Clear();
                        Card.EnumCard();
                        break;
                    case '2':
                        Console.Clear();
                        CardsList.CardsListMain();
                        break;
                    case '3':
                        Console.Clear();
                        CardLinq.CardLinqMain();
                        break;
                    default:
                        return;
                }
            }

        }//Fin de la class Cards

    }}     //=====================================|| Fin du namespace ||======================================================//


