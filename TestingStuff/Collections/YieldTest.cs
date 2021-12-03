using System;
using System.Collections.Generic;

namespace TestingStuff.Collections
{
    class YieldTest
    {
        static IEnumerable<string> SimpleEnumerable()
        {
            yield return "apples";
            yield return "oranges";
            yield return "bananas";
            yield return "unicorns";
        }
        public static void YieldTestMain()
        {
            foreach (var s in SimpleEnumerable()) Console.WriteLine(s);
        }
    }
}
