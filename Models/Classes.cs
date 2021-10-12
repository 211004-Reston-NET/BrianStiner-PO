using System;
using System.Collections.Generic;  

/*
Customer, Storefront, Orders, Products, LineItems
*/

namespace Models
{
    public class Customer
    {
        private string name, address, email, phoneNumber;
        private List<Orders> customerOrders = new List<Orders>();

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public List<Orders> CustomerOrders { get => CustomerOrders; set => CustomerOrders = value; }
    }

    public class Storefront
    {
        private string name, address;
        private List<Product> storeProducts = new List<Product>();
        private List<Orders> storeOrders = new List<Orders>();

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public List<Product> StoreProducts { get => storeProducts; set => storeProducts = value; }
        public List<Orders> StoreOrders { get => storeOrders; set => storeOrders = value; }
    }

    public class Orders
    {

        private List<LineItems> OrderLineItems = new List<LineItems>(); 
        private string location;
        private decimal totalPrice;

        public List<LineItems> OrderLineItems1 { get => OrderLineItems; set => OrderLineItems = value; }
        public string Location { get => location; set => location = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
    }

    public class Product
    {
        private string name, description, category;
        private decimal price;

        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }
    }

    public class LineItems
    {
        private Product lineProduct;
        private int quantity;
        public int Quantity { get => quantity; set => quantity = value; }
        public Product LineProduct { get => lineProduct; set => lineProduct = value; }
    }
}
