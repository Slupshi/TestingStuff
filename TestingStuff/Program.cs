using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TestingStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press 1 to go on the Page 2, 2 for the SuperCalculator 3090Super, 3 for Tests Heritage");
            Console.WriteLine("Press 4 for Cards, 5 for LISTS, 6 for Pool Puzzles ");
            Console.WriteLine("Press 7 for Dictionary, 8 for //, 9 for Test");
            Console.WriteLine("Press * to exit");
            char input = Console.ReadKey(true).KeyChar;
            if (input == '1') { Console.Clear(); SecondPage(); }
            else if (input == '2') { Console.Clear(); Weapons.DamageCalculator(); }
            else if (input == '3') { Console.Clear(); PageHeritage(); }
            else if (input == '4') { Console.Clear(); Cards.ChooseCard(); }
            else if (input == '5') { Console.Clear(); Lists.ChooseList(); }
            else if (input == '6') { Console.Clear(); PoolPuzzles(); }
            else if (input == '7') { Console.Clear(); Dictionary.ChooseDico(); }
            else if (input == '8') { Console.Clear(); }
            else if (input == '9') { Console.Clear(); }

            else if (input == '*') return;
            else { Console.WriteLine("ARE YOU DUMB ??"); }
        }

        private static void PoolPuzzles()
        {
            Console.WriteLine("Press 1 for the Maths Quizz, 2 for the ClownShit");
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

        //===============================================================================//
        //                          Weapons Damages Calculator                           //
        //===============================================================================//

        //Nouvelle class Weapons
        class Weapons
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
        }//Fin de la class Weapons

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
        //                         Pool Puzzle : Clown ? (409)                           //
        //===============================================================================//

        class Clown
        {
            internal static void Clown16()
            {
                Of2016.Clown2016();
            }

            abstract class Picasso : INose
            {
                private string face;
                public virtual string Face
                {
                    get { return face; }
                }
                public abstract int Ear();
                public Picasso(string face)
                {
                    this.face = face;
                }
            }

            class Clowns : Picasso
            {
                public Clowns() : base("Clowns") { }
                public override int Ear()
                {
                    return 7;
                }
            }

            class Acts : Picasso
            {
                public Acts() : base("Acts") { }
                public override int Ear()
                {
                    return 5;
                }
            }

            class Of2016 : Clowns
            {
                public override string Face
                {
                    get { return "Of2016"; }
                }
                public static void Clown2016()
                {
                    string result = "";
                    INose[] i = new INose[3];
                    i[0] = new Acts();
                    i[1] = new Clowns();
                    i[2] = new Of2016();
                    for (int x = 0; x < 3; x++)
                    {
                        result +=
                        $"{ i[x].Ear() } { i[x].Face }\n";
                    }
                    Console.WriteLine(result);
                    Console.ReadKey();
                }
            }
        }//Fin de a class Clown

        //===============================================================================//
        //                                Coffre-Fort                                    //
        //===============================================================================//

        //Nouvelle clas Safe
        class JewelsSafe
        {
            public static void Vault()
            {
                SafeOwner owner = new SafeOwner();
                Safe safe = new Safe();
                JewelThief jewelThief = new JewelThief();
                jewelThief.OpenSafe(safe, owner);
                Console.ReadKey(true);
            }
            class Safe
            {


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
        }

        //===============================================================================//
        //                                   ZOO                                         //
        //===============================================================================//

        class Zoo
        {
            public static void MainZOO()
            {
                Animal[] animals =
                {
                    new Wolf(false),
                    new Hippo(),
                    new Wolf(true),
                    new Wolf(false),
                    new Hippo()
                };
                foreach (Animal animal in animals)
                {
                    animal.MakeNoise();
                    if (animal is ISwimmer swimmer)
                    {
                        swimmer.Swim();
                    }
                    if (animal is IPackHunter packHunter)
                    {
                        packHunter.HuntInPack();
                    }
                    Console.WriteLine();
                }
            }

            abstract class Animal
            {
                public abstract void MakeNoise();
            }
            class Hippo : Animal, ISwimmer
            {
                public override void MakeNoise()
                {
                    Console.WriteLine("Grunt.");
                }
                public void Swim()
                {
                    Console.WriteLine("Splash! I'm going for a swim!");
                }
            }
            abstract class Canine : Animal
            {
                public bool BelongsToPack { get; protected set; } = false;
            }
            class Wolf : Canine, IPackHunter
            {
                public Wolf(bool belongsToPack)
                {
                    BelongsToPack = belongsToPack;
                }
                public override void MakeNoise()
                {
                    if (BelongsToPack)
                        Console.WriteLine("I'm in a pack.");
                    Console.WriteLine("Aroooooo!");
                }
                public void HuntInPack()
                {
                    if (BelongsToPack)
                        Console.WriteLine("I'm going hunting with my pack!");
                    else
                        Console.WriteLine("I'm not in a pack.");
                }
            }
        }//Fin de la class ZOO

    } //=====================================|| Fin de la class ||======================================================//

    //===============================================================================//
    //                                   IClowns                                     //
    //===============================================================================//

    class IClowns
    {
        /* Réponse :
         * class FunnyFunny : IClown
         {
             private string funnyThingIHave;
             public string FunnyThingIHave { get { return funnyThingIHave; } }

             public FunnyFunny(string funnyThingIHave)
             {
                 this.funnyThingIHave = funnyThingIHave;
             }

             public void Honk()
             {
                 Console.WriteLine($"Hi kids! I have a {funnyThingIHave}.");
             }
         }

         class ScaryScary : FunnyFunny, IScaryClown
         {
             private int scaryThingCount;
             public ScaryScary(string funnyThing, int scaryThingCount) : base(funnyThing)
             {
                 this.scaryThingCount = scaryThingCount;
             }
             public string ScaryThingIHave { get { return $"{scaryThingCount} spiders"; } }
             public void ScareLittleChildren()
             {
                 Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave}!");
             }
         }

         static void Main(string[] args)
         {
             IClown fingersTheClown = new ScaryScary("big red nose", 14);
             fingersTheClown.Honk();
             if (fingersTheClown is IScaryClown iScaryClownReference)
             {
                 iScaryClownReference.ScareLittleChildren();
             }
         } */


        public static void IClownMain()
        {
            IClown fingersTheClown = new ScaryScary("big red nose", 14);
            fingersTheClown.Honk();
            IScaryClown iScaryClownReference = fingersTheClown as IScaryClown;
            iScaryClownReference.ScareAdults();
            IClown.CarCapacity = 18;
            Console.WriteLine(IClown.ClownCarDescription());
        }

        class FunnyFunny : IClown
        {
            private string funnyThingIHave;
            public string FunnyThingIHave
            {
                get { return funnyThingIHave; }
                private set { }
            }

            public FunnyFunny(string funnyThingIHave)
            {
                FunnyThingIHave = funnyThingIHave;
            }

            public void Honk()
            {
                Console.WriteLine($"Hi kids! I have a {FunnyThingIHave}");
            }
        }//Fin de la class FunnyFunny

        class ScaryScary : IScaryClown
        {

            public ScaryScary(string funny, int scary)
            {
                scaryThingCount = scary;
                funnyThingIHave = funny;
            }

            private readonly string funnyThingIHave;
            public string FunnyThingIHave
            {
                get { return funnyThingIHave; }
                private set { }
            }
            private readonly int scaryThingCount;
            public string ScaryThingIHave
            {
                get { return ($"{scaryThingCount} spiders"); }
            }

            public void Honk()
            {
                Console.WriteLine($"Hi kids! I have a {FunnyThingIHave}");
            }
            public void ScareLittleChildren()
            {
                Console.WriteLine($"Boo! Gotcha! Look at my {ScaryThingIHave} !");
            }
        }//Fin de la class ScaryScary

    }//Fin de la class IClowns

    //===============================================================================//
    //                                 Heritage                                      //
    //===============================================================================//

    //Nouvelles class |Test Héritage|
    class Heritage
    {


        public static void TestBird()
        {
            while (true)
            {
                Bird bird;
                Console.Write("Press P for pigeon, O for ostrich: ");
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
        class BrokenEgg : Egg
        {
            public BrokenEgg(string color) : base(0, $"broken {color}")
            {
                Console.WriteLine("A bird laid a broken egg");
            }
        }
        abstract class Bird
        {
            public static Random Randomizer = new Random();
            public abstract Egg[] LayEggs(int numberOfEggs);

        }
        class Pigeon : Bird
        {
            public override Egg[] LayEggs(int numberOfEggs)
            {
                Egg[] eggs = new Egg[numberOfEggs];
                for (int z = 0; z < numberOfEggs; z++)
                {
                    if (Bird.Randomizer.Next(4) == 0)
                        eggs[z] = new BrokenEgg("white");
                    else
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

    //===============================================================================//
    //                              TallGuy / Interface                              //
    //===============================================================================//

    class TallGuy : IClown
    {
        public string FunnyThingIHave
        {
            get { return "big shoes"; }
        }
        public void Honk()
        {
            Console.WriteLine("Honk honk!");
        }

        public static void TallGuyMethod()
        {
            TallGuy tallGuy = new TallGuy() { Height = 76, Name = "Jimmy" };
            tallGuy.TalkAboutYourself();
            Console.WriteLine($"The tall guy has {tallGuy.FunnyThingIHave}");
            tallGuy.Honk();
        }

        public string Name;
        public int Height;
        public void TalkAboutYourself()
        {
            Console.WriteLine($"My name is {Name} and I'm {Height} inches tall.");
        }
    }//Fin de la class TallGuy

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

    //===============================================================================//
    //                                    Cards                                      //
    //===============================================================================//

    class Cards
    {
        public static void ChooseCard()
        {
            Console.WriteLine("Press 1 for EnumCard, 2 for CardsList");
            Console.WriteLine("Any other key to quit");
            char cardKey = Char.ToUpper(Console.ReadKey().KeyChar);
            switch (cardKey)
            {
                case '1':
                    Console.Clear();
                    Card.EnumCard();
                    break;
                case '2':
                    Console.Clear();
                    CardsList.CardsListMain();
                    break;
                default:
                    return;
            }
        }

        class CardsList
        {
            static List<CardsList> myCardList = new List<CardsList>();
            public Values Value { get; private set; }
            public Suits Suit { get; private set; }
            public string Name { get { return $"{Value} of {Suit}"; } }
            public CardsList(Values value, Suits suit)
            {
                this.Value = value;
                this.Suit = suit;

            }
            private static readonly Random random = new Random();

            public static void CardsListMain()
            {
                while (true)
                {
                    Console.Write("How many cards do you want to peek ? ");
                    int numberOfCards;
                    if (int.TryParse(Console.ReadLine(), out numberOfCards))
                    {
                        Console.Clear();
                        Console.Write($"How many cards do you want to peek ? [{numberOfCards}]\n");
                        Thread.Sleep(200);
                        int loadingTimeCard = numberOfCards * 30;
                        if (numberOfCards == 1) { Console.Write($"\nPeeking {numberOfCards} random card"); }
                        else { Console.Write($"\nPeeking {numberOfCards} random cards"); }
                        Thread.Sleep(loadingTimeCard);
                        Console.Write(" .");
                        Thread.Sleep(loadingTimeCard);
                        Console.Write(".");
                        Thread.Sleep(loadingTimeCard);
                        Console.Write(".");
                        Thread.Sleep(loadingTimeCard);
                        Console.WriteLine("\nHere are your cards !\n");
                        Thread.Sleep(300);
                        CreateCardsList(numberOfCards);
                        bool sort = true;
                        while (sort)
                        {
                            Console.Write($"\nDo you want to sort them ? [Y/N]\n");
                            char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                            if (input == 'Y') { sort = true; Console.Clear(); CardSorting(); }
                            else if (input == 'N') { sort = false; EmptyCardList(); }
                            else return;
                        }
                    }
                }
            }

            private static void PrintCardList()
            {
                foreach (CardsList myCards in myCardList)
                {
                    Console.WriteLine(myCards.Name);
                    Thread.Sleep(200);
                }
            }

            private static void CreateCardsList(int numberOfCardsToPeek)
            {

                for (int i = 0; i < numberOfCardsToPeek; i++)
                {
                    int numberBetween0and3 = random.Next(4);
                    int numberBetween1and13 = random.Next(1, 14);
                    CardsList myCards = new CardsList((Values)numberBetween1and13, (Suits)numberBetween0and3);
                    myCardList.Add(myCards);

                }
                PrintCardList();
            }

            public static CardSortCriteria SortBy;
            public static void CardSorting()
            {
                CardComparer comparer = new CardComparer();
                Console.WriteLine($"Do you want to sort them by Suit then by Value ? [S]");
                Console.WriteLine($"Or Do you want to sort them by Value then Suit ? [V]\n");
                char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                if (input == 'S') { SortBy = CardSortCriteria.SuitThenValue; myCardList.Sort(comparer); PrintCardList(); CardsCounter(); }
                else if (input == 'V') { SortBy = CardSortCriteria.ValueThenSuit; myCardList.Sort(comparer); PrintCardList(); CardsCounter(); }
                else return;
            }

            private static void EmptyCardList()
            {
                Console.Write($"\nDo you want to keep your list ? [Y/N]\n");
                char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                if (input == 'Y') { Console.Clear(); }
                else if (input == 'N')
                {
                    for (int i = myCardList.Count - 1; i >= 0; i--)
                    {
                        myCardList.RemoveAt(i);
                    }
                    Console.WriteLine("Your list is now empty ! Please Wait..");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else return;
            }

            private static void CardsCounter()
            {
                SuitCounter();
                ValueCounter();
            }

            private static void SuitCounter()
            {
                int counterDiamonds = 0;
                int counterClubs = 0;
                int counterHearts = 0;
                int counterSpades = 0;
                string sDiamonds = "s ";
                string sClubs = "s ";
                string sHearts = "s ";
                string sSpades = "s ";
                foreach (CardsList myCards in myCardList)
                {
                    switch (myCards.Suit)
                    {
                        case Suits.Diamonds:
                            counterDiamonds++;
                            break;
                        case Suits.Clubs:
                            counterClubs++;
                            break;
                        case Suits.Hearts:
                            counterHearts++;
                            break;
                        case Suits.Spades:
                            counterSpades++;
                            break;
                    }
                }
                if (counterDiamonds == 0 || counterDiamonds == 1) { sDiamonds = " "; }
                if (counterClubs == 0 || counterClubs == 1) { sClubs = " "; }
                if (counterHearts == 0 || counterHearts == 1) { sHearts = " "; }
                if (counterSpades == 0 || counterSpades == 1) { sSpades = " "; }

                Thread.Sleep(200);
                Console.WriteLine($"\nThere are {counterDiamonds} Diamond{sDiamonds}/ {counterClubs} Club{sClubs}/ " +
                    $"{counterHearts} Heart{sHearts}/ {counterSpades} Spade{sSpades}");
            }

            private static void ValueCounter()
            {
                int counterAce = 0;
                int counterTwo = 0;
                int counterThree = 0;
                int counterFour = 0;
                int counterFive = 0;
                int counterSix = 0;
                int counterSeven = 0;
                int counterEight = 0;
                int counterNine = 0;
                int counterTen = 0;
                int counterJack = 0;
                int counterQueen = 0;
                int counterKing = 0;
                string sJack = "s ";
                string sQueen = "s ";
                string sKing = "s ";
                foreach (CardsList myCards in myCardList)
                {
                    switch (myCards.Value)
                    {
                        case Values.Ace:
                            counterAce++;
                            break;
                        case Values.Two:
                            counterTwo++;
                            break;
                        case Values.Three:
                            counterThree++;
                            break;
                        case Values.Four:
                            counterFour++;
                            break;
                        case Values.Five:
                            counterFive++;
                            break;
                        case Values.Six:
                            counterSix++;
                            break;
                        case Values.Seven:
                            counterSeven++;
                            break;
                        case Values.Eight:
                            counterEight++;
                            break;
                        case Values.Nine:
                            counterNine++;
                            break;
                        case Values.Ten:
                            counterTen++;
                            break;
                        case Values.Jack:
                            counterJack++;
                            break;
                        case Values.Queen:
                            counterQueen++;
                            break;
                        case Values.King:
                            counterKing++;
                            break;
                    }
                }
                if (counterJack == 0 || counterJack == 1) { sJack = " "; }
                if (counterQueen == 0 || counterQueen == 1) { sQueen = " "; }
                if (counterKing == 0 || counterKing == 1) { sKing = " "; }
                Thread.Sleep(200);
                Console.WriteLine($"\nThere are {counterAce} Ace / {counterTwo} Two / {counterThree} Three / {counterFour} Four " +
                    $"/ {counterFive} Five / {counterSix} Six / " +
                    $"{counterSeven} Seven / {counterEight} Eight / {counterNine} Nine / {counterTen} Ten / {counterJack} Jack{sJack}" +
                    $"/ {counterQueen} Queen{sQueen}/ \n{counterKing} King{sKing}");

            }

            class CardComparer : IComparer<CardsList>
            {
                public int Compare(CardsList x, CardsList y)
                {
                    if (SortBy == CardSortCriteria.SuitThenValue)
                        if (x.Suit > y.Suit)
                            return 1;
                        else if (x.Suit < y.Suit)
                            return -1;
                        else
                        if (x.Value > y.Value)
                            return 1;
                        else if (x.Value < y.Value)
                            return -1;
                        else
                            return 0;
                    else
                    if (x.Value > y.Value)
                        return 1;
                    else if (x.Value < y.Value)
                        return -1;
                    else
                    if (x.Suit > y.Suit)
                        return 1;
                    else if (x.Suit < y.Suit)
                        return -1;
                    else
                        return 0;
                }
            }//Fin de la class CardComparer

        }//Fin de la class CardsList

        class Card
        {
            public Values Value { get; private set; }
            public Suits Suit { get; private set; }
            public string Name { get { return $"{Value} of {Suit}"; } }
            public Card(Values value, Suits suit)
            {
                this.Value = value;
                this.Suit = suit;

            }

            private static readonly Random random = new Random();

            public static void EnumCard()
            {
                Console.WriteLine("Press Q to quit, any other key to continue");
                int numberOfLine = 1;
                while (true)
                {
                    int numberBetween0and3 = random.Next(4);
                    int numberBetween1and13 = random.Next(1, 14);
                    int anyRandomInteger = random.Next();

                    Card myCard = new Card((Values)numberBetween1and13, (Suits)numberBetween0and3);
                    Console.WriteLine(myCard.Name);

                    numberOfLine += 1;
                    if (numberOfLine >= 30) { Console.Clear(); Console.WriteLine("Press Q to quit, any other key to continue"); numberOfLine = 1; }
                    char input = Char.ToUpper(Console.ReadKey(true).KeyChar);
                    if ((input == 'Q')) return;
                }


            }

        }//Fin de la class Card

    }//Fin de la class Cards

    //===============================================================================//
    //                                    LISTS                                      //
    //===============================================================================//

    class Lists
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

        //===============================================================================//
        //                                    Shoes                                      //
        //===============================================================================//

        class Shoes
        {
            static ShoeCloset shoeCloset = new ShoeCloset();
            public static void ShoesMain()
            {
                while (true)
                {
                    shoeCloset.PrintShoes();
                    Console.Write("\nPress 'a' to add or 'r' to remove a shoe: ");
                    char key = Console.ReadKey().KeyChar;
                    switch (key)
                    {
                        case 'a':
                        case 'A':
                            shoeCloset.AddShoe();
                            break;
                        case 'r':
                        case 'R':
                            shoeCloset.RemoveShoe();
                            break;
                        default:
                            return;
                    }
                }
            }

            class Shoe
            {
                public Style Style
                {
                    get; private set;
                }
                public string Color
                {
                    get; private set;
                }
                public Shoe(Style style, string color)
                {
                    Style = style;
                    Color = color;
                }
                public string Description
                {
                    get { return $"A {Color} {Style}"; }
                }
            }//Fin de la class Shoe

            class ShoeCloset
            {
                private readonly List<Shoe> shoes = new List<Shoe>();
                public void PrintShoes()
                {
                    if (shoes.Count == 0)
                    {
                        Console.WriteLine("\nThe shoe closet is empty.");
                    }
                    else
                    {
                        Console.WriteLine("\nThe shoe closet contains:");
                        int i = 1;
                        foreach (Shoe shoe in shoes)
                        {
                            Console.WriteLine($"Shoe #{i++}: {shoe.Description}");
                        }
                    }
                }
                public void AddShoe()
                {
                    Console.WriteLine("\nAdd a shoe");
                    for (int i = 0; i < 6; i++)
                    {
                        Console.WriteLine($"Press {i} to add a {(Style)i}");
                    }
                    Console.Write("Enter a style: ");
                    if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int style))
                    {
                        Console.Write("\nEnter the color: ");
                        string color = Console.ReadLine();
                        Shoe shoe = new Shoe((Style)style, color);
                        shoes.Add(shoe);
                    }
                }
                public void RemoveShoe()
                {
                    Console.Write("\nEnter the number of the shoe to remove: ");
                    if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int shoeNumber) &&
                    (shoeNumber >= 1) && (shoeNumber <= shoes.Count))
                    {
                        Console.WriteLine($"\nRemoving {shoes[shoeNumber - 1].Description}");
                        shoes.RemoveAt(shoeNumber - 1);
                    }
                }
            }//Fin de la class ShoeCloset

        }//Fin de la class Shoes

        //===============================================================================//
        //                                    TEST                                       //
        //===============================================================================//

        class TestList
        {

            public static void TestListMain()
            {

                List<string> a = new List<string>();
                PppPppL(a);
                static void PppPppL(List<string> a)
                {

                    string zilch = "zero";
                    string first = "one";
                    string second = "two";
                    string third = "three";
                    string fourth = "4.2";
                    string twopointtwo = "2.2";
                    a.Add(zilch);
                    a.Add(first);
                    a.Add(second);
                    a.Add(third);
                    a.RemoveAt(2);
                    if (a.Contains("three"))
                    {
                        a.Add("four");
                    }
                    if (a.IndexOf("four") != 4)
                    {
                        a.Add(fourth);
                    }
                    if (a.Contains("two"))
                    {
                        a.Add(twopointtwo);
                    }
                    foreach (string element in a)
                    {
                        Console.WriteLine(element);
                    }
                }
            }
        }//Fin de la class Test

        //===============================================================================//
        //                                     Duck                                      //
        //===============================================================================//

        class Duck : IComparable<Duck>
        {
            public static void Ducks()
            {
                List<Duck> ducks = new List<Duck>() {
                new Duck() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 14 },
                new Duck() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Duck() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Duck() { Kind = KindOfDuck.Loon, Size = 13 }, };
                IComparer<Duck> sizeComparer = new DuckComparerBySize();
                ducks.Sort(sizeComparer);
                PrintDucks(ducks);
                DuckComparer comparer = new DuckComparer();
                Console.WriteLine("\nSorting by kind then size\n");
                comparer.SortBy = DuckSortCriteria.KindThenSize;
                ducks.Sort(comparer);
                PrintDucks(ducks);
                Console.WriteLine("\nSorting by size then kind\n");
                comparer.SortBy = DuckSortCriteria.SizeThenKind;
                ducks.Sort(comparer);
                PrintDucks(ducks);
            }

            public int Size
            {
                get; set;
            }
            public KindOfDuck Kind
            {
                get; set;
            }
            public int CompareTo(Duck duckToCompare)
            {
                if (this.Size > duckToCompare.Size)
                    return 1;
                else if (this.Size < duckToCompare.Size)
                    return -1;
                else
                    return 0;
            }
            public static void PrintDucks(List<Duck> ducks)
            {
                foreach (Duck duck in ducks)
                {
                    Console.WriteLine($"{duck.Size} inch {duck.Kind}");
                }
            }

            class DuckComparerBySize : IComparer<Duck>
            {
                public int Compare(Duck x, Duck y)
                {
                    if (x.Size < y.Size)
                        return -1;
                    if (x.Size > y.Size)
                        return 1;
                    return 0;
                }
            }//Fin de la class DuckComparerBySize

            class DuckComparerByKind : IComparer<Duck>
            {
                public int Compare(Duck x, Duck y)
                {
                    if (x.Kind < y.Kind)
                        return -1;
                    if (x.Kind > y.Kind)
                        return 1;
                    else
                        return 0;
                }
            }//Fin de la class DuckComparerBykind

            class DuckComparer : IComparer<Duck>
            {
                public DuckSortCriteria SortBy = DuckSortCriteria.SizeThenKind;
                public int Compare(Duck x, Duck y)
                {
                    if (SortBy == DuckSortCriteria.SizeThenKind)
                        if (x.Size > y.Size)
                            return 1;
                        else if (x.Size < y.Size)
                            return -1;
                        else
                        if (x.Kind > y.Kind)
                            return 1;
                        else if (x.Kind < y.Kind)
                            return -1;
                        else
                            return 0;
                    else
                    if (x.Kind > y.Kind)
                        return 1;
                    else if (x.Kind < y.Kind)
                        return -1;
                    else
                    if (x.Size > y.Size)
                        return 1;
                    else if (x.Size < y.Size)
                        return -1;
                    else
                        return 0;
                }
            }//Fin de la class DuckComparer

        }//Fin de la class Duck

        class Birds
        {
            public string Name { get; set; }
            public virtual void Fly(string destination)
            {
                Console.WriteLine($"{this} is flying to {destination}");
            }
            public override string ToString()
            {
                return $"A bird named {Name}";
            }
            public static void FlyAway(List<Birds> flock, string destination)
            {
                foreach (Birds bird in flock)
                {
                    bird.Fly(destination);
                }
            }
        }//Fin de la class Birds

        class Ducks : Birds
        {

            public static void DuckBird()
            {
                List<Ducks> ducks = new List<Ducks>() {
                new Ducks() { Kind = KindOfDuck.Mallard, Size = 17 },
                new Ducks() { Kind = KindOfDuck.Muscovy, Size = 18 },
                new Ducks() { Kind = KindOfDuck.Loon, Size = 14 },
                new Ducks() { Kind = KindOfDuck.Muscovy, Size = 11 },
                new Ducks() { Kind = KindOfDuck.Mallard, Size = 14 },
                new Ducks() { Kind = KindOfDuck.Loon, Size = 13 }, };
                IEnumerable<Birds> upcastDucks = ducks;
                Birds.FlyAway(upcastDucks.ToList(), "Minnesota");
            }

            public int Size { get; set; }
            public KindOfDuck Kind { get; set; }
            public override string ToString()
            {
                return $"A {Size} inch {Kind}";
            }
        }//Fin de la class Ducks
    }//Fin de la class Lists

    //===============================================================================//
    //                        Dictionary / Stack / Queue                             //
    //===============================================================================//

    class Dictionary
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
                default:
                    return;
            }
        }

        class RetiredPlayer
        {
            public string Name { get; private set; }
            public int YearRetired { get; private set; }
            public RetiredPlayer(string player, int yearRetired)
            {
                Name = player;
                YearRetired = yearRetired;
            }

            public static void RetiredPlayersMain()
            {
                Dictionary<int, RetiredPlayer> retiredYankees = new Dictionary<int, RetiredPlayer>() {
                {3, new RetiredPlayer("Babe Ruth", 1948)},
                {4, new RetiredPlayer("Lou Gehrig", 1939)},
                {5, new RetiredPlayer("Joe DiMaggio", 1952)},
                {7, new RetiredPlayer("Mickey Mantle", 1969)},
                {8, new RetiredPlayer("Yogi Berra", 1972)},
                {10, new RetiredPlayer("Phil Rizzuto", 1985)},
                {23, new RetiredPlayer("Don Mattingly", 1997)},
                {42, new RetiredPlayer("Jackie Robinson", 1993)},
                {44, new RetiredPlayer("Reggie Jackson", 1993)},};

                foreach (int jerseyNumber in retiredYankees.Keys)
                {
                    RetiredPlayer player = retiredYankees[jerseyNumber];
                    Console.WriteLine($"{player.Name} #{jerseyNumber} retired in {player.YearRetired}");
                }
            }
        }//Fin de la class RetiredPlayers

        class LumberJack
        {
            public static void LumberJackMain()
            {
                Console.Write("First lumberjack's name: ");
                string inputName = Console.ReadLine();
                Console.Write("Number of flapjacks: ");
                if (int.TryParse(Console.ReadLine(), out int inputFlapJack)) { TakeFlapJack(inputFlapJack); }
                else return;
                MakeLumberJackWait(inputName, inputFlapJack);
                while (inputName != "")
                {
                    Console.Write("Next lumberjack's name (blank to end): ");
                    inputName = Console.ReadLine();
                    if (inputName != "")
                    {
                        Console.Write("Number of flapjacks: ");
                        if (int.TryParse(Console.ReadLine(), out inputFlapJack)) { TakeFlapJack(inputFlapJack); }
                        else return;
                        MakeLumberJackWait(inputName, inputFlapJack);
                    }
                }
                EatFlapJack();

            }

            private static void MakeLumberJackWait(string inputName, int inputFlapJack)
            {
                LumberJack newLumberJack = new LumberJack(inputName, inputFlapJack);
                lumberjackQueue.Enqueue(newLumberJack);
            }

            public string Name { get; private set; }
            public int NumberOfFlapJack { get; private set; }
            private LumberJack(string name, int numberOfFlapJack)
            {
                this.Name = name;
                this.NumberOfFlapJack = numberOfFlapJack;
            }
            private static Stack<FlapJack> flapjackStack = new Stack<FlapJack>();
            private static Queue<LumberJack> lumberjackQueue = new Queue<LumberJack>();
            private static readonly Random random = new Random();

            private static void TakeFlapJack(int numberOfFlapJackToCook)
            {
                for (int i = 0; i < numberOfFlapJackToCook; i++)
                {
                    flapjackStack.Push((FlapJack)random.Next(4));
                }


            }

            private static void EatFlapJack()
            {
                int lumberJackWhoAte = 0;
                foreach (LumberJack lumberJack in lumberjackQueue)
                {
                    Console.WriteLine(" ");
                    for (int j = 0; j < lumberJack.NumberOfFlapJack; j++)
                    {
                        Console.WriteLine($"{lumberJack.Name} ate a {flapjackStack.Pop()}");
                    }
                    lumberJackWhoAte++;
                }
                for (int k = 0; k < lumberJackWhoAte; k++)
                {
                    lumberjackQueue.Dequeue();
                }
            }

        }//Fin de la class LumberJack

    }//Fin de la class Disctionary

}     //=====================================|| Fin du namespace ||======================================================//


/*Exemple de Main Method avec un Dictionary
 * 
Dictionary<string, string> favoriteFoods = new Dictionary<string, string>();
 favoriteFoods["Alex"] = "hot dogs";
 favoriteFoods["A'ja"] = "pizza";
 favoriteFoods["Jules"] = "falafel";
 favoriteFoods["Naima"] = "spaghetti";
 string name;
 while ((name = Console.ReadLine()) != "")
 {
 if (favoriteFoods.ContainsKey(name))
 Console.WriteLine($"{name}'s favorite food is {favoriteFoods[name]}");
 else
 Console.WriteLine($"I don't know {name}'s favorite food");
 } 
*/