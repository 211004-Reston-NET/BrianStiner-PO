using System.Collections.Generic;
using System.Linq;
using System;
using Entity = DataAccessLogic.Entity;
using Model = Models;

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
        public void Add(Model.Customer p_IC){
            _context.Add(
                new Entity.Customer(){
                    Name = p_IC.Name,
                    Address = p_IC.Address,
                    Email = p_IC.Email,
                    Phone = p_IC.Phone,
                });
            _context.SaveChanges();
        }
        public void Add(Model.Storefront p_IC){
            _context.Add(
                new Entity.Storefront(){
                    Name = p_IC.Name,
                    Address = p_IC.Address
                });
            _context.SaveChanges();
        }
        public void Add(Model.Order p_IC){
            _context.Add(
                new Entity.Order(){
                    Location = p_IC.Location
                });
            _context.SaveChanges();
        }
        public void Add(Model.LineItem p_IC){
            _context.Add(
                new Entity.LineItem(){
                    Quantity = p_IC.Quantity
                });
            _context.SaveChanges();
        }
        public void Add(Model.Product p_IC){
            _context.Add(
                new Entity.Product(){
                    Name = p_IC.Name,
                    Description = p_IC.Description,
                    Category = p_IC.Category,
                    Price = p_IC.Price
                });
            _context.SaveChanges();
        }

        // Method DelClass: Class parameter. Overloaded 5 times. Used to delete a class from the database.
        public void Delete(Model.Customer p_IC){
            var entity = _context.Customers.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Model.Storefront p_IC){
            var entity = _context.Storefronts.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.Storefronts.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Model.Order p_IC){
            var entity = _context.Orders.FirstOrDefault(x => x.Id == p_IC.Id);
            _context.Orders.Remove(entity);
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
                    Name = IC.Name,
                    Email = IC.Email,
                    Phone = IC.Phone,
                    Address = IC.Address,
                }).ToList();
        }
        public List<Model.Storefront> GetAll(Model.Storefront p_IC){
            return _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Name = IC.Name,
                    Address = IC.Address,
                }).ToList();
        }
        public List<Model.Order> GetAll(Model.Order p_IC){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Location = IC.Location,
                }).ToList();
        }
        public List<Model.LineItem> GetAll(Model.LineItem p_IC){
            return _context.LineItems.Select(IC =>
                new Model.LineItem(){
                    Quantity = (int)IC.Quantity,
                }).ToList();
        }
        public List<Model.Product> GetAll(Model.Product p_IC){
            return _context.Products.Select(IC =>
                new Model.Product(){
                    Name = IC.Name,
                    Description = IC.Description,
                    Category = IC.Category,
                    Price = (decimal)IC.Price,
                }).ToList();
        }




        // Method GetClass: Class parameter. Overloaded 5 times. Uses Linq to grab a class from the database by its ID.
        public Model.Customer Get(Model.Customer p_IC){
            return _context.Customers.Select(IC =>
                new Model.Customer(){
                    Name = IC.Name,
                    Email = IC.Email,
                    Phone = IC.Phone,
                    Address = IC.Address,
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.Storefront Get(Model.Storefront p_IC){
            return _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Name = IC.Name,
                    Address = IC.Address,
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.Order Get(Model.Order p_IC){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Location = IC.Location,
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.LineItem Get(Model.LineItem p_IC){
            return _context.LineItems.Select(IC =>
                new Model.LineItem(){
                    Quantity = (int)IC.Quantity,
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        public Model.Product Get(Model.Product p_IC){
            return _context.Products.Select(IC =>
                new Model.Product(){
                    Name = IC.Name,
                    Description = IC.Description,
                    Category = IC.Category,
                    Price = (decimal)IC.Price,
                }).FirstOrDefault(IC => IC.Id == p_IC.Id);
        }
        
        // Method UpdateClass: Class parameter. Overloaded 5 times. Used to update a class in the database.
        public void Update(Model.Customer p_IC){
            var entity = _context.Customers.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Name = p_IC.Name;
            entity.Email = p_IC.Email;
            entity.Phone = p_IC.Phone;
            entity.Address = p_IC.Address;
            _context.SaveChanges();
        }
        public void Update(Model.Storefront p_IC){
            var entity = _context.Storefronts.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Name = p_IC.Name;
            entity.Address = p_IC.Address;
            _context.SaveChanges();
        }
        public void Update(Model.Order p_IC){
            var entity = _context.Orders.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Location = p_IC.Location;
            _context.SaveChanges();
        }
        public void Update(Model.LineItem p_IC){
            var entity = _context.LineItems.FirstOrDefault(x => x.Id == p_IC.Id);
            entity.Quantity = p_IC.Quantity;
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
                    Name = IC.Name,
                    Email = IC.Email,
                    Phone = IC.Phone,
                    Address = IC.Address,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Email.Contains(p_Search) || IC.Phone.Contains(p_Search) || IC.Address.Contains(p_Search)).ToList();
        }
        public List<Model.Storefront> Search(Model.Storefront p_IC, string p_Search){
            return _context.Storefronts.Select(IC =>
                new Model.Storefront(){
                    Name = IC.Name,
                    Address = IC.Address,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Address.Contains(p_Search)).ToList(); 
        }
        public List<Model.Order> Search(Model.Order p_IC, string p_search){
            return _context.Orders.Select(IC =>
                new Model.Order(){
                    Location = IC.Location,
                }).Where(IC => IC.Location.Contains(p_search)).ToList();
        }
        public List<Model.LineItem> Search(Model.LineItem p_IC, string p_Search){
            return _context.LineItems.Select(IC =>
                new Model.LineItem(){
                    Quantity = (int)IC.Quantity,
                }).Where(IC => IC.Quantity.ToString().Contains(p_Search)).ToList();
        }
        public List<Model.Product> Search(Model.Product p_IC, string p_Search){
            return _context.Products.Select(IC =>
                new Model.Product(){
                    Name = IC.Name,
                    Description = IC.Description,
                    Category = IC.Category,
                    Price = (decimal)IC.Price,
                }).Where(IC => IC.Name.Contains(p_Search) || IC.Description.Contains(p_Search) || IC.Category.Contains(p_Search) || IC.Price.ToString().Contains(p_Search)).ToList();
        }



    }
}