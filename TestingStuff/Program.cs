using System;
using System.Threading;

namespace TestingStuff
{
    class Program
    {


        static void Main(string[] args)
        {

            Console.WriteLine("Press 1 for the StatsCalculator, 2 for the SwordDamageCalculator, 3 for Elephant");
            Console.WriteLine("Press 4 for the Hi - Lo game, 5 for PaintballGun, 6 for QuizzMaths ");
            Console.WriteLine("Press 9 to exit");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1') { Console.Clear(); TestCalculator(); }
            else if (input == '2') { Console.Clear(); SwordDamage(); }
            else if (input == '3') { Console.Clear(); Elephant(); }
            else if (input == '4') { Console.Clear(); StaticProgram.HiLogame(); }
            else if (input == '5') { Console.Clear(); MachineGun.PaintballGun(); }
            else if (input == '6') { Console.Clear(); QuizzMaths(); }
            else if (input == '9') return;
        }

        //===============================================================================//
        //                               Sword Damage                                    //
        //===============================================================================//

        public const int BASE_DAMAGE = 3;
        public const int FLAME_DAMAGE = 2;
        public int Roll;
        private decimal MagicMultiplier = 1M;
        private int FlamingDamage = 0;
        public int Damage;

        private void CalculateDamage()
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

        //===============================================================================//
        //                         Pool Puzzle : Maths Quizz (303)                       //
        //===============================================================================//



        //Class Quizz Maths//
        class Q
        {
            public static Random R = new Random();
            public int N1 { get; private set; }
            public string Op { get; private set; }
            public int N2 { get; private set; }
            public Q(bool add)
            {
                if (add) Op = "+";
                else Op = "*";
                N1 = R.Next(1, 10);
                N2 = R.Next(1, 10);
            }
            public bool Check(int a)
            {
                if (Op == "+") return (a == N1 + N2);
                else return (a == N1 * N2);
            }
        }//Fin de la class Quizz Maths//

        public static void QuizzMaths()
        {
            Q q = new Q(Q.R.Next(2) == 1);
            while (true)
            {
                Console.Write($"{q.N1}{q.Op}{q.N2} = ");
                if (!int.TryParse(Console.ReadLine(), out int i)) { Console.WriteLine("Thanks for playing!"); return; }
                if (q.Check(i))
                {
                    Console.WriteLine("Right!");
                    q = new Q(Q.R.Next(2) == 1);
                }
                else Console.WriteLine("Wrong! Try again.");
            }
        }






    } //=====================================|| Fin de la class ||======================================================//

    //Nouvelle class MachineGun 
    class MachineGun
    {
        //===============================================================================//
        //                                Paintball Gun                                  //
        //===============================================================================//

        public MachineGun(int balls, int magazineSize, bool loaded)
        {
            this.balls = balls;
            MagazineSize = magazineSize;
            if (!loaded) Reload();
        }

        public int MagazineSize { get; private set; } = 16;

        private int balls = 0;

        public int BallsLoaded { get; private set; }

        public bool IsEmpty() { return BallsLoaded == 0; }

        public int Balls
        {
            get { return balls; }
            set
            {
                if (value > 0)
                    balls = value;
                Reload();
            }
        }

        public void Reload()
        {
            if (balls > MagazineSize)
                BallsLoaded = MagazineSize;
            else
                BallsLoaded = balls;
        }

        public bool Shoot()
        {
            if (BallsLoaded == 0) return false;
            BallsLoaded--;
            balls--;
            return true;
        }

        private static int ReadInt(int lastUsedValueGun, string promptGun)
        {
            Console.Write(promptGun + " [" + lastUsedValueGun + "]: ");
            string promptGunRead = Console.ReadLine();
            if (promptGunRead == "")
            {
                Console.WriteLine("using default value " + lastUsedValueGun);
            }
            else
            {
                if (int.TryParse(promptGunRead, out lastUsedValueGun))
                {
                    Console.WriteLine("using value " + lastUsedValueGun);
                }
                else
                { Console.WriteLine("using default value " + lastUsedValueGun); }
            }
            return lastUsedValueGun;
        }

        public static void PaintballGun()
        {
            int numberOfBalls = ReadInt(20, "Number of balls");
            int magazineSize = ReadInt(16, "Magazine size");

            Console.Write($"Loaded [false]: ");
            bool.TryParse(Console.ReadLine(), out bool isLoaded);

            MachineGun gun = new MachineGun(numberOfBalls, magazineSize, isLoaded);

            while (true)
            {
                Console.WriteLine($"{gun.Balls} balls, {gun.BallsLoaded} loaded");
                if (gun.IsEmpty()) Console.WriteLine("WARNING: You're out of ammo");
                Console.WriteLine("Space to shoot, r to reload, + to add ammo, q to quit");
                char key = Console.ReadKey(true).KeyChar;
                if (key == ' ') Console.WriteLine($"Shooting returned {gun.Shoot()}");
                else if (key == 'r') gun.Reload();
                else if (key == '+') gun.Balls += gun.MagazineSize;
                else if (key == 'q') return;
            }
        }
    } //Fin de la class MachineGun



    //Nouvelle class STATIC
    static class StaticProgram
    {
        //===============================================================================//
        //                               Hi-Lo Game                                      //
        //===============================================================================//

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





}     //Fin du namespace
