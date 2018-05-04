using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crystal
{
    public class FrequencyAnalysis : IEnumerable<KeyValuePair<char, int>>
    {
        private string originalText;

        private SortedDictionary<char, int> Letters;

        public FrequencyAnalysis() { }

        public FrequencyAnalysis(string array)
        {
            originalText = array;
        }

        public void Analise ()
        {
            Letters = new SortedDictionary<char, int>();

            foreach (char c in originalText)
            {
                if (Letters.ContainsKey(c))
                {
                    Letters[c]++;
                }
                else
                {
                    Letters.Add(c, 1);
                }
            }
        }

        public int Count
        {
            get { return Letters.Count; }
        }

        public IEnumerator<KeyValuePair<char, int>> GetEnumerator()
        {
            return Letters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
