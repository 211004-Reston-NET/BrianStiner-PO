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

        //Overridden AddClass. Receives Customer adds to Class.json
        //We add one IClass to the file by first adding to a list of IClasses, translating that list into json serial, then overwriting to the correct file.

        public void AddClass(Customer p_IC){
            List<Customer> listOfCustomer = GetAllClasses(p_IC);
            listOfCustomer.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        } public void AddClass(Storefront p_IC){
            List<Storefront> listOfStorefront = GetAllClasses(p_IC);
            listOfStorefront.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfStorefront, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }public void AddClass(Order p_IC){
            List<Order> listOfOrders = GetAllClasses(p_IC);
            listOfOrders.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfOrders, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }public void AddClass(LineItem p_IC){
            List<LineItem> listOflineItems = GetAllClasses(p_IC);
            listOflineItems.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOflineItems, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }public void AddClass(Product p_IC){
            List<Product> listOfProduct = GetAllClasses(p_IC);
            listOfProduct.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }





        //File IClass will announce their place and be put in a .json they choose
        //Try to read all text from the file and turn into List. If nothings there alert and send blank List.
        public List<Customer> GetAllClasses(Customer p_IC){ 
            try{
                _jsonString = File.ReadAllText($"{c_filepath}{p_IC.Identify()}s.json"); 
                return JsonSerializer.Deserialize<List<Customer>>(_jsonString);    
            }catch (System.IO.FileNotFoundException){
                Console.WriteLine($"There is no {c_filepath}{p_IC.Identify()}s.json file");Console.ReadLine();
                return new List<Customer>(); 
            }
            
        }public List<Storefront> GetAllClasses(Storefront p_IC){  
            try{
                _jsonString = File.ReadAllText($"{c_filepath}{p_IC.Identify()}s.json"); 
                return JsonSerializer.Deserialize<List<Storefront>>(_jsonString);
            }catch (System.IO.FileNotFoundException){
                Console.WriteLine($"There is no {c_filepath}{p_IC.Identify()}s.json file");Console.ReadLine();
                return new List<Storefront>(); 
            }
        }public List<Order> GetAllClasses(Order p_IC){ 
            try{
                _jsonString = File.ReadAllText($"{c_filepath}{p_IC.Identify()}s.json"); 
                return JsonSerializer.Deserialize<List<Order>>(_jsonString);    
            }catch (System.IO.FileNotFoundException){
                Console.WriteLine($"There is no {c_filepath}{p_IC.Identify()}s.json file");Console.ReadLine();
                return new List<Order>(); 
            } 
        }public List<LineItem> GetAllClasses(LineItem p_IC){
            try{
                _jsonString = File.ReadAllText($"{c_filepath}{p_IC.Identify()}s.json"); 
                return JsonSerializer.Deserialize<List<LineItem>>(_jsonString);    
            }catch (System.IO.FileNotFoundException){
                Console.WriteLine($"There is no {c_filepath}{p_IC.Identify()}s.json file");Console.ReadLine();
                return new List<LineItem>(); 
            } 
        }public List<Product> GetAllClasses(Product p_IC){  
            try{
                _jsonString = File.ReadAllText($"{c_filepath}{p_IC.Identify()}s.json"); 
                return JsonSerializer.Deserialize<List<Product>>(_jsonString);    
            }catch (System.IO.FileNotFoundException){
                Console.WriteLine($"There is no {c_filepath}{p_IC.Identify()}s.json file");Console.ReadLine();
                return new List<Product>(); 
            } 
        }


        //Overridden Delete a Class. Receives Class and a List<Class> from Class.json.
        //Uses List.Remove(p_IC) on the list then Overwriting the file with the shorter list.
        public void DelClass(Customer p_IC){
            List<Customer> listOfCustomer = GetAllClasses(p_IC);
            listOfCustomer.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfCustomer, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }public void DelClass(Storefront p_IC){
            List<Storefront> listOfStorefront = GetAllClasses(p_IC);
            listOfStorefront.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfStorefront, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }public void DelClass(Order p_IC){
            List<Order> listOfOrders = GetAllClasses(p_IC);
            listOfOrders.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfOrders, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }public void DelClass(LineItem p_IC){
            List<LineItem> listOflineItems = GetAllClasses(p_IC);
            listOflineItems.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOflineItems, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }public void DelClass(Product p_IC){
            List<Product> listOfProduct = GetAllClasses(p_IC);
            listOfProduct.Remove(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfProduct, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText($"{c_filepath}{p_IC.Identify()}s.json", _jsonString);
        }
    }
}