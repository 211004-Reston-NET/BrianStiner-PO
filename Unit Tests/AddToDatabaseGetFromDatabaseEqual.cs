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
    public class UnitTest2{
        [Test]
        var repo = new DataAccessLogic.Repository();
        public AddToDatabaseGetFromDatabaseAreTheSame(){
            
            Model.Product model = new Model.Product(){
                Name = "Test",
                Description = "Test",
                Category = "Test",
                Price = 1.11m,
            };
            var model1 = repo.Add(model);
            var model2 = repo.Get(model1);

            Assert.AreEqual(model1.Id, model2.Id);
            Assert.AreEqual(model1.Name, model2.Name);
            Assert.AreEqual(model1.Description, model2.Description);
            Assert.AreEqual(model1.Category, model2.Category);
            Assert.AreEqual(model1.Price, model2.Price);
        }
    }
}