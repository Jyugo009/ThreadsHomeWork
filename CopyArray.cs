using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public class ArrayCopy<T> : MultiThreadingProcessor<T>
    {
        private T[] _destinctArray;

        public ArrayCopy(int threadsCount, T[] sourceArray)
            : base(threadsCount, sourceArray)
        {
            _destinctArray = new T[sourceArray.Length];
        }

        protected override T ProcessValue(int threadIndex, int itemIndex, Span<T> span)
        {
            var index = threadIndex * span.Length + itemIndex;

            if (index < _destinctArray.Length)
            {
                _destinctArray[index] = span[itemIndex];
            }

            return span[itemIndex];
        }

        public T[] GetCopiedArray()
        {
            return _destinctArray;
        }
    }
}
