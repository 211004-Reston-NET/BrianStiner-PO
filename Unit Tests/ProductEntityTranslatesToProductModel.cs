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
            Entity.Product entity = new Entity.Product(){
                Id = 101,
                Name = "Test",
                Description = "Test",
                Category = "Test",
                Price = 1.11m,
            };
            Model.Product model = repo.Translate(entity);

            Assert.AreEqual(entity.Id, model.Id);
            Assert.AreEqual(entity.Name, model.Name);
            Assert.AreEqual(entity.Description, model.Description);
            Assert.AreEqual(entity.Category, model.Category);
            Assert.AreEqual(entity.Price, model.Price);

        }
    }
}