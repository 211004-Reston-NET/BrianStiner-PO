using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

/* The logic to perform CRUD operations on the models.
Contains repository specific logic on storing and accessing data
*/

namespace DataAccessLogic
{
    //Access the json files where data is stored.
    public class Repository : IRepository
    {
        private const string c_filepath = "./../DataAccessLogic/Database/"; 
        private string _jsonString;
    
        public void AddClass(Customer p_IC)
        {
            //Overridden AddClass for Customer. Receives Customer adds to Customers.json
            List<Customer> listOfCustomer = GetAllClasses(p_IC);

            //We add one IClass to the file by first adding to a list of IClasses, translating that list into json serial, then overwriting to the correct file.
            listOfCustomer.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void AddClass(Storefront p_IC)
        {
            //Overridden AddClass for Storefront. Receives Storefront adds to Storefront.json
            List<Storefront> listOfStorefront = GetAllClasses(p_IC);

            //We add one IClass to the file by first adding to a list of IClasses, translating that list into json serial, then overwriting to the correct file.
            listOfStorefront.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfStorefront, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void AddClass(Order p_IC)
        {
            //Overridden AddClass for Order. Receives Order adds to Orders.json
            List<Order> listOfOrders = GetAllClasses(p_IC);

            //We add one IClass to the file by first adding to a list of IClasses, translating that list into json serial, then overwriting to the correct file.
            listOfOrders.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfOrders, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void AddClass(LineItem p_IC)
        {
            //Overridden AddClass for LineItem. Receives LineItem adds to LineItems.json
            List<LineItem> listOflineItems = GetAllClasses(p_IC);

            //We add one IClass to the file by first adding to a list of IClasses, translating that list into json serial, then overwriting to the correct file.
            listOflineItems.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOflineItems, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void AddClass(Product p_IC)
        {
            //Overridden AddClass for Product. Receives Product adds to Products.json
            List<Product> listOfProduct = GetAllClasses(p_IC);

            //We add one IClass to the file by first adding to a list of IClasses, translating that list into json serial, then overwriting to the correct file.
            listOfProduct.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }






        public List<Customer> GetAllClasses(Customer p_IC)
        {
            //File IClass will announce their place and be put in a .json they choose
            _jsonString = File.ReadAllText(c_filepath+p_IC.Identify()+"s.json");      
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
        public List<Storefront> GetAllClasses(Storefront p_IC)
        {
            //File IClass will announce their place and be put in a .json they choose
            _jsonString = File.ReadAllText(c_filepath+p_IC.Identify()+"s.json");
            return JsonSerializer.Deserialize<List<Storefront>>(_jsonString);
        }
        public List<Order> GetAllClasses(Order p_IC)
        {
            //File IClass will announce their place and be put in a .json they choose
            _jsonString = File.ReadAllText(c_filepath+p_IC.Identify()+"s.json");
            return JsonSerializer.Deserialize<List<Order>>(_jsonString);
        }
        public List<LineItem> GetAllClasses(LineItem p_IC)
        {
            //File IClass will announce their place and be put in a .json they choose
            _jsonString = File.ReadAllText(c_filepath+p_IC.Identify()+"s.json");
            return JsonSerializer.Deserialize<List<LineItem>>(_jsonString);
        }
        public List<Product> GetAllClasses(Product p_IC)
        {
            //File IClass will announce their place and be put in a .json they choose
            _jsonString = File.ReadAllText(c_filepath+p_IC.Identify()+"s.json");
            return JsonSerializer.Deserialize<List<Product>>(_jsonString);
        }



        public void DelClass(Customer p_IC)
        {
            //Overridden DelClass for Customer. Receives Customer adds to Customers.json
            List<Customer> listOfCustomer = GetAllClasses(p_IC);

            //We delete the matching p_IC Customer in the list then save to the file.
            listOfCustomer.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void DelClass(Storefront p_IC)
        {
            //Overridden DelClass for Storefront. Receives Storefront adds to Storefront.json
            List<Storefront> listOfStorefront = GetAllClasses(p_IC);

            //We add one Storefront to the file by first adding to a list of Storefronts, translating that list into json serial, then overwriting to the correct file.
            listOfStorefront.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfStorefront, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void DelClass(Order p_IC)
        {
            //Overridden DelClass for Order. Receives Order adds to Orders.json
            List<Order> listOfOrders = GetAllClasses(p_IC);

            //We add one Order to the file by first adding to a list of Orders, translating that list into json serial, then overwriting to the correct file.
            listOfOrders.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfOrders, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void DelClass(LineItem p_IC)
        {
            //Overridden DelClass for LineItem. Receives LineItem adds to LineItems.json
            List<LineItem> listOflineItems = GetAllClasses(p_IC);

            //We add one LineItem to the file by first adding to a list of LineItems, translating that list into json serial, then overwriting to the correct file.
            listOflineItems.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOflineItems, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
        public void DelClass(Product p_IC)
        {
            //Overridden DelClass for Product. Receives Product adds to Products.json
            List<Product> listOfProduct = GetAllClasses(p_IC);

            //We add one Product to the file by first adding to a list of Products, translating that list into json serial, then overwriting to the correct file.
            listOfProduct.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify() + "s.json", _jsonString);
        }
    }
}