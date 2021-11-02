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
            var entity = new Entity.Customer(){
                Name = p_IC.Name,
                Address = p_IC.Address,
                Email = p_IC.Email,
                Phone = p_IC.Phone,
                Totalspent = p_IC.TotalSpent,
                Picture = p_IC.Picture
                };
            _context.Add(entity);
            _context.SaveChanges();

            foreach(var order in p_IC.CustomerOrders){
                entity.CustomerOrders.Add(
                    new CustomerOrder(){
                    CustomerId = entity.Id,
                    OrdersId = order.Id,
                });
            }
            _context.SaveChanges();
            p_IC.Id = entity.Id;
            return p_IC;
        }
        public Model.Storefront Add(Model.Storefront p_IC){
            var entity = new Entity.Storefront(){
                Name = p_IC.Name,
                Address = p_IC.Address,
                Expenses = p_IC.Expenses,
                Revenue = p_IC.Revenue,
                };
            _context.Add(entity);
            _context.SaveChanges();

            foreach(var lineitem in p_IC.StoreLineItems){
                entity.Inventories.Add(
                    new Inventory(){
                        StorefrontId = entity.Id,
                        LineitemId = lineitem.Id,
                    });
            }
            foreach(var order in p_IC.StoreOrders){
                entity.StorefrontOrders.Add(
                    new StorefrontOrder(){
                        StorefrontId = entity.Id,
                        OrdersId = order.Id,
                    });
                
            }
            _context.SaveChanges();
            p_IC.Id = entity.Id;
            return p_IC;
        }
        public Model.Order Add(Model.Order p_IC){
            var entity = new Entity.Order(){
                Location = p_IC.Location,
                Active = p_IC.Active,
                };
            _context.Add(entity);
            _context.SaveChanges();
            foreach(var lineitem in p_IC.OrderLineItems){
                entity.OrdersLineitems.Add(
                    new OrdersLineitem(){
                        OrdersId = entity.Id,
                        LineItemId = lineitem.Id,
                    });
            }
            _context.SaveChanges();
            p_IC.Id = entity.Id;
            return p_IC;
        }
        public Model.LineItem Add(Model.LineItem p_IC){
            var entity = new Entity.LineItem(){
                ProductId = p_IC.ProductId,
                Quantity = p_IC.Quantity,
                };
            _context.Add(entity);
            _context.SaveChanges();
            p_IC.Id = entity.Id;
            return p_IC;
        }

        public Model.Product Add(Model.Product p_IC){
            var entity = new Entity.Product(){
                    Name = p_IC.Name,
                    Description = p_IC.Description,
                    Category = p_IC.Category,
                    Price = p_IC.Price
                };
            _context.Add(entity);
            _context.SaveChanges();
            p_IC.Id = entity.Id;
            return p_IC;
        }











        // Method Delete: Class parameter. Overloaded 5 times. Used to delete a Class from the database.
        public void Delete(Model.Customer p_IC){
            var entity = _context.Customers.FirstOrDefault(x => x.Id == p_IC.Id);
            
            _context.CustomerOrders.RemoveRange(entity.CustomerOrders);
            var orders = _context.CustomerOrders.Where(x => x.CustomerId == p_IC.Id);
            foreach(var order in orders){
                _context.CustomerOrders.RemoveRange(order);
            }

            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Model.Storefront p_IC){
            var entity = _context.Storefronts.FirstOrDefault(x => x.Id == p_IC.Id);

            _context.RemoveRange(entity.StorefrontOrders);
            _context.RemoveRange(entity.Inventories);
            // --------------------------------------------------
            var so = _context.StorefrontOrders.Where(x => x.StorefrontId == entity.Id);
            foreach(StorefrontOrder order in so){
                entity.StorefrontOrders.Remove(order);
            }
            var li = _context.Inventories.Where(x => x.StorefrontId == entity.Id);
            foreach(Inventory lineitem in li){
                entity.Inventories.Remove(lineitem);
            }
            // --------------------------------------------------
            foreach(var lineitem in p_IC.StoreLineItems){
                Delete(lineitem);
            }
            foreach(var order in p_IC.StoreOrders){
                Delete(order);
            }
            _context.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Model.Order p_IC){
            var entity = _context.Orders.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.RemoveRange(entity.OrdersLineitems);
            _context.RemoveRange(entity.CustomerOrders);
            _context.RemoveRange(entity.StorefrontOrders);
            

            var li = _context.OrdersLineitems.Where(x => x.OrdersId == entity.Id);
            foreach(OrdersLineitem lineitem in li){
                entity.OrdersLineitems.Remove(lineitem);
            }
            var co = _context.CustomerOrders.Where(x => x.OrdersId == entity.Id);
            foreach(CustomerOrder order in co){
                entity.CustomerOrders.Remove(order);
            }
            var so = _context.StorefrontOrders.Where(x => x.OrdersId == entity.Id);
            foreach(StorefrontOrder order in so){
                entity.StorefrontOrders.Remove(order);
            }

            _context.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Model.LineItem p_IC){
            var entity = _context.LineItems.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.RemoveRange(entity.OrdersLineitems);
            _context.RemoveRange(entity.Inventories);
            
            var li = _context.OrdersLineitems.Where(x => x.LineItemId == entity.Id);
            foreach(OrdersLineitem lineitem in li){
                entity.OrdersLineitems.Remove(lineitem);
            }
            var inv = _context.Inventories.Where(x => x.LineitemId == entity.Id);
            foreach(Inventory inventory in inv){
                entity.Inventories.Remove(inventory);
            }
            _context.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Model.Product p_IC){
            var entity = _context.Products.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.LineItems.RemoveRange(entity.LineItems);
            var li = _context.LineItems.Where(x => x.ProductId == entity.Id);
            foreach(LineItem lineitem in li){
                entity.LineItems.Remove(lineitem);
            }

            _context.Products.Remove(entity);
            _context.SaveChanges();
        }






        //Method GetAllClasses: Class parameter. Overloaded 5 times. Uses Linq to grab all classes from the database.
        public List<Model.Customer> GetAll(Model.Customer p_IC, bool? p_Active = true){
            var c = _context.Customers.Select(IC =>
                new Model.Customer(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Email = IC.Email,
                    Phone = IC.Phone,
                    Address = IC.Address,
                    TotalSpent = IC.Totalspent,
                    Picture = IC.Picture,
                    CustomerOrders=
                    (from o in _context.Orders
                    join co in _context.CustomerOrders on o.Id equals co.OrdersId
                    where co.CustomerId == IC.Id
                    where o.Active == p_Active
                    select 
                    new Model.Order(){
                        Id = o.Id,
                        Location = o.Location,
                        OrderLineItems=
                        (from li in _context.LineItems
                        join oli in _context.OrdersLineitems on li.Id equals oli.LineItemId
                        where oli.OrdersId == o.Id
                        select 
                        new Model.LineItem(){
                            Id = li.Id,
                            Quantity = li.Quantity,
                            ProductId = li.ProductId,
                            LineProduct = _context.Products.Where(z => z.Id == li.ProductId).Select(a => 
                            new Model.Product(){
                                Id = a.Id,
                                Name = a.Name,
                                Description = a.Description,
                                Price = a.Price,
                                Category = a.Category
                            }).FirstOrDefault()
                        }).ToList()
                    }).ToList()
                }).ToList();
            return c;
        }
        public List<Model.Storefront> GetAll(Model.Storefront p_IC, bool? p_Active = true){
            var c = _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Address = IC.Address,
                    Revenue = IC.Revenue,
                    Expenses = IC.Expenses,
                    StoreLineItems = 
                        (from li in _context.LineItems
                        join i in _context.Inventories on li.Id equals i.LineitemId
                        where i.StorefrontId == IC.Id
                        select
                        new Model.LineItem(){
                            Id = li.Id,
                            Quantity = li.Quantity,
                            ProductId = li.ProductId,
                            LineProduct = _context.Products.Where(z => z.Id == li.ProductId).Select(a => 
                            new Model.Product(){
                                Id = a.Id,
                                Name = a.Name,
                                Description = a.Description,
                                Price = a.Price,
                                Category = a.Category
                            }).FirstOrDefault()
                        }).ToList(),
                    StoreOrders =
                    (from o in _context.Orders
                    join so in _context.StorefrontOrders on o.Id equals so.OrdersId
                    where so.StorefrontId == IC.Id
                    where o.Active == p_Active
                    select 
                    new Model.Order(){
                        Id = o.Id,
                        Location = o.Location,
                        OrderLineItems=
                        (from li in _context.LineItems
                        join oli in _context.OrdersLineitems on li.Id equals oli.LineItemId
                        where oli.OrdersId == o.Id
                        select 
                        new Model.LineItem(){
                            Id = li.Id,
                            Quantity = li.Quantity,
                            ProductId = li.ProductId,
                            LineProduct = _context.Products.Where(z => z.Id == li.ProductId).Select(a => 
                            new Model.Product(){
                                Id = a.Id,
                                Name = a.Name,
                                Description = a.Description,
                                Price = a.Price,
                                Category = a.Category
                            }).FirstOrDefault()
                        }).ToList()
                    }).ToList()
                }).ToList();
            return c;

        }
        public List<Model.Order> GetAll(Model.Order p_IC){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Id = IC.Id,
                    Location = IC.Location,
                    Active = IC.Active,
                    OrderLineItems = _context.LineItems.Where(x => x.Id == _context.OrdersLineitems.Where(y => y.OrdersId == IC.Id).Select(z => z.LineItemId).FirstOrDefault()).Select(x => new Model.LineItem(){
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
                        }).ToList()
                }).ToList();
        }
        public List<Model.LineItem> GetAll(Model.LineItem p_IC){
            return _context.LineItems.Select(IC =>
                new Model.LineItem(){
                    Id = IC.Id,
                    Quantity = IC.Quantity,
                    LineProduct = _context.Products.Where(x => x.Id == IC.ProductId).Select(a => new Model.Product(){
                        Id = a.Id,
                        Name = a.Name,
                        Description = a.Description,
                        Price = (decimal)a.Price,
                        Category = a.Category
                        }).FirstOrDefault()
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
                    TotalSpent = IC.Totalspent,
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
                    Expenses = IC.Expenses,
                    Revenue = IC.Revenue,
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
                    Active = IC.Active,
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
                    TotalSpent = p_IC.Totalspent,
                    Picture = p_IC.Picture,
                    CustomerOrders = _context.Orders.Where(x => x.Id == _context.CustomerOrders.Where(y => y.CustomerId == p_IC.Id).Select(z => z.OrdersId).FirstOrDefault()).Select(x => new Model.Order(){
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
                };
                
        }
        public Model.Storefront Translate(Entity.Storefront p_IC){
            return new Model.Storefront(){
                Id = p_IC.Id,
                Name = p_IC.Name,
                Address = p_IC.Address,
                Revenue = p_IC.Revenue,
                Expenses = p_IC.Expenses,
                StoreLineItems = _context.LineItems.Where(x => x.Id == _context.Inventories.Where(y => y.StorefrontId == p_IC.Id).Select(z => z.LineitemId).FirstOrDefault()).Select(x => new Model.LineItem(){
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
                StoreOrders = _context.Orders.Where(x => x.Id == _context.StorefrontOrders.Where(y => y.StorefrontId == p_IC.Id).Select(z => z.OrdersId).FirstOrDefault()).Select(x => new Model.Order(){
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
                };
                    
        }
                
        // public Model.Order Translate(Entity.Order p_Order, List<Entity.LineItem> p_LineItem){
        //     return new Model.Order(){
        //         Id = p_Order.Id,
        //         Location = p_Order.Location,
        //         OrderLineItems = Translate(p_LineItem, p_Product)
        //         };
        // }
        public static Model.LineItem Translate(Entity.LineItem p_LineItem, Entity.Product p_Product){
            return new Model.LineItem(){
                Id = p_LineItem.Id,
                Quantity = p_LineItem.Quantity,
                ProductId = p_LineItem.ProductId,
                LineProduct = Translate(p_Product)
            };
            
        }
        public static Model.Product Translate(Entity.Product p_Product){
            return new Model.Product(){
                    Id = p_Product.Id,
                    Name = p_Product.Name,
                    Description = p_Product.Description,
                    Category = p_Product.Category,
                    Price = p_Product.Price,
                };
                
        }
        





        // Method UpdateClass: Class parameter. Overloaded 5 times. Used to update a class in the database.
        public void Update(Model.Customer p_IC){
            if(!_context.Customers.Any(x => x.Id == p_IC.Id)){ p_IC = Add(p_IC); }
            var entity = _context.Customers.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Name = p_IC.Name;
            entity.Email = p_IC.Email;
            entity.Phone = p_IC.Phone;
            entity.Address = p_IC.Address;
            entity.Totalspent = p_IC.TotalSpent;
            entity.Picture = p_IC.Picture; 
            foreach(var order in p_IC.CustomerOrders){
                if(!_context.CustomerOrders.Any(x => x.OrdersId == order.Id && x.CustomerId == p_IC.Id)){
                    entity.CustomerOrders.Add(
                    new CustomerOrder(){
                    CustomerId = p_IC.Id,
                    OrdersId = order.Id,
                    });
                }
                _context.SaveChanges();
                Update(order);
                
            }
            _context.SaveChanges();
        }
        public void Update(Model.Storefront p_IC){
            if(!_context.Storefronts.Any(x => x.Id == p_IC.Id)){ p_IC = Add(p_IC); }
            var entity = _context.Storefronts.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Name = p_IC.Name;
            entity.Address = p_IC.Address;
            entity.Revenue = p_IC.Revenue;
            entity.Expenses = p_IC.Expenses;

            foreach(var lineitem in p_IC.StoreLineItems){
                if(!_context.Inventories.Any(x => x.LineitemId == lineitem.Id && x.StorefrontId == p_IC.Id)){
                        entity.Inventories.Add(
                        new Inventory(){
                        LineitemId = lineitem.Id,
                        StorefrontId = p_IC.Id,
                        });
                }
                _context.SaveChanges();
                Update(lineitem);
            }
            foreach(var order in p_IC.StoreOrders){
                if(!_context.StorefrontOrders.Any(x => x.OrdersId == order.Id && x.StorefrontId == p_IC.Id)){
                    entity.StorefrontOrders.Add(
                    new StorefrontOrder(){
                    OrdersId = order.Id,
                    StorefrontId = p_IC.Id,
                    });
                }
                _context.SaveChanges();
                Update(order);
                
            }
            _context.SaveChanges();
        }
        public void Update(Model.Order p_IC){
            if(!_context.Orders.Any(x => x.Id == p_IC.Id)){ p_IC = Add(p_IC); }
            var entity1 = _context.Orders.Where(x => x.Id == p_IC.Id).First();
            entity1.Location = p_IC.Location;
            entity1.Active = p_IC.Active;

            foreach(var li in p_IC.OrderLineItems){
                if(!_context.OrdersLineitems.Any(x => x.OrdersId == p_IC.Id && x.LineItemId == li.Id)){
                    entity1.OrdersLineitems.Add(
                    new OrdersLineitem(){
                    LineItemId = li.Id,
                    OrdersId = p_IC.Id,
                    });
                }
                _context.SaveChanges();
                Update(li);
            }
            _context.SaveChanges();
        }
        public void Update(Model.LineItem p_IC){
            if(!_context.LineItems.Any(x => x.Id == p_IC.Id)){ p_IC = Add(p_IC); }
            var entity = _context.LineItems.FirstOrDefault(x => x.Id == p_IC.Id); 
            entity.Quantity = p_IC.Quantity;
            entity.ProductId = p_IC.ProductId;
            _context.SaveChanges();
        }
        public void Update(Model.Product p_IC){
            if(!_context.Products.Any(x => x.Id == p_IC.Id)){ p_IC = Add(p_IC); }
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
                    TotalSpent = IC.Totalspent,
                    Picture = IC.Picture,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Email.Contains(p_Search) || IC.Phone.Contains(p_Search) || IC.Address.Contains(p_Search)).ToList();
        }
        public List<Model.Storefront> Search(Model.Storefront p_IC, string p_Search){
            return _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Id = IC.Id,
                    Name = IC.Name,
                    Address = IC.Address,
                    Revenue = IC.Revenue,
                    Expenses = IC.Expenses,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Address.Contains(p_Search)).ToList(); 
        }
        public List<Model.Order> Search(Model.Order p_IC, string p_search){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Id = IC.Id,
                    Location = IC.Location,
                    Active = IC.Active,
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