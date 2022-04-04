using Microsoft.VisualStudio.TestTools.UnitTesting;
using Counter;
namespace CounterTests
{
    [TestClass]
    public class SampleTests
    {
        [TestMethod]
        public void SampleTest1()
        {
            Program instance = new Program();
            instance.ParseInput("It was many and many a year ago");            
            Assert.AreEqual("I0t w1s m2y a1d m2y a y2r a1o", instance.Result);
        }

        [TestMethod]
        public void SampleTest2()
        {
            Program instance = new Program();
            instance.ParseInput("Copyright,Microsoft:Corporation");
            Assert.AreEqual("C7t,M6t:C6n", instance.Result);
        }

    }

    [TestClass]
    public class EdgeCases
    {
        [TestMethod]
        public void EdgeCase1()  //  Last character is not a letter
        {
            Program instance = new Program();
            instance.ParseInput("Hello World!");
            Assert.AreEqual("H2o W3d!", instance.Result);
        }

        [TestMethod]
        public void EdgeCase2()  // symbols separating single letters
        {
            Program instance = new Program();
            instance.ParseInput("!a@b#c$");
            Assert.AreEqual("!a@b#c$", instance.Result);
        }

        [TestMethod]
        public void EdgeCase3()  //  Letters, symbols, and numbers.
        {
            Program instance = new Program();
            instance.ParseInput("!abc@def#123");
            Assert.AreEqual("!a1c@d1f#123", instance.Result);
        }

        [TestMethod]
        public void EdgeCase4()  //  Thoroughly mixed symbols of all three types (numeric, special, alphabetic).
        {
            Program instance = new Program();
            instance.ParseInput("njr@cox abc123def4ghi5!");
            Assert.AreEqual("n1r@c1x a1c123d1f4g1i5!", instance.Result);
        }

    }
}
