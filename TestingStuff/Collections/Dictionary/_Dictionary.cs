using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                        Dictionary / Stack / Queue                             //
        //===============================================================================//

        partial class Dictionary
        {
            public static void ChooseDico()
            {
                Console.WriteLine("Press 1 for RetiredPlayers, 2 for LumberJack");
                Console.WriteLine("Any other key to quit");
                char dicoKey = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (dicoKey)
                {
                    case '1':
                        Console.Clear();
                        RetiredPlayer.RetiredPlayersMain();
                        break;
                    case '2':
                        Console.Clear();
                        LumberJack.LumberJackMain();
                        break;
                    case '3':
                        Console.Clear();

                        break;
                    default:
                        return;
                }
            }

        }//Fin de la class Disctionary

    }
}     //=====================================|| Fin du namespace ||======================================================//


