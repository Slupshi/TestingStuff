using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                           Hi-Lo Game / Static                                 //
        //===============================================================================//

        //Nouvelle class STATIC
        static class StaticProgram
        {
            private static Random random = new Random();
            private const int MAXIMUM = 10;
            private static int currentNumber = random.Next(1, MAXIMUM + 1);
            private static int pot = 10;
            private static int nextNumber;

            public static void HiLogame()
            {
                Console.WriteLine("Welcome to HiLo.");
                Console.WriteLine($"Guess numbers between 1 and {MAXIMUM}.");
                Console.WriteLine($"The current number is {currentNumber}");
                while (GetPot() > 0)
                {
                    Console.WriteLine("Press h for higher, l for lower, k to buy a hint,");
                    Console.WriteLine($"or any other key to quit with {GetPot()} bucks.");
                    char key = Console.ReadKey(true).KeyChar;
                    if (key == 'h') Guess(true);
                    else if (key == 'l') Guess(false);
                    else if (key == 'k') Hint();
                    else return;
                }
                Console.WriteLine("The pot is empty. Bye!");
            }

            public static int GetPot() { return pot; }

            public static void Guess(bool higher)
            {
                nextNumber = random.Next(1, MAXIMUM + 1);
                if ((higher && nextNumber >= currentNumber)
                    || (!higher && nextNumber <= currentNumber))
                { Console.WriteLine("You guessed right !"); pot += 1; Console.WriteLine("You gained 1 buck !"); }
                else
                { Console.WriteLine("You guessed wrong !"); pot -= 1; Console.WriteLine("You lost 1 buck !"); }
                currentNumber = nextNumber;
                Console.WriteLine($"The current number is now {currentNumber}");
            }

            public static void Hint()
            {
                if (nextNumber >= MAXIMUM / 2) { Console.WriteLine($"The number is at least {MAXIMUM / 2}"); pot -= 1; Console.WriteLine("You lost 1 buck !"); }
                else if (nextNumber <= MAXIMUM / 2) { Console.WriteLine($"The number is at most {MAXIMUM / 2}"); pot -= 1; Console.WriteLine("You lost 1 buck !"); }
            }
        } //Fin de la class STATIC

    }}     //=====================================|| Fin du namespace ||======================================================//


