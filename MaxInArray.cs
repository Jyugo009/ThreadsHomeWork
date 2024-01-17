using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public class MaxInArray<T> : MultiThreadingProcessor<T> where T : IComparable
    {
        private T _maxValue;
        private readonly object _lockObj = new object();

        public T Max => _maxValue;

        public MaxInArray(int threadsCount, T[] array)
            : base(threadsCount, array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array cannot be empty.", nameof(array));

            _maxValue = array[0];
        }

        protected override T ProcessValue(int threadIndex, int itemIndex, Span<T> span)
        {
            var localMax = span[itemIndex];

            lock (_lockObj)
            {
                if (localMax.CompareTo(_maxValue) > 0)
                    _maxValue = localMax;
            }

            return localMax;
        }
    }
}
