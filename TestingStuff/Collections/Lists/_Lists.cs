using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                                    LISTS                                      //
        //===============================================================================//

        partial class Lists
        {

            public static void ChooseList()
            {
                Console.WriteLine("Press 1 for ShoesStore, 2 for Test, 3 for Ducks");
                Console.WriteLine("Press 4 for DuckBird");
                Console.WriteLine("Any other key to quit");
                char cardKey = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (cardKey)
                {
                    case '1':
                        Console.Clear();
                        Shoes.ShoesMain();
                        break;
                    case '2':
                        Console.Clear();
                        TestList.TestListMain();
                        break;
                    case '3':
                        Console.Clear();
                        Duck.Ducks();
                        break;
                    case '4':
                        Console.Clear();
                        Ducks.DuckBird();
                        break;
                    default:
                        return;
                }
            }
        }//Fin de la class Lists

    }}     //=====================================|| Fin du namespace ||======================================================//


