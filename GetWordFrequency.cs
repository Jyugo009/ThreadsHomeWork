using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsHomeWork
{
    public class GetWordFrequency : MultiThreadingProcessor<string>
    {
        private readonly Dictionary<string, int> _frequencyDictionary = new Dictionary<string, int>();
        private readonly object _lockObj = new object();

        public GetWordFrequency(int threadsCount, string[] array) : base(threadsCount, array)
        {
        }

        protected override string ProcessValue(int threadIndex, int itemIndex, Span<string> span)
        {
            string word = span[itemIndex].ToLower();

            lock (_lockObj)
            {
                if (!_frequencyDictionary.ContainsKey(word))
                    _frequencyDictionary[word] = 0;

                _frequencyDictionary[word]++;
            }

            return word;
        }

        public Dictionary<string, int> GetFrequency()
        {
            return _frequencyDictionary;
        }
    }
}
