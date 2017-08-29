using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstVogel;

namespace UnitTestFindVogel
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestVogelValid()
        {
            StringStream stream = new StringStream("aAbBABacfe");
            SearchVogel searchVogel = new SearchVogel();

            char result;

            try
            {
                result = searchVogel.FirstChar(stream);
            }
            catch (Exception)
            {
                result = ' ';
            }

            Assert.IsTrue(result != ' ');
        }

        [TestMethod]
        public void TestVogelInvalid()
        {
            StringStream stream = new StringStream("aaaaaaaaa");
            SearchVogel searchVogel = new SearchVogel();

            char result;

            try
            {
                result = searchVogel.FirstChar(stream);
            }
            catch (Exception)
            {
                result = ' ';
            }

            Assert.IsTrue(result == ' ');
        }
    }
}
