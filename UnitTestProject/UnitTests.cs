using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PracticeTask4.Program;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Complex[] coefs = new Complex[2];
            coefs[0] = new Complex(-2, -2);
            coefs[1] = new Complex(-2, -2);
            string check = "-2 - 2i";
            Assert.AreEqual(Gorner(coefs).ToString(), check);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Complex[] coefs = new Complex[4];
            coefs[0] = new Complex(3, 4);
            coefs[1] = new Complex(1, 2);
            coefs[2] = new Complex(3, 4);
            coefs[3] = new Complex(5, 6);
            string check = "-185 + 104i";
            Assert.AreEqual(Gorner(coefs).ToString(), check);
        }
    }
}