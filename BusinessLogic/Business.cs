using System;
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
        private IRepository _repo = new Repository();


        //Customer
        public void AddClass(Customer p_IC){
            _repo.AddClass(p_IC);       
        }
        public List<Customer> GetAllClasses(Customer p_IC){
            return _repo.GetAllClasses(p_IC);
        }
        public void DelClass(Customer p_IC){
            _repo.DelClass(p_IC);
        }

        //Storefront
        public void AddClass(Storefront p_IC){
            _repo.AddClass(p_IC);       
        }
        public List<Storefront> GetAllClasses(Storefront p_IC){
            return _repo.GetAllClasses(p_IC);
        }
        public void DelClass(Storefront p_IC){
            _repo.DelClass(p_IC);       
        }

        //Order
        public void AddClass(Order p_IC){
            _repo.AddClass(p_IC);       
        }
        public List<Order> GetAllClasses(Order p_IC){
            return _repo.GetAllClasses(p_IC);
        }
        public void DelClass(Order p_IC){
            _repo.DelClass(p_IC);       
        }

        //LineItem
        public void AddClass(LineItem p_IC){
            _repo.AddClass(p_IC);       
        }
        public List<LineItem> GetAllClasses(LineItem p_IC){
            return _repo.GetAllClasses(p_IC);
        }
        public void DelClass(LineItem p_IC){
            _repo.DelClass(p_IC);       
        }

        //Product
        public void AddClass(Product p_IC){
            _repo.AddClass(p_IC);       
        }
        public List<Product> GetAllClasses(Product p_IC){
            return _repo.GetAllClasses(p_IC);
        }
        public void DelClass(Product p_IC){
            _repo.DelClass(p_IC);       
        }
    }
}