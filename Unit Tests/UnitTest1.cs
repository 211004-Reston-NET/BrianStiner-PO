using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void one_equals_one_true()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
