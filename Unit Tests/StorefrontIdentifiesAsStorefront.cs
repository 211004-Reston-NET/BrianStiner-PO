using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests{
    [TestClass]
    public class StorefrontIdentifiesAsStorefront{
        [TestMethod]
        public void Storefront_Equals_Storefront(){
            Storefront store = new Storefront();
            Assert.AreEqual(store.Identify(), "Storefront");
        }
    }
}