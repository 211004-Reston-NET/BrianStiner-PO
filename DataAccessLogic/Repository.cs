using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models.Classes;

/* The logic to perform CRUD operations on the models.
Contains repository specific logic on storing and accessing data
*/

namespace RRDL
{
    //Access the json files where data is stored.
    public class Repository : IRepository
    {
        private const string c_filepath = "./../RRDL/Database/Customer.json";
        private const string s_filepath = "./../RRDL/Database/Storefront.json";
        private const string p_filepath = "./../RRDL/Database/Product.json";
        private string _jsonString;
    
        public Customer AddCustomer(Customer p_rest)
        {
            List<Customer> listOfCustomers = GetAllCustomers();

            listOfCustomers.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented=true});

            File.WriteAllText(c_filepath,_jsonString);

            return p_rest;
        }
        public List<Customer> GetAllCustomers()
        {
            //File class will just read everything in the Resturant.json and put it in a string
            _jsonString = File.ReadAllText(c_filepath);
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }

        public List<Storefront> GetAllStorefronts()
        {
            //File class will just read everything in the Resturant.json and put it in a string
            _jsonString = File.ReadAllText(s_filepath);
            return JsonSerializer.Deserialize<List<Storefront>>(_jsonString);
        }
        public Storefront AddStorefront(Storefront p_rest)
        {
            List<Storefront> listOfStorefronts = GetAllStorefront();

            listOfStorefronts.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfStorefronts, new JsonSerializerOptions{WriteIndented=true});

            File.WriteAllText(s_filepath,_jsonString);

            return p_rest;
        }

        public List<Product> GetAllProducts()
        {
            //File class will just read everything in the Resturant.json and put it in a string
            _jsonString = File.ReadAllText(p_filepath);
            return JsonSerializer.Deserialize<List<Product>>(_jsonString);
        }
        public Product AddProduct(Product p_rest)
        {
            List<Product> listOfProducts = GetAllProduct();

            listOfProducts.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfProducts, new JsonSerializerOptions{WriteIndented=true});

            File.WriteAllText(p_filepath,_jsonString);

            return p_rest;
        }

    }
}