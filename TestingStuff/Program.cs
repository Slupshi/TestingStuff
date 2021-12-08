using System;

namespace TestingStuff
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to go on the Page 2, 2 for the SuperCalculator 3090Super, 3 for Tests Heritage");
            Console.WriteLine("Press 4 for Cards, 5 for Collections, 6 for Pool Puzzles ");
            Console.WriteLine("Press 7 for Stream, 8 for Lambda, 9 for //");
            Console.WriteLine("Press * to exit");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1') { Console.Clear(); SecondPage(); }
            else if (input == '2') { Console.Clear(); Weapons.DamageCalculator(); }
            else if (input == '3') { Console.Clear(); PageHeritage(); }
            else if (input == '4') { Console.Clear(); Cards.ChooseCard(); }
            else if (input == '5') { Console.Clear(); PageCollection(); }
            else if (input == '6') { Console.Clear(); PoolPuzzles(); }
            else if (input == '7') { Console.Clear(); Stream.ChooseStream(); }
            else if (input == '8') { Console.Clear(); Lambda.ChooseLambda(); }
            else if (input == '9') { Console.Clear(); }

            else if (input == '*') return;
            else { Console.WriteLine("ARE YOU DUMB ??"); }
        }

        private static void PoolPuzzles()
        {
            Console.WriteLine("Press 1 for the Maths Quizz, 2 for the ClownShit, 3 for PineapplePizza");
            Console.WriteLine("Any other key to quit");
            char poolKey = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (poolKey)
            {
                case '1':
                    Console.Clear();
                    Q.QuizzMaths();
                    break;
                case '2':
                    Console.Clear();
                    Clown.Clown16();
                    break;
                case '3':
                    Console.Clear();
                    PineapplePizza.PizzaFun();
                    break;
                default:
                    return;
            }
        }

        private static void SecondPage()
        {
            Console.WriteLine("Page 2 :");
            Console.WriteLine("Press 1 for Elephant, 2 for Hilo Game, 3 for PaintBallGun");
            Console.WriteLine("Any other key to quit");
            char secondKey = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (secondKey)
            {
                case '1':
                    Console.Clear();
                    Elephant.Elephanto();
                    break;
                case '2':
                    Console.Clear();
                    StaticProgram.HiLogame();
                    break;
                case '3':
                    Console.Clear();
                    MachineGun.PaintballGun();
                    break;
                default:
                    return;
            }
        }

        private static void PageHeritage()
        {
            Console.WriteLine("Press 1 for Test Bird, 2 for JewelsSafe, 3 for TallGuy");
            Console.WriteLine("Press 4 for the ZOO, 5 for IClown");
            Console.WriteLine("Any other key to quit");
            char heritageKey = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (heritageKey)
            {
                case '1':
                    Console.Clear();
                    Heritage.TestBird();
                    break;
                case '2':
                    Console.Clear();
                    JewelsSafe.Vault();
                    break;
                case '3':
                    Console.Clear();
                    TallGuy.TallGuyMethod();
                    break;
                case '4':
                    Console.Clear();
                    Zoo.MainZOO();
                    break;
                case '5':
                    Console.Clear();
                    IClowns.IClownMain();
                    break;
                default:
                    return;
            }
        }

        private static void PageCollection()
        {
            Console.WriteLine("Press 1 for Lists, 2 for Dictionary, 3 for Linq");
            Console.WriteLine("Any other key to quit");
            char collecKey = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (collecKey)
            {
                case '1':
                    Console.Clear();
                    Lists.ChooseList();
                    break;
                case '2':
                    Console.Clear();
                    Dictionary.ChooseDico();
                    break;
                case '3':
                    Console.Clear();
                    Dictionary.LINQ.ChooseLinq();
                    break;
                default:
                    return;
            }
        }

        //===============================================================================//
        //                                  Lambda                                       //
        //===============================================================================//

        class Lambda
        {
            public static void ChooseLambda()
            {
                Console.WriteLine("Press 1 LambdaDrive");
                Console.WriteLine("Any other key to quit");
                char lambdaKey = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (lambdaKey)
                {
                    case '1':
                        Console.Clear();
                        LambdaDrive.DriveMain();
                        break;
                    case '2':
                        Console.Clear();

                        break;
                    case '3':
                        Console.Clear();

                        break;
                    default:
                        return;
                }
            }

            class LambdaDrive
            {
                static Random random => new Random();
                static double GetRandomDouble(int max) => max * random.NextDouble();
                static void PrintValue(double d) => Console.WriteLine($"The value is {d:0.0000}");

                public static void DriveMain()
                {
                    Console.WriteLine("Press * to quit or anything else to rerun\n");
                    while (true)
                    {
                        var value = LambdaDrive.GetRandomDouble(100);
                        LambdaDrive.PrintValue(value);

                        char input = Char.ToUpper(Console.ReadKey().KeyChar);
                        if (input == '*') return;
                    }
                }

            }//Fin de la class LambdaDrive



        }//Fin de la class Lambda

    } //=====================================|| Fin de la class ||======================================================//
}     //=====================================|| Fin du namespace ||======================================================//


