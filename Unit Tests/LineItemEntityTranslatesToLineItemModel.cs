namespace UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    using Model = Models;
    using Entity = DataAccessLogic.Entity;

    [TestFixture]
    public class UnitTest2
    {
        [Test]
        var repo = new DataAccessLogic.Repository();
        public ProductEntityTranslatesToProductModel()
        {
            Entity.LineItem entity = new Entity.LineItem(){
                Id = 101,
                Quantity = 10,
                ProductId = 11,
                Product = new Entity.Product()
                {
                    Id = 11,
                    Name = "Test",
                    Description = "Test",
                    Category = "Test",
                    Price = 1.11m,
                }
                
            };
            Model.LineItem model = repo.Translate(entity, entity.Product);

            Assert.AreEqual(entity.Id, model.Id);
            Assert.AreEqual(entity.Quantity, model.Quantity);
            Assert.AreEqual(entity.ProductId, model.ProductId);
            Assert.AreEqual(entity.Product.Id, model.ProductId);
            Assert.AreEqual(entity.Product.Id, model.Product.Id);
            Assert.AreEqual(entity.Product.Name, model.Product.Name);
            Assert.AreEqual(entity.Product.Description, model.Product.Description);
            Assert.AreEqual(entity.Product.Category, model.Product.Category);
            Assert.AreEqual(entity.Product.Price, model.Product.Price);

        }
    }
}