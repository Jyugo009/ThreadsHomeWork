using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public abstract class MultiThreadingProcessor<T>
    {
        protected readonly Thread[] _threads;
        protected readonly T[] _array;

        public MultiThreadingProcessor(int threadsCount, T[] array)
        {
            _threads = new Thread[threadsCount];
            _array = array;
        }

        public virtual void Process()
        {
            for (int i = 0; i < _threads.Length; i++)
            {
                _threads[i] = new Thread(ThreadProc) { IsBackground = true };
                _threads[i].Start(i);
            }

            foreach (var thread in _threads)
            {
                thread.Join();
            }
        }

        private void ThreadProc(object state)
        {
            var lenght = _threads.Length;
            var index = (int)state!;
            var count = _array.Length / lenght;

            var span = index == lenght - 1
                ? _array.AsSpan((index * count)..)
                : _array.AsSpan((index * count)..((index * count) + count));

            for (var i = 0; i < span.Length; i++)
            {
                ProcessValue(index, i, span);
            }
        }

        protected abstract T ProcessValue(int threadIndex, int itemIndex, Span<T> span);
    }
}
