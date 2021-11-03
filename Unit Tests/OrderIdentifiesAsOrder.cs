using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests{
    [TestClass]
    public class OrderIdentifiesAsOrder{
        [TestMethod]
        public void Order_Equals_Order(){
            Order order = new Order();
            Assert.AreEqual(order.Identify(), "Order");
        }
    }
}