using System;
using System.Collections.Generic;

namespace TestingStuff
{
    partial class Program
    {
        class CaptainAmazing
        {
            public static void CaptainAmazingMain()
            {
                var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                var clones = new List<EvilClone>();
                while (true)
                {
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case 'a':
                            clones.Add(new EvilClone());
                            break;
                        case 'c':
                            Console.WriteLine("Clearing list at time {0}", stopwatch.ElapsedMilliseconds);
                            clones.Clear();
                            break;
                        case 'g':
                            Console.WriteLine("Collecting at time {0}", stopwatch.ElapsedMilliseconds);
                            GC.Collect();
                            break;
                        default:
                            return;
                    };
                }
            }



            class EvilClone
            {
                public static int CloneCount = 0;
                public int CloneID { get; } = ++CloneCount;
                public EvilClone() => Console.WriteLine("Clone #{0} is wreaking havoc", CloneID);
                ~EvilClone() => Console.WriteLine("Clone #{0} destroyed", CloneID);

            }
        }
    }

}
