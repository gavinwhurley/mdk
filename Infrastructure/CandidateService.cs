using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mdk.Domain;

namespace Mdk.Infrastructure
{
    public class CandidateService : ICandidateService
    {
        private IDataStore _store;

        public CandidateService(IDataStore store)
        {
            _store = store;
        }

        public List<Candidate> GetCandidates(string word)
        {
            var candidates = new List<Candidate>();
            var matches = _store.FetchWords().OrderBy(w => w.Value);

            foreach (var match in matches.Where(m => m.Key.ToLower().StartsWith(word.ToLower())))
            {
                candidates.Add(new Candidate { Word = match.Key, Confidence = match.Value });
            }

            return candidates;
        }

        public void Train(string passage)
        {
            var words = passage.Split(' ');
            foreach (var word in words)
            {
                var scrubbed = Scrub(word.ToLower());
                _store.StoreWord(scrubbed);
            }
        }

        private string Scrub(string word)
        {
            var scrubbed = new string(word.ToCharArray().Where(c => !char.IsPunctuation(c)).ToArray());
            return scrubbed;
        }
    }
}
