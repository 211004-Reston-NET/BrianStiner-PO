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
        private const string _filepath = "./../RRDL/Database/Customer.json";
        private string _jsonString;
    
        public Customer AddCustomer(Customer p_rest)
        {
            List<Customer> listOfCustomers = GetAllCustomer();

            listOfCustomers.Add(p_rest);

            _jsonString = JsonSerializer.Serialize(listOfCustomers, new JsonSerializerOptions{WriteIndented=true});

            File.WriteAllText(_filepath,_jsonString);

            return p_rest;
        }

        public List<Customer> GetAllCustomers()
        {
            //File class will just read everything in the Resturant.json and put it in a string
            _jsonString = File.ReadAllText(_filepath);

            //Since we are converting from a string to an object that C# understands we need to deserialize the string to object.
            //Json Serializer has a static method called Deserialize and thats why you don't need to instantiate it
            //The parameter of the Deserialize method needs a string variable that holds the json file
            return JsonSerializer.Deserialize<List<Customer>>(_jsonString);
        }
    }
}