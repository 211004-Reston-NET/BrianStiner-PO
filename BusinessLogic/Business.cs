using System;
using System.Linq;
using System.Collections.Generic;
using Models;
using DataAccessLogic;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the business logic for the our economic application.
    /// They are in charge of further processing/sanitizing/furthur validation of data
    /// *Mostly passing data to and from the repository.*
    /// </summary>
    public class Business :IBusiness
    {
        private IRepository _repo;
        public Business(IRepository repo)
        {
            _repo = repo;
        }


        //Customer
        public Customer Add(Customer p_IC){
            return _repo.Add(p_IC);       
        }
        public List<Customer> GetAll(Customer p_IC){
            return _repo.GetAll(p_IC);
        }
        public void Delete(Customer p_IC){
            _repo.Delete(p_IC);
        }
        public List<Customer> Search(Customer p_IC, string p_search){
            return _repo.Search(p_IC, p_search);
        }


        //Storefront
        public Storefront Add(Storefront p_IC){
            return _repo.Add(p_IC);       
        }
        public List<Storefront> GetAll(Storefront p_IC){
            return _repo.GetAll(p_IC);
        }
        public void Delete(Storefront p_IC){
            _repo.Delete(p_IC);       
        }
        public List<Storefront> Search(Storefront p_IC, string p_search){
            return _repo.Search(p_IC, p_search);
        }


        //Order
        public Order Add(Order p_IC){
            return _repo.Add(p_IC);       
        }
        public List<Order> GetAll(Order p_IC){
            return _repo.GetAll(p_IC);
        }
        public void Delete(Order p_IC){
            _repo.Delete(p_IC);       
        }
        public List<Order> Search(Order p_IC, string p_search){
            return _repo.Search(p_IC, p_search);
        }


        //LineItem
        public LineItem Add(LineItem p_IC){
            return _repo.Add(p_IC);       
        }
        public List<LineItem> GetAll(LineItem p_IC){
            return _repo.GetAll(p_IC);
        }
        public void Delete(LineItem p_IC){
            _repo.Delete(p_IC);       
        }
        public List<LineItem> Search(LineItem p_IC, string p_search){
            return _repo.Search(p_IC, p_search);
        }


        //Product
        public Product Add(Product p_IC){
            return _repo.Add(p_IC);       
        }
        public List<Product> GetAll(Product p_IC){
            return _repo.GetAll(p_IC);
        }
        public void Delete(Product p_IC){
            _repo.Delete(p_IC);       
        }
        public List<Product> Search(Product p_IC, string p_search){
            return _repo.Search(p_IC, p_search);
        }


        // Methods Get: parameter class. Overloaded 5 times. Passes and returns a class with matching ID
        public Customer Get(Customer p_IC){
            return _repo.Get(p_IC);
        }
        public Storefront Get(Storefront p_IC){
            return _repo.Get(p_IC);
        }
        public Order Get(Order p_IC){
            return _repo.Get(p_IC);
        }
        public LineItem Get(LineItem p_IC){
            return _repo.Get(p_IC);
        }
        public Product Get(Product p_IC){
            return _repo.Get(p_IC);
        }


        // Methods Update: parameter class. Overloaded 5 times. Passes a Class to update the matching ID.
        public void Update(Customer p_IC){
            _repo.Update(p_IC);
        }
        public void Update(Storefront p_IC){
            _repo.Update(p_IC);
        }
        public void Update(Order p_IC){
            _repo.Update(p_IC);
        }
        public void Update(LineItem p_IC){
            _repo.Update(p_IC);
        }
        public void Update(Product p_IC){
            _repo.Update(p_IC);
        }

        
    }
}