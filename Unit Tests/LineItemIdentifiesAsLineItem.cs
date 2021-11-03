using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests{
    [TestClass]
    public class LineItemIdentifiesAsLineItem{
        [TestMethod]
        public void LineItem_Equals_LineItem(){
            LineItem LineItem = new LineItem();
            Assert.AreEqual(LineItem.Identify(), "LineItem");
        }
    }
}