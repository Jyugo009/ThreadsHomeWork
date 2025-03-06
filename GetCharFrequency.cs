using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public class GetCharFrequency : MultiThreadingProcessor<char>
    {
        private Dictionary<char, int> _frequencyDictionary;

        public GetCharFrequency(int threadsCount, char[] array) : base(threadsCount, array)
        {
            _frequencyDictionary = new Dictionary<char, int>();
        }

        protected override char ProcessValue(int threadIndex, int itemIndex, Span<char> span)
        {
            lock (_frequencyDictionary)
            {
                if (!_frequencyDictionary.ContainsKey(span[itemIndex]))
                    _frequencyDictionary[span[itemIndex]] = 0;

                _frequencyDictionary[span[itemIndex]]++;
            }

            return span[itemIndex];
        }

        public Dictionary<char, int> GetFrequency()
        {
            return _frequencyDictionary;
        }
    }
}
