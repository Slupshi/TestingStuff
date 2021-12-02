using System;
using System.Collections.Generic;

namespace TestingStuff
{
    partial class Program
    {

        partial class Dictionary
        {
            //===============================================================================//
            //                               LumberJack                                      //
            //===============================================================================//

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

                    foreach (LumberJack lumberJack in lumberjackQueue)
                    {
                        Console.WriteLine(" ");
                        for (int j = 0; j < lumberJack.NumberOfFlapJack; j++)
                        {
                            Console.WriteLine($"{lumberJack.Name} ate a {flapjackStack.Pop()}");
                        }
                    }
                    while (lumberjackQueue.Count > 0)
                    {
                        lumberjackQueue.Dequeue();
                    }
                }

            }//Fin de la class LumberJack

        }
    }}     //=====================================|| Fin du namespace ||======================================================//


