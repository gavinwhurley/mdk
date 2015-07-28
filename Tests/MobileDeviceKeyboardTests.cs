using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mdk.Domain;
using Mdk.Infrastructure;
using Moq;

namespace Mdk.Tests
{
    [TestClass]
    public class MobileDeviceKeyboardTests
    {
        [TestMethod]
        public void TestEverything()
        {
            // it's important to note here that I've done a Bad Thing.  I should 
            //  be using the Mock library to make a fake version of the data store 
            //  class, based on it's interface.  But in the interest of time, I just 
            //  used the data store so I could get the project finished.  

            //var storage = new Mock<IDataStore>();
            //var service = new CandidateService(storage.Object);

            var service = new CandidateService(new DataStore());

            service.Train("When Wilson wins he whistles without wonder.");

            var candidates = service.GetCandidates("W");
            Assert.IsTrue(candidates.Count == 6);

            candidates = service.GetCandidates("Wh");
            Assert.IsTrue(candidates.Count == 2);

            service.Train("Whereas when Wilson wonders why, Wilson hesitates.");

            candidates = service.GetCandidates("Wh");
            Assert.IsTrue(candidates.Count == 4);
            var candidate = candidates.Find(c => c.Word.Equals("when"));
            Assert.IsTrue(candidate.Confidence == 2);
            

        }
    }
}
