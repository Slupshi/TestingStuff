using System;
using System.Threading;

namespace TestingStuff
{
    partial class Program
    {

        public partial class Weapons
        {
            //Class Sword//
            class Sword : WeaponDamage
            {
                public Sword(int startingRoll) : base(startingRoll)
                {
                    roll = startingRoll;
                    CalculateDamage();
                }

                protected override void CalculateDamage()
                {

                    if (Magic) SWORD_MAGIC_MULTIPLIER = 1.75M;
                    Damage = SWORD_BASE_DAMAGE;
                    Damage = (int)(Roll * SWORD_MAGIC_MULTIPLIER) + SWORD_BASE_DAMAGE;
                    if (Flaming) Damage += SWORD_FLAME_DAMAGE;
                }

                public static void SwordDamage()
                {
                    int numberOfRolls = 0;
                    Sword ironSword = new Sword(RollDice(numberOfRolls));
                    while (true)
                    {
                        Console.WriteLine("Welcome to the Sword's Damage Calculatron 2000, use the Y or N keys, other keys will close the program !");
                        Console.Write("How many dices do you want to roll ? ");
                        if (int.TryParse(Console.ReadLine(), out numberOfRolls))
                            ironSword.Roll = RollDice(numberOfRolls);
                        else return;
                        Console.WriteLine("Is your sword Magic ? [Y/N]");
                        char input = Console.ReadKey(true).KeyChar;
                        if (input == 'y' || input == 'Y') { ironSword.Magic = true; Console.WriteLine("Your sword is now Magic"); }
                        else if (input == 'n' || input == 'N') { ironSword.Magic = false; Console.WriteLine("Your sword is not Magic"); }

                        else return;

                        Console.WriteLine("Is your sword Flaming ? [Y/N]");
                        input = Console.ReadKey(true).KeyChar;
                        if (input == 'y' || input == 'Y') { ironSword.Flaming = true; Console.WriteLine("Your sword is now Flaming"); }
                        else if (input == 'n' || input == 'N') { ironSword.Flaming = false; Console.WriteLine("Your sword is not Flaming"); }

                        else return;
                        Console.WriteLine("Calculating your damages");
                        Thread.Sleep(300);
                        Console.WriteLine("Calculating your damages .");
                        Thread.Sleep(300);
                        Console.WriteLine("Calculating your damages ..");
                        Thread.Sleep(300);
                        Console.WriteLine("Calculating your damages ...");
                        Thread.Sleep(300);
                        Console.WriteLine("The dices rolled " + ironSword.Roll + " for a total of " + ironSword.Damage + " HP");
                        Console.WriteLine("Press Q to quit, any other key to continue");
                        input = Console.ReadKey(true).KeyChar;
                        if ((input == 'Q') || (input == 'q')) return;
                        Console.WriteLine("[Reseting the system]");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }

                }
            }//Fin de la Class Sword//
        }
    }

}     //=====================================|| Fin du namespace ||======================================================//


