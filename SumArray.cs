using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public class SumArray : MultiThreadingProcessor<int>
    {
        private int _totalSum;

        public int TotalSum => _totalSum;

        public SumArray(int threadsCount, int[] array)
            : base(threadsCount, array) { }

        protected override int ProcessValue(int threadIndex, int itemIndex, Span<int> span)
        {
            Interlocked.Add(ref _totalSum, span[itemIndex]);

            return span[itemIndex];
        }        
    }
}
