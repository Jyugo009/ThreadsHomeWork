using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public class MinInArray<T> : MultiThreadingProcessor<T> where T : IComparable
    {
        private T _minValue;
        private readonly object _lockObj = new object();

        public T Min => _minValue;

        public MinInArray(int threadsCount, T[] array)
            : base(threadsCount, array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Array cannot be empty.", nameof(array));

            _minValue = array[0];
        }

        protected override T ProcessValue(int threadIndex, int itemIndex, Span<T> span)
        {
            var localMin = span[itemIndex];

            lock (_lockObj)
            {
                if (localMin.CompareTo(_minValue) < 0)
                    _minValue = localMin;
            }

            return localMin;
        }


    }
}
