using System;
using System.Collections.Generic;

namespace TestingStuff
{
    partial class Program
    {

        partial class Lists
        {
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
        }
    }}     //=====================================|| Fin du namespace ||======================================================//


