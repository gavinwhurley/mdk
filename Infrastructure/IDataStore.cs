using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdk.Infrastructure
{
    // this interface defines the operations that the business class can perform to the data store.  As long as the 
    //  replacement data store uses this same interface, it can replace the existing one by simply wiring it up to 
    //  the new class.
    public interface IDataStore
    {
        void StoreWord(string word);

        IEnumerable<KeyValuePair<string, int>> FetchWords();
    }
}