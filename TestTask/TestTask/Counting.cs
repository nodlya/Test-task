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
        public static long SumMinimalArrayNumbers(int[] array)
        {
            if (array == null) throw new ArgumentNullException("array is empty");
            if (array.Length < 2)
                throw new ArgumentOutOfRangeException("array has less than 2 elements");

            var tuple = TwoMinimals(array);
            return (long)tuple.Item1 + tuple.Item2;

            //return array.OrderBy(x => x).Take(2).Sum();
        }


        //finds two minimal numbers in array with a loop
        private static Tuple<int, int> TwoMinimals(int[] array)
        {
            int superMin = int.MaxValue;
            int almostMin = int.MaxValue;
            

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= superMin)
                {
                    int t = superMin;
                    superMin = array[i];
                    almostMin = t;
                }
                else if (array[i] <= almostMin)
                    almostMin = array[i];
            }

            return Tuple.Create(superMin, almostMin);
        }

    }
}
