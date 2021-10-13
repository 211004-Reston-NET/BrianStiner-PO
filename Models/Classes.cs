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
        private List<Orders> customerOrders = new List<Orders>();
        public Customer(){}
        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber)
        {
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phoneNumber = p_phoneNumber;
            this.CustomerOrders = new List<Orders>();
        }

        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber, List<Orders> p_Orders)
        {
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phoneNumber = p_phoneNumber;
            this.CustomerOrders = p_Orders;
        }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public List<Orders> CustomerOrders { get => CustomerOrders; set => CustomerOrders = value; }

        public string Identify() { return "Customers.json"; }

        public List<string> ToStringList(){
            List<string> stringlist = new List<string>() {
            $"name: {name}",
            $"address: {address}",
            $"email: {email}",
            $"phoneNumber: {phoneNumber}",
            $"Orders: "};

            foreach(Orders o in customerOrders){
                stringlist.Add(o.ToStringList());
            }

            return stringlist;
        }
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

    //to-do make Orders into Order
    public class Orders : IClass
    {

  
        private List<LineItems> OrderLineItems = new List<LineItems>(); 
        private string location;
        private decimal totalPrice;
        public Orders(string p_location)
        {
            this.location = p_location;
        }

        public List<LineItems> OrderLineItems1 { get => OrderLineItems; set => OrderLineItems = value; }
        public string Location { get => location; set => location = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }

        public string Identify() { return "Orders.json"; }
    }

    public class LineItems : IClass
    {
        private Product lineProduct;
        private int quantity;
        public int Quantity { get => quantity; set => quantity = value; }
        public Product LineProduct { get => lineProduct; set => lineProduct = value; }
        public string Identify() { return "LineItems.json"; }
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
}
