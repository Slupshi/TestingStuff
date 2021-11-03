using System;
using System.Threading;

namespace TestingStuff
{
    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Press 1 for the StatsCalculator, 2 for the SwordDamageCalculator, 3 for Elephant");
            Console.WriteLine("Press 9 to exit");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1') { Console.Clear(); TestCalculator(); }
            else if (input == '2') { Console.Clear(); SwordDamage(); }
            else if (input == '3') { Console.Clear(); Elephant(); }
            else if (input == '9') return;
        }


        //===============================================================================//
        //                               Sword Damage                                    //
        //===============================================================================//

        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;
        public int Roll;
        public decimal MagicMultiplier = 1M;
        public int FlamingDamage = 0;
        public int Damage;

        public void CalculateDamage()
        {
            Damage = (int)(Roll * MagicMultiplier) + BASE_DAMAGE + FlamingDamage;
        }

        public void SetMagic(bool isMagic)
        {
            if (isMagic)
            {
                MagicMultiplier = 1.75M;
            }
            else
            {
                MagicMultiplier = 1M;
            }
            CalculateDamage();
        }

        public void SetFlaming(bool isFlaming)
        {
            CalculateDamage();
            if (isFlaming)
            {
                Damage += FLAME_DAMAGE;
            }
        }

        public static void SwordDamage()
        {
            Random random = new Random();
            Program ironSword = new Program();
            while (true)
            {
                Console.WriteLine("Welcome to the Sword's Damage Calculatron 2000, use the Y or N keys, other keys will close the program !");
                ironSword.Roll = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
                Console.WriteLine("Is your sword Magic ? [Y/N]");
                char input = Console.ReadKey(true).KeyChar;
                if (input == 'y' || input == 'Y') { ironSword.SetMagic(true); Console.WriteLine("Your sword is now Magic"); }
                else if (input == 'n' || input == 'N') { ironSword.SetMagic(false); Console.WriteLine("Your sword is not Magic"); }
                else return;

                Console.WriteLine("Is your sword Flaming ? [Y/N]");
                input = Console.ReadKey(true).KeyChar;
                if (input == 'y' || input == 'Y') { ironSword.SetFlaming(true); Console.WriteLine("Your sword is now Flaming"); }
                else if (input == 'n' || input == 'N') { ironSword.SetFlaming(false); Console.WriteLine("Your sword is not Flaming"); }
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
                Console.Clear();
            }

        }


        //===============================================================================//
        //                                Stats Calculator                               //  
        //===============================================================================//

        private static void TestCalculator()
        {
            Program calculator = new Program();
            while (true)
            {
                calculator.RollResult = ReadInt(calculator.RollResult, "Starting 4d6 roll");
                calculator.DivideBy = ReadDouble(calculator.DivideBy, "Divide by");
                calculator.AddAmount = ReadInt(calculator.AddAmount, "Add amount");
                calculator.Minimum = ReadInt(calculator.Minimum, "Minimum");
                calculator.CalculateAbilityScore();
                Console.WriteLine("Calculated ability score: " + calculator.Score);
                Console.WriteLine("Press Q to quit, any other key to continue");
                char keyChar = Console.ReadKey(true).KeyChar;
                if ((keyChar == 'Q') || (keyChar == 'q')) return;
            }
        }

        private static double ReadDouble(double lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string promptRead = Console.ReadLine();
            if (promptRead == "")
            {
                Console.WriteLine("using default value " + lastUsedValue);
            }
            else
            {
                if (double.TryParse(promptRead, out lastUsedValue))
                {
                    Console.WriteLine("using value " + lastUsedValue);
                }
                else
                { Console.WriteLine("using default value " + lastUsedValue); }
            }
            return lastUsedValue;
        }

        private static int ReadInt(int lastUsedValue, string prompt)
        {
            Console.Write(prompt + " [" + lastUsedValue + "]: ");
            string promptRead = Console.ReadLine();
            if (promptRead == "")
            {
                Console.WriteLine("using default value " + lastUsedValue);
            }
            else
            {
                if (int.TryParse(promptRead, out lastUsedValue))
                {
                    Console.WriteLine("using value " + lastUsedValue);
                }
                else
                { Console.WriteLine("using default value " + lastUsedValue); }
            }
            return lastUsedValue;
        }

        public int RollResult = 14;
        public double DivideBy = 1.75;
        public int AddAmount = 2;
        public int Minimum = 3;
        public int Score;


        public void CalculateAbilityScore()
        {

            double divided = RollResult / DivideBy;

            int added = AddAmount + (int)divided;


            if (added < Minimum)
            {
                Score = Minimum;
            }
            else
            {
                Score = added;
            }
        }

        //===============================================================================//
        //                                    ELEPHANT                                   //
        //===============================================================================//

        public int EarSize;
        public string Name;
        public bool IsSwapped = false;

        public static void Elephant()
        {
            Program lloyd = new Program() { Name = "Lloyd", EarSize = 40 };
            Program lucinda = new Program() { Name = "Lucinda", EarSize = 33 };

            Console.WriteLine("Press 1 for Lloyd, 2 for Lucinda, 3 to swap, 4 to send a message");
            Console.WriteLine("Press 9 to exit");

            while (true)
            {

                char input = Console.ReadKey(true).KeyChar;
                if (input == '1')
                {
                    Console.WriteLine("You pressed 1");
                    Console.WriteLine("Calling Lloyd");
                    lloyd.WhoAmI();
                }
                else if (input == '2')
                {
                    Console.WriteLine("You pressed 2");
                    Console.WriteLine("Calling Lucinda");
                    lucinda.WhoAmI();
                }
                else if (input == '3')
                {
                    Console.WriteLine("You pressed 3");
                    Program swap = lucinda;
                    lucinda = lloyd;
                    lloyd = swap;
                    Console.WriteLine("References have been swapped");
                }
                else if (input == '4')
                {
                    Console.WriteLine("You pressed 4");
                    lucinda.SpeakTo(lloyd, "Hi, Lloyd!");
                }
                else if (input == '9')
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong button dumbass !");
                }

            }
        }

        public void WhoAmI()
        {
            Console.WriteLine("My name is " + Name);
            Console.WriteLine("My ears are " + EarSize + " tall.");
        }


        public void HearMessage(string message, Program whoSaidIt)
        {
            Console.WriteLine(Name + " heard a message");
            Console.WriteLine(whoSaidIt.Name + " said this: " + message);
        }

        public void SpeakTo(Program whoToTalkTo, string message)
        {
            whoToTalkTo.HearMessage(message, this);
        }











    } //Fin de la class
}     //Fin du namespace
