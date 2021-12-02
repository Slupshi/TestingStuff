﻿using System;

namespace TestingStuff
{
    partial class Program
    {
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

    }}     //=====================================|| Fin du namespace ||======================================================//


