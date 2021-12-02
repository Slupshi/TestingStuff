using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingStuff
{
    partial class Program
    {

        partial class Dictionary
        {
            //===============================================================================//
            //                                   LINQ                                        //
            //===============================================================================//

            public partial class LINQ
            {
                public static void ChooseLinq()
                {
                    Console.WriteLine("Press 1 for TestLinq, 2 for Comic, 3 for MagnetsLinq");
                    Console.WriteLine("Press 4 for JimmyLinq");
                    Console.WriteLine("Any other key to quit");
                    char linqKey = Char.ToUpper(Console.ReadKey().KeyChar);
                    switch (linqKey)
                    {
                        case '1':
                            Console.Clear();
                            TestLinq.TestLinqMain();
                            break;
                        case '2':
                            Console.Clear();
                            Comic.ComicMain();
                            break;
                        case '3':
                            Console.Clear();
                            LinqFridge.MagnetsLinq();
                            break;
                        case '4':
                            Console.Clear();
                            JimmyLinq.JimmyMain();
                            break;
                        default:
                            return;
                    }
                }

                class TestLinq
                {
                    public static void TestLinqMain()
                    {
                        List<int> numbers = new List<int>();
                        for (int i = 1; i <= 99; i++)
                            numbers.Add(i);
                        IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
                        foreach (int i in firstAndLastFive)
                        {
                            Console.Write($"{i} ");
                        }
                    }

                }//Fin de la class TestLinq

            }//Fin de la class LINQ

        }
    }
}     //=====================================|| Fin du namespace ||======================================================//


