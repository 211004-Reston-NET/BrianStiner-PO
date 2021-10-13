using System;
using System.Collections.Generic;  

/*
Customer, Storefront, Orders, Products, LineItems
*/

namespace Models
{
    public class Customer : IClass
    {
        private string name, address, email, phoneNumber;
        private List<Product> customerProduct = new List<Product>();

        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber)
        {
            
        }

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public List<Product> CustomerProduct { get => CustomerProduct; set => CustomerProduct = value; }

        public string Identify() { return "Customers.json"; }
    }

    public class Storefront : IClass
    {
        private string name, address;
        private List<Product> storeProducts = new List<Product>();
        private List<Orders> storeOrders = new List<Orders>();

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public List<Product> StoreProducts { get => storeProducts; set => storeProducts = value; }
        public List<Orders> StoreOrders { get => storeOrders; set => storeOrders = value; }

        public string Identify() { return "Storefronts.json"; }
            
    }

    public class Orders : IClass
    {

        private List<LineItems> OrderLineItems = new List<LineItems>(); 
        private string location;
        private decimal totalPrice;

        public List<LineItems> OrderLineItems1 { get => OrderLineItems; set => OrderLineItems = value; }
        public string Location { get => location; set => location = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }

        public string Identify() { return "Orders.json"; }
    }

    public class Product : IClass
    {
        private string name, description, category;
        private decimal price;

        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }
        public string Identify() { return "Products.json"; }
    }

    public class LineItems : IClass
    {
        private Product lineProduct;
        private int quantity;
        public int Quantity { get => quantity; set => quantity = value; }
        public Product LineProduct { get => lineProduct; set => lineProduct = value; }
        public string Identify() { return "LineItems.json"; }
    }
}
