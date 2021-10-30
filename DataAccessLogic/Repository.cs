using System.Collections.Generic;
using System.Linq;
using System;
using Entity = DataAccessLogic.Entity;
using Model = Models;
using DataAccessLogic.Entity;

namespace DataAccessLogic
{
    public class Repository : IRepository
    {
        private Entity.revaturedatabaseContext _context;
        public Repository(Entity.revaturedatabaseContext p_context)
        {
            _context = p_context;
        }
        









        // Useful Methods in Repository: Add, Update, Delete, Get, GetAll

        // Method AddClass: Class parameter. Overloaded 5 times. Used to add a new Class to the database.
        public Model.Customer Add(Model.Customer p_IC){ 
            var p = new Entity.Customer(){
                Name = p_IC.Name,
                Address = p_IC.Address,
                Email = p_IC.Email,
                Phone = p_IC.Phone,
                Picture = p_IC.Picture
                };
            _context.Add(p);
            _context.SaveChanges();
            return Get(Translate(p));
        }
        public Model.Storefront Add(Model.Storefront p_IC){
            var p = new Entity.Storefront(){
                Name = p_IC.Name,
                Address = p_IC.Address,
                };
            _context.Add(p);
            _context.SaveChanges();
            return Get(Translate(p));
        }
        public Model.Order Add(Model.Order p_IC){
            var p = new Entity.Order(){
                Location = p_IC.Location,
                }; 
            _context.SaveChanges();
            return Get(Translate(p));
        }
        public Model.LineItem Add(Model.LineItem p_IC){
            var p = new Entity.LineItem(){
                ProductId = p_IC.ProductId,
                Quantity = p_IC.Quantity,
                };
            _context.Add(p);
            _context.SaveChanges();
            return Get(Translate(p));
        }

        public Model.Product Add(Model.Product p_IC){
            var p = new Entity.Product(){
                    Name = p_IC.Name,
                    Description = p_IC.Description,
                    Category = p_IC.Category,
                    Price = p_IC.Price
                };
            _context.Add(p);
            _context.SaveChanges();
            return Get(Translate(p));
        }











        // Method Delete: Class parameter. Overloaded 5 times. Used to delete a Class from the database.
        public void Delete(Model.Customer p_IC){
            var entity = _context.Customers.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.Customers.Remove(entity);
            foreach(var order in p_IC.CustomerOrders){
                Delete(order);
            }
            _context.SaveChanges();
        }
        public void Delete(Model.Storefront p_IC){
            var entity = _context.Storefronts.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.Storefronts.Remove(entity);
            foreach(var order in p_IC.StoreOrders){
                Delete(order);
            }
            foreach(var lineitem in p_IC.StoreLineItems){
                Delete(lineitem);
            }
            _context.SaveChanges();
        }
        public void Delete(Model.Order p_IC){
            var entity = _context.Orders.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.Orders.Remove(entity);
            foreach(var lineitem in p_IC.OrderLineItems){
                Delete(lineitem);
            }
            _context.SaveChanges();
        }
        public void Delete(Model.LineItem p_IC){
            var entity = _context.LineItems.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.LineItems.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Model.Product p_IC){
            var entity = _context.Products.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }






        //Method GetAllClasses: Class parameter. Overloaded 5 times. Uses Linq to grab all classes from the database.
        public List<Model.Customer> GetAll(Model.Customer p_IC){
            return _context.Customers.Select(IC =>
                new Model.Customer(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Email = IC.Email,
                    Phone = IC.Phone,
                    Address = IC.Address,
                    Picture = IC.Picture,
                    CustomerOrders = _context.Orders.Where(x => x.Id == _context.CustomerOrders.Where(y => y.CustomerId == IC.Id).Select(z => z.OrdersId).FirstOrDefault()).Select(x => new Model.Order(){
                        Id = x.Id,
                        Location = x.Location,
                        OrderLineItems = _context.LineItems.Where(y => y.Id == _context.OrdersLineitems.Where(z => z.OrdersId == x.Id).Select(a => a.LineItemId).FirstOrDefault()).Select(y => new Model.LineItem(){
                            Id = y.Id,
                            Quantity = y.Quantity,
                            ProductId = y.ProductId,
                            LineProduct = _context.Products.Where(z => z.Id == y.ProductId).Select(a => new Model.Product(){
                                Id = a.Id,
                                Name = a.Name,
                                Description = a.Description,
                                Price = (decimal)a.Price,
                                Category = a.Category
                                }).FirstOrDefault()
                            }).ToList()
                        }).ToList()
                    }).ToList();
        }
        public List<Model.Storefront> GetAll(Model.Storefront p_IC){
            return _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Address = IC.Address,
                }).ToList();
        }
        public List<Model.Order> GetAll(Model.Order p_IC){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Id = IC.Id,
                    Location = IC.Location,
                }).ToList();
        }
        public List<Model.LineItem> GetAll(Model.LineItem p_IC){
            return _context.LineItems.Select(IC =>
                new Model.LineItem(){
                    Id = IC.Id,
                    Quantity = IC.Quantity,
                }).ToList();
        }
        public List<Model.Product> GetAll(Model.Product p_IC){
            return _context.Products.Select(IC =>
                new Model.Product(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Description = IC.Description,
                    Category = IC.Category,
                    Price = (decimal)IC.Price,
                }).ToList();
        }









        // Maybe the Get can use GetAll? Search the returned List for the Id and return the object?


        // Method Get. 
        // Matches ID to an entry in the database. Grabs all info from the database and returns it as a class. 
        // Can either send a Model or Entity and will return Model.
        public Model.Customer Get(Model.Customer p_IC){
            return _context.Customers.Select(IC =>
                new Model.Customer(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Email = IC.Email,
                    Phone = IC.Phone,
                    Address = IC.Address,
                    Picture = IC.Picture,
                    CustomerOrders = _context.Orders.Where(x => x.Id == _context.CustomerOrders.Where(y => y.CustomerId == IC.Id).Select(z => z.OrdersId).FirstOrDefault()).Select(x => new Model.Order(){
                        Id = x.Id,
                        Location = x.Location,
                        OrderLineItems = _context.LineItems.Where(y => y.Id == _context.OrdersLineitems.Where(z => z.OrdersId == x.Id).Select(a => a.LineItemId).FirstOrDefault()).Select(y => new Model.LineItem(){
                            Id = y.Id,
                            Quantity = y.Quantity,
                            ProductId = y.ProductId,
                            LineProduct = _context.Products.Where(z => z.Id == y.ProductId).Select(a => new Model.Product(){
                                Id = a.Id,
                                Name = a.Name,
                                Description = a.Description,
                                Price = (decimal)a.Price,
                                Category = a.Category
                                }).FirstOrDefault()
                            }).ToList()
                        }).ToList()
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.Storefront Get(Model.Storefront p_IC){
            return _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Address = IC.Address,
                    StoreLineItems = _context.LineItems.Where(x => x.Id == _context.Inventories.Where(y => y.StorefrontId == IC.Id).Select(z => z.LineitemId).FirstOrDefault()).Select(x => new Model.LineItem(){
                        Id = x.Id,
                        Quantity = x.Quantity,
                        ProductId = x.ProductId,
                        LineProduct = _context.Products.Where(y => y.Id == x.ProductId).Select(a => new Model.Product(){
                            Id = a.Id,
                            Name = a.Name,
                            Description = a.Description,
                            Price = (decimal)a.Price,
                            Category = a.Category
                            }).FirstOrDefault()
                        }).ToList(),
                    StoreOrders = _context.Orders.Where(x => x.Id == _context.StorefrontOrders.Where(y => y.StorefrontId == IC.Id).Select(z => z.OrdersId).FirstOrDefault()).Select(x => new Model.Order(){
                        Id = x.Id,
                        Location = x.Location,
                        OrderLineItems = _context.LineItems.Where(y => y.Id == _context.OrdersLineitems.Where(z => z.OrdersId == x.Id).Select(a => a.LineItemId).FirstOrDefault()).Select(y => new Model.LineItem(){
                            Id = y.Id,
                            Quantity = y.Quantity,
                            ProductId = y.ProductId,
                            LineProduct = _context.Products.Where(z => z.Id == y.ProductId).Select(a => new Model.Product(){
                                Id = a.Id,
                                Name = a.Name,
                                Description = a.Description,
                                Price = (decimal)a.Price,
                                Category = a.Category
                                }).FirstOrDefault()
                            }).ToList()
                        }).ToList()
                    

                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.Order Get(Model.Order p_IC){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Id = IC.Id,
                    Location = IC.Location,
                    OrderLineItems = _context.LineItems.Where(y => y.Id == _context.OrdersLineitems.Where(z => z.OrdersId == IC.Id).Select(a => a.LineItemId).FirstOrDefault()).Select(y => new Model.LineItem(){
                        Id = y.Id,
                        Quantity = y.Quantity,
                        ProductId = y.ProductId,
                        LineProduct = _context.Products.Where(z => z.Id == y.ProductId).Select(a => new Model.Product(){
                            Id = a.Id,
                            Name = a.Name,
                            Description = a.Description,
                            Price = (decimal)a.Price,
                            Category = a.Category
                            }).FirstOrDefault()
                        }).ToList()
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.LineItem Get(Model.LineItem p_IC){
            return _context.LineItems.Select(IC =>
                new Model.LineItem(){
                    Id = IC.Id,
                    Quantity = IC.Quantity,
                    ProductId = IC.ProductId,
                    LineProduct = _context.Products.Where(z => z.Id == IC.ProductId).Select(a => new Model.Product(){
                        Id = a.Id,
                        Name = a.Name,
                        Description = a.Description,
                        Price = (decimal)a.Price,
                        Category = a.Category
                        }).FirstOrDefault()
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.Product Get(Model.Product p_IC){
            return _context.Products.Select(IC =>
                new Model.Product(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Description = IC.Description,
                    Category = IC.Category,
                    Price = (decimal)IC.Price,
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }








        public Model.Customer Translate(Entity.Customer p_IC){
            return new Model.Customer(){
                    Id = p_IC.Id,
                    Name = p_IC.Name,
                    Email = p_IC.Email,
                    Phone = p_IC.Phone,
                    Address = p_IC.Address,
                    Picture = p_IC.Picture,
                   // CustomerOrders = p_IC.CustomerOrders,
                };
                
        }
        public Model.Storefront Translate(Entity.Storefront p_IC){
            return new Model.Storefront(){
                    Id = p_IC.Id,
                    Name = p_IC.Name,
                    Address = p_IC.Address,
                };
                
        }
        public Model.Order Translate(Entity.Order p_IC){
            return new Model.Order(){
                    Id = p_IC.Id,
                    Location = p_IC.Location,
                   // OrderLineItems = p_IC.OrderLineItems,
                };
                
        }
        public Model.LineItem Translate(Entity.LineItem p_IC){
            return new Model.LineItem(){
                    Id = p_IC.Id,
                    Quantity = p_IC.Quantity,
                    ProductId = p_IC.ProductId,
                    //LineProduct = p_IC.LineProduct,
                };
                
        }
        public Model.Product Translate(Entity.Product p_IC){
            return new Model.Product(){
                    Id = p_IC.Id,
                    Name = p_IC.Name,
                    Description = p_IC.Description,
                    Category = p_IC.Category,
                    Price = (decimal)p_IC.Price,
                };
                
        }
        





        // Method UpdateClass: Class parameter. Overloaded 5 times. Used to update a class in the database.
        public void Update(Model.Customer p_IC){
            var entity = _context.Customers.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Name = p_IC.Name;
            entity.Email = p_IC.Email;
            entity.Phone = p_IC.Phone;
            entity.Address = p_IC.Address;
            entity.Picture = p_IC.Picture; 
            foreach(var order in p_IC.CustomerOrders){
                entity.CustomerOrders.Add(
                    new CustomerOrder(){
                    CustomerId = p_IC.Id,
                    OrdersId = order.Id,
                });
            }
            _context.SaveChanges();
        }
        public void Update(Model.Storefront p_IC){
            var entity = _context.Storefronts.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Name = p_IC.Name;
            entity.Address = p_IC.Address;
            foreach(var lineitem in p_IC.StoreLineItems){
                entity.Inventories.Add(
                    new Inventory(){
                        StorefrontId = p_IC.Id,
                        LineitemId = lineitem.Id,
                    });
            }
            foreach(var order in p_IC.StoreOrders){
                entity.StorefrontOrders.Add(
                    new StorefrontOrder(){
                        StorefrontId = p_IC.Id,
                        OrdersId = order.Id,
                    });
                
            }
            _context.SaveChanges();
        }
        public void Update(Model.Order p_IC){
            var entity = _context.Orders.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Location = p_IC.Location;

            foreach(var lineitem in p_IC.OrderLineItems){
                entity.OrdersLineitems.Add(
                    new OrdersLineitem(){
                        OrdersId = p_IC.Id,
                        LineItemId = lineitem.Id,
                    });
            }
            _context.SaveChanges();
        }
        public void Update(Model.LineItem p_IC){
            var entity = _context.LineItems.FirstOrDefault(x => x.Id == p_IC.Id); //The M.Lineitem still doesn't have an ID after adding it to the database.
            entity.Quantity = p_IC.Quantity;
            entity.ProductId = p_IC.ProductId;
            _context.SaveChanges();
        }
        public void Update(Model.Product p_IC){
            var entity = _context.Products.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Name = p_IC.Name;
            entity.Description = p_IC.Description;
            entity.Category = p_IC.Category;
            entity.Price = p_IC.Price;
            _context.SaveChanges();
        }









        // Method Search: Class parameter. Overloaded 5 times. Used to search the database and return all classes that match the search criteria.
        public List<Model.Customer> Search(Model.Customer p_IC, string p_Search){
            return _context.Customers.Select(IC =>
                new Model.Customer(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Email = IC.Email,
                    Phone = IC.Phone,
                    Address = IC.Address,
                    Picture = IC.Picture,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Email.Contains(p_Search) || IC.Phone.Contains(p_Search) || IC.Address.Contains(p_Search)).ToList();
        }
        public List<Model.Storefront> Search(Model.Storefront p_IC, string p_Search){
            return _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Address = IC.Address,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Address.Contains(p_Search)).ToList(); 
        }
        public List<Model.Order> Search(Model.Order p_IC, string p_search){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Id = IC.Id,
                    Location = IC.Location,
                }).Where(IC => IC.Location.Contains(p_search)).ToList();
        }
        public List<Model.LineItem> Search(Model.LineItem p_IC, string p_Search){
            return _context.LineItems.Select(IC =>
                new Model.LineItem(){
                    Id = IC.Id,
                    Quantity = IC.Quantity,
                }).Where(IC => IC.Quantity.ToString().Contains(p_Search) || IC.LineProduct.Name.Contains(p_Search) || IC.LineProduct.Description.Contains(p_Search)|| IC.LineProduct.Category.Contains(p_Search)).ToList();
        }
        public List<Model.Product> Search(Model.Product p_IC, string p_Search){
            return _context.Products.Select(IC =>
                new Model.Product(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Description = IC.Description,
                    Category = IC.Category,
                    Price = (decimal)IC.Price,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Description.Contains(p_Search) || IC.Category.Contains(p_Search) || IC.Price.ToString().Contains(p_Search)).ToList();
        }
















































    }
}