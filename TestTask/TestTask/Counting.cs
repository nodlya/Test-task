using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public static class Counting
    {
        /// <summary> 
        /// Returns a sum of two minimal numbers in <paramref name="array"/> which has more than 2 elements.
        /// </summary>
        /// 
        /// obvious variant was using LINQ because it's laconine 
        /// but at the same time it's inefficient in contrast to 
        /// simple single loop
        /// 
        public static int SumMinimalArrayNumbers(int[] array)
        {
            if (array == null) throw new ArgumentNullException("array is empty");
            if (array.Length < 2)
                throw new ArgumentOutOfRangeException("array has less than 2 elements");

            var tuple = TwoMinimals(array);
            return tuple.Item1 + tuple.Item2;

            //return array.OrderBy(x => x).Take(2).Sum();
        }


        //finds two minimal numbers in array with a loop
        private static Tuple<int, int> TwoMinimals(int[] array)
        {
            int superMin = array[0];
            int almostMin = array[1];
            if (superMin > almostMin)
                SwapInts(ref superMin, ref almostMin);


            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] < superMin)
                {
                    almostMin = array[i];
                    SwapInts(ref superMin, ref almostMin);
                }
                else if (array[i] < almostMin)
                    almostMin = array[i];
            }

            return Tuple.Create(superMin, almostMin);
        }

        private static void SwapInts(ref int min1, ref int min2)
        {
            int t = min1;
            min1 = min2;
            min2 = t;
        }

    }
}
