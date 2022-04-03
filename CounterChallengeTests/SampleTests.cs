using Microsoft.VisualStudio.TestTools.UnitTesting;
using CounterChallenge;
namespace CounterChallengeTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void SampleTest1()
        {
            Program instance = new Program();
            instance.ParseInput("It was many and many a year ago");            
            Assert.AreEqual("I0t w1s m2y a1d m2y a y2r a1o", instance.getResult());
        }

        [TestMethod]
        public void SampleTest2()
        {
            Program instance = new Program();
            instance.ParseInput("Copyright,Microsoft:Corporation");
            Assert.AreEqual("C7t,M6t:C6n", instance.getResult());
        }
    }
}
