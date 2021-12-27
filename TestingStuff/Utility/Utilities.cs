using System;
using System.Threading;

namespace TestingStuff.Utility
{
    class Utilities
    {
        /// <summary>
        /// Write 3 dots with 0.3s of delay between each one
        /// </summary>
        public static void LoadingDots()
        {
            for (int d = 0; d < 3; d++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }
            Thread.Sleep(300);
            Console.WriteLine();
        }

        /// <summary>
        /// Write 3 dots with a custom delay
        /// </summary>
        /// <param name="delay">The delay between each dot</param>
        public static void LoadingDots(int delay)
        {
            for (int d = 0; d < 3; d++)
            {
                Thread.Sleep(delay);
                Console.Write(".");
            }
            Thread.Sleep(delay);
            Console.WriteLine();
        }

        /// <summary>
        /// Wait 5s before automatically close the consol app 
        /// </summary>
        public static void WaitToClose() => Thread.Sleep(5000);

    }
}
