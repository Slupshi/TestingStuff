using System;

namespace TestingStuff
{
    class Program
    {


        static void Main(string[] args)
        {
            Elephant();


        }

        public int EarSize;
        public string Name;
        public bool IsSwapped = false;

        public static void Elephant()
        {
            Program lloyd = new Program() { Name = "Lloyd", EarSize = 40 };
            Program lucinda = new Program() { Name = "Lucinda", EarSize = 33 };

            Console.WriteLine("Press 1 for Lloyd, 2 for Lucinda, 3 to swap, 4 to exit");

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
    }
}
