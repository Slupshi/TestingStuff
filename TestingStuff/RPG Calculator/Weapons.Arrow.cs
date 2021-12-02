using System;
using System.Threading;

namespace TestingStuff
{
    partial class Program
    {

        public partial class Weapons
        {
            //Class Arrow//
            class Arrow : WeaponDamage
            {
                public Arrow(int startingRoll) : base(startingRoll)
                {
                    roll = startingRoll;
                    CalculateDamage();
                }

                protected override void CalculateDamage()
                {
                    decimal baseDamage = Roll * ARROW_BASE_MULTIPLIER;
                    if (Magic) baseDamage *= ARROW_MAGIC_MULTIPLIER;
                    if (Flaming) Damage = (int)Math.Ceiling(baseDamage + ARROW_FLAME_DAMAGE);
                    else Damage = (int)Math.Ceiling(baseDamage);
                }

                public static void ArrowDamage()
                {

                    int numberOfRolls = 0;
                    Arrow arrow = new Arrow(RollDice(numberOfRolls));
                    while (true)
                    {
                        Console.WriteLine("Welcome to the Arrow's Damage Calculatron 2000, use the Y or N keys, other keys will close the program !");
                        Console.Write("How many dices do you want to roll ? ");
                        if (int.TryParse(Console.ReadLine(), out numberOfRolls))
                            arrow.Roll = RollDice(numberOfRolls);
                        else return;
                        Console.WriteLine("Is your arrow Magic ? [Y/N]");
                        char input = Console.ReadKey(true).KeyChar;
                        if (input == 'y' || input == 'Y') { arrow.Magic = true; Console.WriteLine("Your arrow is now Magic"); }
                        else if (input == 'n' || input == 'N') { arrow.Magic = false; Console.WriteLine("Your arrow is not Magic"); }

                        else return;

                        Console.WriteLine("Is your arrow Flaming ? [Y/N]");
                        input = Console.ReadKey(true).KeyChar;
                        if (input == 'y' || input == 'Y') { arrow.Flaming = true; Console.WriteLine("Your arrow is now Flaming"); }
                        else if (input == 'n' || input == 'N') { arrow.Flaming = false; Console.WriteLine("Your arrow is not Flaming"); }

                        else return;
                        Console.WriteLine("Calculating your damages");
                        Thread.Sleep(300);
                        Console.WriteLine("Calculating your damages .");
                        Thread.Sleep(300);
                        Console.WriteLine("Calculating your damages ..");
                        Thread.Sleep(300);
                        Console.WriteLine("Calculating your damages ...");
                        Thread.Sleep(300);
                        Console.WriteLine("The dices rolled " + arrow.Roll + " for a total of " + arrow.Damage + " HP");
                        Console.WriteLine("Press Q to quit, any other key to continue");
                        input = Console.ReadKey(true).KeyChar;
                        if ((input == 'Q') || (input == 'q')) return;
                        Console.WriteLine("[Reseting the system]");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }

                }

            }//Fin de la Class Arrow//
        }
    }

}     //=====================================|| Fin du namespace ||======================================================//


