using System;

namespace TestingStuff
{
    partial class Program
    {
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

    }}     //=====================================|| Fin du namespace ||======================================================//


