using System;
using System.Collections.Generic;

namespace TestingStuff.Collections
{
    class ManualSportSequence : IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            return new ManualSportEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class ManualSportEnumerator : IEnumerator<Sport>
    {
        int current = -1;
        public Sport Current { get { return (Sport)current; } }
        public void Dispose() { return; }
        object System.Collections.IEnumerator.Current { get { return Current; } }
        public bool MoveNext()
        {
            var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
            if ((int)current >= maxEnumValue - 1)
                return false;
            current++;
            return true;
        }
        public void Reset() { current = 0; }
    }
    //=============================================================================================//
    class BetterSportSequence : IEnumerable<Sport>
    {
        public IEnumerator<Sport> GetEnumerator()
        {
            int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
            for (int i = 0; i <= maxEnumValue; i++)
            {
                yield return (Sport)i;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }








}
