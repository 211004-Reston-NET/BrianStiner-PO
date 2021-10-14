using System;
using System.Collections.Generic;
using Models;
using DataAccessLogic;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the business logic for the our restuarant application
    /// They are in charge of further processing/sanitizing/furthur validation of data
    /// Any Logic
    /// </summary>
    public class Business :IBusiness
    {
        private IRepository _repo = new Repository();

        public void AddClass(Customer p_IC){
            //Passes to storage without change. 
            _repo.AddClass(p_IC);       
        }

        public List<Customer> GetAllClasses(Customer p_IC){
            //Passes List from storage without change.
            return _repo.GetAllClasses(p_IC);
        }
        public void AddClass(Storefront p_IC){
            //Passes to storage without change. 
            _repo.AddClass(p_IC);       
        }

        public List<Storefront> GetAllClasses(Storefront p_IC){
            //Passes List from storage without change.
            return _repo.GetAllClasses(p_IC);
        }
        public void AddClass(Order p_IC){
            //Passes to storage without change. 
            _repo.AddClass(p_IC);       
        }

        public List<Order> GetAllClasses(Order p_IC){
            //Passes List from storage without change.
            return _repo.GetAllClasses(p_IC);
        }
        public void AddClass(LineItem p_IC){
            //Passes to storage without change. 
            _repo.AddClass(p_IC);       
        }

        public List<LineItem> GetAllClasses(LineItem p_IC){
            //Passes List from storage without change.
            return _repo.GetAllClasses(p_IC);
        }
        public void AddClass(Product p_IC){
            //Passes to storage without change. 
            _repo.AddClass(p_IC);       
        }

        public List<Product> GetAllClasses(Product p_IC){
            //Passes List from storage without change.
            return _repo.GetAllClasses(p_IC);
        }
    }
}