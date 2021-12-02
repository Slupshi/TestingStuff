using System;
using System.Linq;

namespace TestingStuff
{
    partial class Program
    {

        partial class Dictionary
        {

            partial class LINQ
            {
                class LinqFridge
                {
                    public static void MagnetsLinq()
                    {
                        //Output : "Get your kicks on route 66"

                        int[] badgers = { 36, 5, 91, 3, 41, 69, 8 };

                        var skunks =
                            from pigeon in badgers
                            where (pigeon != 36 && pigeon < 50)
                            orderby pigeon descending
                            select pigeon + 5; //Ajoute 5 a chaque nombre de pigeon

                        var bears = skunks.Take(3); // Garde les 3 premiers nombres de Skunks (index : 0,1,2)

                        var weasels =
                            from sparrow in bears
                            select sparrow - 1;

                        Console.WriteLine("Get your kicks on route {0}", weasels.Sum());
                    }
                }//Fin de la class LinqFridge

            }
        }
    }}     //=====================================|| Fin du namespace ||======================================================//


