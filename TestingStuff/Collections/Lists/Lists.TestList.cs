using System;
using System.Collections.Generic;

namespace TestingStuff
{
    partial class Program
    {

        partial class Lists
        {
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
        }
    }}     //=====================================|| Fin du namespace ||======================================================//


