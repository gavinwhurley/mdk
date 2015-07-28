using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdk.Domain
{
    // this is the interface that defines the logical operations that can be performed on the object.  
    //  I like to thing this is a CQRS style interface, but since there's only two methods, it's a bit
    //  of a stretch to give myself credit for that.  
    public interface ICandidateService
    {
        void Train(string passage);

        List<Candidate> GetCandidates(string word);

    }
}
