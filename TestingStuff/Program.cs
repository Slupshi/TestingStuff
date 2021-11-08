using System;
using System.Threading;

namespace TestingStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 for the StatsCalculator, 2 for the SuperCalculator 3090Super, 3 for Elephant");
            Console.WriteLine("Press 4 for the Hi - Lo game, 5 for PaintballGun, 6 for QuizzMaths ");
            Console.WriteLine("Press 7 to TestBird, 8 for Safe");
            Console.WriteLine("Press * to exit");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1') { Console.Clear(); Calculator.TestCalculator(); }
            else if (input == '2') { Console.Clear(); DamageCalculator(); }
            else if (input == '3') { Console.Clear(); Elephant.Elephanto(); }
            else if (input == '4') { Console.Clear(); StaticProgram.HiLogame(); }
            else if (input == '5') { Console.Clear(); MachineGun.PaintballGun(); }
            else if (input == '6') { Console.Clear(); Q.QuizzMaths(); }
            else if (input == '7') { Console.Clear(); Heritage.TestHeritage(); }
            else if (input == '8') { Console.Clear(); Safe.Vault(); }

            else if (input == '*') return;
            else { Console.WriteLine("ARE YOU DUMB ??"); }
        }

        //===============================================================================//
        //                              Damages Calculator                               //
        //===============================================================================//

        private static void DamageCalculator()
        {
            Console.WriteLine("Press S to use a Sword, A to use an Arrow");
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
                default:
                    return;
            }
        }

        //===============================================================================//
        //                               Arrow Damage                                    //
        //===============================================================================//
        //Class Arrow//
        class Arrow
        {
            public Arrow(int startingRoll)
            {
                roll = startingRoll;
                ArrowCalculateDamage();
            }

            private const decimal BASE_MULTIPLIER = 0.35M;
            private const decimal MAGIC_MULTIPLIER = 2.5M;
            private const decimal FLAME_DAMAGE = 1.25M;
            private int roll = 0;
            public int Roll
            {
                get { return roll; }
                set { roll = value; ArrowCalculateDamage(); }
            }

            public int Damage { get; private set; }
            public bool isMagic = false;
            public bool isFlaming = false;

            private void ArrowCalculateDamage()
            {
                decimal baseDamage = Roll * BASE_MULTIPLIER;
                if (Magic) baseDamage *= MAGIC_MULTIPLIER;
                if (Flaming) Damage = (int)Math.Ceiling(baseDamage + FLAME_DAMAGE);
                else Damage = (int)Math.Ceiling(baseDamage);
            }

            private bool magic;
            public bool Magic
            {
                get { return magic; }
                set { magic = value; ArrowCalculateDamage(); }
            }

            private bool flaming;
            public bool Flaming
            {
                get { return flaming; }
                set { flaming = value; ArrowCalculateDamage(); }
            }

            private static int ArrowRollDice(int numberOfRolls)
            {
                int diceRolled = 0;
                Random random = new Random();
                for (int j = 1; j <= numberOfRolls; j++)
                {
                    diceRolled += random.Next(1, 7);
                }
                return diceRolled;
            }

            public static void ArrowDamage()
            {

                int numberOfRolls = 0;
                Arrow arrow = new Arrow(ArrowRollDice(numberOfRolls));
                while (true)
                {
                    Console.WriteLine("Welcome to the Arrow's Damage Calculatron 2000, use the Y or N keys, other keys will close the program !");
                    Console.Write("How many dices do you want to roll ? ");
                    if (int.TryParse(Console.ReadLine(), out numberOfRolls))
                        arrow.Roll = ArrowRollDice(numberOfRolls);
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
                    Console.Clear();
                }

            }





        }//Fin de la Class Arrow//

        //===============================================================================//
        //                               Sword Damage                                    //
        //===============================================================================//

        //Class Sword//
        class Sword
        {
            public Sword(int startingRoll)
            {
                roll = startingRoll;
                CalculateDamage();
            }

            public const int BASE_DAMAGE = 3;
            public const int FLAME_DAMAGE = 2;
            private int roll = 0;
            public int Roll
            {
                get { return roll; }
                set { roll = value; CalculateDamage(); }
            }

            public int Damage { get; private set; }
            public bool isMagic = false;
            public bool isFlaming = false;

            private void CalculateDamage()
            {
                decimal magicMultiplier = 1M;
                if (Magic) magicMultiplier = 1.75M;
                Damage = BASE_DAMAGE;
                Damage = (int)(Roll * magicMultiplier) + BASE_DAMAGE;
                if (Flaming) Damage += FLAME_DAMAGE;
            }

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

            private static int RollDice()
            {
                Random random = new Random();
                return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            }

            public static void SwordDamage()
            {

                Sword ironSword = new Sword(RollDice());
                while (true)
                {
                    Console.WriteLine("Welcome to the Sword's Damage Calculatron 2000, use the Y or N keys, other keys will close the program !");
                    ironSword.Roll = RollDice();
                    Console.WriteLine("Is your sword Magic ? [Y/N]");
                    char input = Console.ReadKey(true).KeyChar;
                    if (input == 'y' || input == 'Y') { ironSword.Magic = (input == 'y' || input == 'Y'); Console.WriteLine("Your sword is now Magic"); }
                    else if (input == 'n' || input == 'N') { Console.WriteLine("Your sword is not Magic"); }

                    else return;

                    Console.WriteLine("Is your sword Flaming ? [Y/N]");
                    input = Console.ReadKey(true).KeyChar;
                    if (input == 'y' || input == 'Y') { ironSword.Flaming = (input == 'y' || input == 'Y'); Console.WriteLine("Your sword is now Flaming"); }
                    else if (input == 'n' || input == 'N') { Console.WriteLine("Your sword is not Flaming"); }

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
        }//Fin de la Class Sword//

        //===============================================================================//
        //                                Stats Calculator                               //  
        //===============================================================================//

        //Class Calculator//
        class Calculator
        {
            public static void TestCalculator()
            {
                Calculator calculator = new Calculator();
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
        }//Fin de la Class Calculator//

        //===============================================================================//
        //                                    ELEPHANT                                   //
        //===============================================================================//

        //Class Elephant//
        class Elephant
        {
            public int EarSize;
            public string Name;

            public static void Elephanto()
            {
                Elephant lloyd = new Elephant() { Name = "Lloyd", EarSize = 40 };
                Elephant lucinda = new Elephant() { Name = "Lucinda", EarSize = 33 };

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
                        Elephant swap = lucinda;
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


            public void HearMessage(string message, Elephant whoSaidIt)
            {
                Console.WriteLine(Name + " heard a message");
                Console.WriteLine(whoSaidIt.Name + " said this: " + message);
            }

            public void SpeakTo(Elephant whoToTalkTo, string message)
            {
                whoToTalkTo.HearMessage(message, this);
            }
        }//Fin de la Class Elephant//

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
        }//Fin de la class Quizz Maths//

        //===============================================================================//
        //                                Paintball Gun                                  //
        //===============================================================================//

        //Nouvelle class MachineGun 
        class MachineGun
        {

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

        //===============================================================================//
        //                                Coffre-Fort                                    //
        //===============================================================================//

        //Nouvelle clas Safe
        class Safe
        {

            public static void Vault()
            {
                SafeOwner owner = new SafeOwner();
                Safe safe = new Safe();
                JewelThief jewelThief = new JewelThief();
                jewelThief.OpenSafe(safe, owner);
                Console.ReadKey(true);
            }
            private string contents = "precious jewels";
            private string safeCombination = "12345";
            public string Open(string combination)
            {
                if (combination == safeCombination) return contents;
                return "";
            }
            public void PickLock(Locksmith lockpicker)
            {
                lockpicker.Combination = safeCombination;
            }
        }//FIn de la class Safe
        class SafeOwner
        {
            private string valuables = "";
            public void ReceiveContents(string safeContents)
            {
                valuables = safeContents;
                Console.WriteLine($"Thank you for returning my {valuables}!");
            }
        }//FIn de la class SafeOwner
        class Locksmith
        {
            public void OpenSafe(Safe safe, SafeOwner owner)
            {
                safe.PickLock(this);
                string safeContents = safe.Open(Combination);
                ReturnContents(safeContents, owner);
            }
            public string Combination { private get; set; }
            protected virtual void ReturnContents(string safeContents, SafeOwner owner)
            {
                owner.ReceiveContents(safeContents);
            }
        }//FIn de la class Locksmith
        class JewelThief : Locksmith
        {
            private string stolenJewels;
            protected override void ReturnContents(string safeContents, SafeOwner owner)
            {
                stolenJewels = safeContents;
                Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
            }
        }//FIn de la class JewelThief


    } //=====================================|| Fin de la class ||======================================================//



    //===============================================================================//
    //                               Hi-Lo Game                                      //
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


    //===============================================================================//
    //                                 Heritage                                      //
    //===============================================================================//

    //Nouvelles class |Test Héritage|
    class Heritage
    {


        public static void TestHeritage()
        {
            while (true)
            {
                Bird bird;
                Console.Write("\nPress P for pigeon, O for ostrich: ");
                char key = Char.ToUpper(Console.ReadKey().KeyChar);
                if (key == 'P') bird = new Pigeon();
                else if (key == 'O') bird = new Ostrich();
                else return;
                Console.Write("\nHow many eggs should it lay? ");
                if (!int.TryParse(Console.ReadLine(), out int numberOfEggs)) return;
                Egg[] eggs = bird.LayEggs(numberOfEggs);
                foreach (Egg egg in eggs)
                {
                    Console.WriteLine(egg.Description);
                }
            }
        }

        class Egg
        {
            public double Size { get; private set; }
            public string Color { get; private set; }
            public Egg(double size, string color)
            {
                Size = size;
                Color = color;
            }
            public string Description
            {
                get { return $"A {Size:0.0}cm {Color} egg"; }
            }
        }
        class Bird
        {
            public static Random Randomizer = new Random();
            public virtual Egg[] LayEggs(int numberOfEggs)
            {
                Console.Error.WriteLine("Bird.LayEggs should never get called");
                return new Egg[0];
            }
        }
        class Pigeon : Bird
        {
            public override Egg[] LayEggs(int numberOfEggs)
            {
                Egg[] eggs = new Egg[numberOfEggs];
                for (int z = 0; z < numberOfEggs; z++)
                {
                    eggs[z] = new Egg(Bird.Randomizer.NextDouble() * 2 + 1, "white");
                }
                return eggs;
            }
        }
        class Ostrich : Bird
        {
            public override Egg[] LayEggs(int numberOfEggs)
            {
                Egg[] eggs = new Egg[numberOfEggs];
                for (int i = 0; i < numberOfEggs; i++)
                {
                    eggs[i] = new Egg(Bird.Randomizer.NextDouble() + 12, "speckled");
                }
                return eggs;
            }
        }

    }//Fin de la class Heritage

}     //=====================================|| Fin du namespace ||======================================================//
