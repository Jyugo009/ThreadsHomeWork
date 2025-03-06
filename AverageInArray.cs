using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public class AverageInArray : MultiThreadingProcessor<int>
    {
        private double _sum;
        private object _lock = new object();

        public AverageInArray(int threadsCount, int[] array)
            : base(threadsCount, array)
        {
        }

        protected override int ProcessValue(int threadIndex, int itemIndex, Span<int> span)
        {
            lock (_lock)
            {
                _sum += span[itemIndex];
            }
            return span[itemIndex];
        }

        public double GetAverage()
        {
            Process();
            return _sum / (_array.Length);
        }
    }
}
