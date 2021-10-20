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
        public List<Customer> SearchClass(Customer p_IC, string p_search){
            List<Customer> listOfCustomers = _repo.GetAllClasses(p_IC);
            return listOfCustomers.Where(IC => IC.Name.ToLower().Contains(p_search.ToLower())).ToList();
        }
        public Customer ChooseClassFromList(List<Customer> p_ICList){
            int choice = Int32.Parse(Console.ReadLine());
            while(choice > p_ICList.Count || choice < 0)
            {
                Console.WriteLine("Thats not a valid selection. Try again.");
                choice = Int32.Parse(Console.ReadLine());
            }
            return p_ICList[choice];
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
        public List<Storefront> SearchClass(Storefront p_IC, string p_search)
        {
            List<Storefront> listOfStorefronts = _repo.GetAllClasses(p_IC);
            return listOfStorefronts.Where(IC => IC.Name.ToLower().Contains(p_search.ToLower())).ToList();
        }
        public Storefront ChooseClassFromList(List<Storefront> p_ICList){
            int choice = Int32.Parse(Console.ReadLine());
            while(choice > p_ICList.Count || choice < 0)
            {
                Console.WriteLine("Thats not a valid selection. Try again.");
                choice = Int32.Parse(Console.ReadLine());
            }
            return p_ICList[choice];
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
        public List<Order> SearchClass(Order p_IC, string p_search){
            List<Order> listOfOrders = _repo.GetAllClasses(p_IC);
            return listOfOrders.Where(IC => IC.Location.ToLower().Contains(p_search.ToLower())).ToList();
        }
        public Order ChooseClassFromList(List<Order> p_ICList){
            int choice = Int32.Parse(Console.ReadLine());
            while(choice > p_ICList.Count || choice < 0)
            {
                Console.WriteLine("Thats not a valid selection. Try again.");
                choice = Int32.Parse(Console.ReadLine());
            }
            return p_ICList[choice];
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
        public List<LineItem> SearchClass(LineItem p_IC, string p_search){
            List<LineItem> listOfLineItems = _repo.GetAllClasses(p_IC);
            return listOfLineItems.Where(IC => IC.LineProduct.Name.ToLower().Contains(p_search.ToLower())).ToList();
        }
        public LineItem ChooseClassFromList(List<LineItem> p_ICList){
            int choice = Int32.Parse(Console.ReadLine());
            while(choice > p_ICList.Count || choice < 0)
            {
                Console.WriteLine("Thats not a valid selection. Try again.");
                choice = Int32.Parse(Console.ReadLine());
            }
            return p_ICList[choice];
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
        public List<Product> SearchClass(Product p_IC, string p_search){
            List<Product> listOfProducts = _repo.GetAllClasses(p_IC);
            return listOfProducts.Where(IC => IC.Name.ToLower().Contains(p_search.ToLower())).ToList();
        }
        public Product ChooseClassFromList(List<Product> p_ICList){
            int choice = Int32.Parse(Console.ReadLine());
            while(choice > p_ICList.Count || choice < 0)
            {
                Console.WriteLine("Thats not a valid selection. Try again.");
                choice = Int32.Parse(Console.ReadLine());
            }
            return p_ICList[choice];
        }

    }
}