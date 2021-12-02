using System;

namespace TestingStuff
{
    partial class Program
    {
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

    }}     //=====================================|| Fin du namespace ||======================================================//


