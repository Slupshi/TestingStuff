using System;

namespace TestingStuff
{
    partial class Program
    {
        //===============================================================================//
        //                                Coffre-Fort                                    //
        //===============================================================================//

        //Nouvelle clas Safe
        class JewelsSafe
        {
            public static void Vault()
            {
                SafeOwner owner = new SafeOwner();
                Safe safe = new Safe();
                JewelThief jewelThief = new JewelThief();
                jewelThief.OpenSafe(safe, owner);
                Console.ReadKey(true);
            }
            class Safe
            {


                private string contents = "precious jewels";
                private string safeCombination = "12345";
                public string Open(string combination)
                {
                    if (combination == safeCombination) return contents;
                    return "";
                }
                public void PickLock(Locksmith lockpicker)
                {
                    lockpicker.Combination = safeCombination;
                }
            }//FIn de la class Safe
            class SafeOwner
            {
                private string valuables = "";
                public void ReceiveContents(string safeContents)
                {
                    valuables = safeContents;
                    Console.WriteLine($"Thank you for returning my {valuables}!");
                }
            }//FIn de la class SafeOwner
            class Locksmith
            {
                public void OpenSafe(Safe safe, SafeOwner owner)
                {
                    safe.PickLock(this);
                    string safeContents = safe.Open(Combination);
                    ReturnContents(safeContents, owner);
                }
                public string Combination { private get; set; }
                protected virtual void ReturnContents(string safeContents, SafeOwner owner)
                {
                    owner.ReceiveContents(safeContents);
                }
            }//FIn de la class Locksmith
            class JewelThief : Locksmith
            {
                private string stolenJewels;
                protected override void ReturnContents(string safeContents, SafeOwner owner)
                {
                    stolenJewels = safeContents;
                    Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
                }
            }//FIn de la class JewelThief
        }

    }}     //=====================================|| Fin du namespace ||======================================================//


