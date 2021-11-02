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
            Entity.Order entity = new Entity.Order(){
                Id = 101,
                Location = "Test Location",
                Active = true,
                OrderLineItems = new List<Entity.OrderLineItem>(){
                    new Entity.OrderLineItem(){
                        Id = 1,
                        ProductId = 1,
                        Quantity = 1,
                        UnitPrice = 1.00m,
                        LineProduct = new Entity.Product(){
                            Id = 1,
                            Name = "Test Product",
                            Description = "Test Description",
                            Price = 1.00m
                        }
                    },
                    new Entity.OrderLineItem(){
                        Id = 2,
                        ProductId = 2,
                        Quantity = 2,
                        UnitPrice = 2.00m,
                        LineProduct = new Entity.Product(){
                            Id = 2,
                            Name = "Test Product 2",
                            Description = "Test Description 2",
                            Price = 2.00m
                        }
                    },
                    new Entity.OrderLineItem(){
                        Id = 3,
                        ProductId = 3,
                        Quantity = 3,
                        UnitPrice = 3.00m,
                        LineProduct = new Entity.Product(){
                            Id = 3,
                            Name = "Test Product 3",
                            Description = "Test Description 3",
                            Price = 3.00m
                        }
                    }
                }  
            };

            Model.Order model = repo.Translate(entity, entity.OrderLineItems, entity.OrderLineItems.LineProduct);

            Assert.AreEqual(entity.Id, model.Id);
            Assert.AreEqual(entity.Location, model.Location);
            Assert.AreEqual(entity.Active, model.Active);
            Assert.AreEqual(entity.OrderLineItems.Count, model.OrderLineItems.Count);
            Assert.AreEqual(entity.OrderLineItems[0].Id, model.OrderLineItems[0].Id);
            Assert.AreEqual(entity.OrderLineItems[0].ProductId, model.OrderLineItems[0].ProductId);
            Assert.AreEqual(entity.OrderLineItems[0].Quantity, model.OrderLineItems[0].Quantity);
            Assert.AreEqual(entity.OrderLineItems[0].UnitPrice, model.OrderLineItems[0].UnitPrice);
            Assert.AreEqual(entity.OrderLineItems[0].LineProduct.Id, model.OrderLineItems[0].Product.Id);
            Assert.AreEqual(entity.OrderLineItems[0].LineProduct.Name, model.OrderLineItems[0].Product.Name);
            Assert.AreEqual(entity.OrderLineItems[0].LineProduct.Description, model.OrderLineItems[0].Product.Description);
            Assert.AreEqual(entity.OrderLineItems[0].LineProduct.Price, model.OrderLineItems[0].Product.Price);
            Assert.AreEqual(entity.OrderLineItems[1].Id, model.OrderLineItems[1].Id);
            Assert.AreEqual(entity.OrderLineItems[1].ProductId, model.OrderLineItems[1].ProductId);
            Assert.AreEqual(entity.OrderLineItems[1].Quantity, model.OrderLineItems[1].Quantity);
            Assert.AreEqual(entity.OrderLineItems[1].UnitPrice, model.OrderLineItems[1].UnitPrice);
            Assert.AreEqual(entity.OrderLineItems[1].LineProduct.Id, model.OrderLineItems[1].Product.Id);
            Assert.AreEqual(entity.OrderLineItems[1].LineProduct.Name, model.OrderLineItems[1].Product.Name);
            Assert.AreEqual(entity.OrderLineItems[1].LineProduct.Description, model.OrderLineItems[1].Product.Description);
            Assert.AreEqual(entity.OrderLineItems[1].LineProduct.Price, model.OrderLineItems[1].Product.Price);
            Assert.AreEqual(entity.OrderLineItems[2].Id, model.OrderLineItems[2].Id);
            Assert.AreEqual(entity.OrderLineItems[2].ProductId, model.OrderLineItems[2].ProductId);
            Assert.AreEqual(entity.OrderLineItems[2].Quantity, model.OrderLineItems[2].Quantity);
            Assert.AreEqual(entity.OrderLineItems[2].UnitPrice, model.OrderLineItems[2].UnitPrice);
            Assert.AreEqual(entity.OrderLineItems[2].LineProduct.Id, model.OrderLineItems[2].Product.Id);
            Assert.AreEqual(entity.OrderLineItems[2].LineProduct.Name, model.OrderLineItems[2].Product.Name);
            Assert.AreEqual(entity.OrderLineItems[2].LineProduct.Description, model.OrderLineItems[2].Product.Description);
            Assert.AreEqual(entity.OrderLineItems[2].LineProduct.Price, model.OrderLineItems[2].Product.Price);

        }
    }
}