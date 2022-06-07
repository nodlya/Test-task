using System;
using System.Collections.Generic;
using System.Linq;
using TestTask;
using Xunit;

namespace MinimumsTest
{
    
    public class MininmumsTest
    {
        [Fact]
        public void TestExceptions()
        {
            var emptyArray = new int[0];
            var shortArray = new int[] { 0 };

            Assert.Throws<ArgumentOutOfRangeException>
                (() => Counting.SumMinimalArrayNumbers(emptyArray));
            Assert.Throws<ArgumentOutOfRangeException>
                (() => Counting.SumMinimalArrayNumbers(shortArray));
            Assert.Throws<ArgumentNullException>
                (() => Counting.SumMinimalArrayNumbers(null!));
        }


        [Theory]
        [InlineData(new int[] { 4, 0, 3, 19, 492, -10, 1 })]
        public void TestExamlpe(int[] array)
        {
            Assert.Equal(-10, Counting.SumMinimalArrayNumbers(array));
        }

        [Theory]
        [InlineData(int.MinValue, 100_000_000)]
        public void TestBigSequence(int min, int count)
        {
            IEnumerable<int> testData = Enumerable.Range(min, count);

            long expected = min + (long)min + 1;
            long actual = Counting.SumMinimalArrayNumbers(testData.ToArray<int>()!);

            Assert.Equal(expected, actual);
        }
    }
}
