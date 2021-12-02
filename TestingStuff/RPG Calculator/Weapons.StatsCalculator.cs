using System;

namespace TestingStuff
{
    partial class Program
    {
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

    }

}     //=====================================|| Fin du namespace ||======================================================//


