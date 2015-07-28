using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdk.Infrastructure
{
    // this is my poor man's database, a simple in-memory dictionary of words and counts.  
    public class DataStore : IDataStore
    {
        private Dictionary<string, int> _words;

        public DataStore()
        {
            _words = new Dictionary<string, int>();
        }

        public IEnumerable<KeyValuePair<string, int>> FetchWords()
        {
            return _words;
        }

        public void StoreWord(string word)
        {
            if (_words.ContainsKey(word))
            {
                _words[word]++;
            }
            else
            {
                _words.Add(word, 1);
            }
        }
    }
}
