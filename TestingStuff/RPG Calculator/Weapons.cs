using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                          Weapons Damages Calculator                           //
        //===============================================================================//

        //Nouvelle class Weapons
        public partial class Weapons
        {
            public static void DamageCalculator()
            {
                Console.WriteLine("Press S to use a Sword, A to use an Arrow, P for your stats");
                Console.WriteLine("Any other key to quit");
                char weaponKey = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (weaponKey)
                {
                    case 'S':
                        Console.Clear();
                        Sword.SwordDamage();
                        break;
                    case 'A':
                        Console.Clear();
                        Arrow.ArrowDamage();
                        break;
                    case 'P':
                        Console.Clear();
                        Calculator.TestCalculator();
                        break;
                    default:
                        return;
                }
            }

            abstract class WeaponDamage//Nouvelle class WeaponDamage
            {
                public WeaponDamage(int startingRoll)
                {
                    roll = startingRoll;
                    CalculateDamage();
                }
                protected const decimal ARROW_BASE_MULTIPLIER = 0.35M;
                protected const decimal ARROW_MAGIC_MULTIPLIER = 2.5M;
                protected const decimal ARROW_FLAME_DAMAGE = 1.25M;
                protected const int SWORD_BASE_DAMAGE = 3;
                protected decimal SWORD_MAGIC_MULTIPLIER = 1M;
                protected const int SWORD_FLAME_DAMAGE = 2;

                protected int roll;
                public int Roll
                {
                    get { return roll; }
                    set { roll = value; CalculateDamage(); }
                }
                public int Damage { get; protected set; }


                private bool magic;
                public bool Magic
                {
                    get { return magic; }
                    set { magic = value; CalculateDamage(); }
                }

                private bool flaming;
                public bool Flaming
                {
                    get { return flaming; }
                    set { flaming = value; CalculateDamage(); }
                }

                protected abstract void CalculateDamage();


                protected static int RollDice(int numberOfRolls)
                {
                    int diceRolled = 0;
                    Random random = new Random();
                    for (int j = 1; j <= numberOfRolls; j++)
                    {
                        diceRolled += random.Next(1, 7);
                    }
                    return diceRolled;
                }

            }//Fin de la class WeaponDamage
        }//Fin de la class Weapons

    }

}     //=====================================|| Fin du namespace ||======================================================//


