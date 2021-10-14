using System;
using System.Collections.Generic;
using Toolbox;

/*
Customer, Storefront, Orders, Products, LineItems
*/

namespace Models
{
    public class Customer : IClass
    {
        private string name, address, email, phoneNumber;
        private List<Orders> customerOrders = new List<Orders>();
        public Customer(){

            Tools Builder = new Tools();    
            var menulines = new List<string>()
            {"Fill in Customer's info,",
            "What is their name?"};
            Builder.BuildMenu(menulines);
            this.name = Console.ReadLine();
            menulines.Add(name);

            menulines.Add("What is their address?");
            Builder.BuildMenu(menulines);
            this.address = Console.ReadLine();
            menulines.Add(address);

            menulines.Add("What is their email?");
            Builder.BuildMenu(menulines);
            this.email = Console.ReadLine();
            menulines.Add(email);

            menulines.Add("What is their phone number?");
            Builder.BuildMenu(menulines);
            this.phoneNumber = Console.ReadLine();
            menulines.Add(phoneNumber);

            menulines.Add("   ------------------   ");
            foreach(string s in this.ToStringList()){
                menulines.Add(s);
            }

            menulines.Add("Press Enter to Continue...");
            Builder.BuildMenu(menulines);
            Console.ReadLine();

        }
        public Customer(string p_name){
            this.name = p_name;
        }
        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber)
        {
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phoneNumber = p_phoneNumber;
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
            $"name: {this.name}",
            $"address: {this.address}",
            $"email: {this.email}",
            $"phoneNumber: {this.phoneNumber}",
            $"Orders: "};
            try{
                foreach(Orders o in this.customerOrders){
                    foreach(string s in o.ToStringList()){
                        stringlist.Add(s);
                    }
                }
            }
            catch (System.Exception){
                stringlist.Add("Customer has no orders.");
                throw;
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
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>() {
            $"name: {name}",
            $"address: {address}",
            $"Products: "};

            foreach(Product p in storeProducts){
                foreach(string s in p.ToStringList()){
                    stringlist.Add(s);
                }
            }

            stringlist.Add($"Orders: ");
            foreach(Orders o in storeOrders){
                foreach(string s in o.ToStringList()){
                    stringlist.Add(s);
                }
            }

            return stringlist;
        }
            
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

        public List<string> ToStringList(){
        List<string> stringlist = new List<string>() {
                $"location: {this.location}",
                $"total price: {this.totalPrice}",
                $"Line Items: "};

            foreach(LineItems l in this.OrderLineItems){
                foreach(string s in l.ToStringList()){
                    stringlist.Add(s);
                }
            }

            return stringlist;
        }
    }

    public class LineItems : IClass
    {
        private Product lineProduct;
        private int quantity;
        public int Quantity { get => quantity; set => quantity = value; }
        public Product LineProduct { get => lineProduct; set => lineProduct = value; }
        public string Identify() { return "LineItems.json"; }
        public List<string> ToStringList(){
        List<string> stringlist = new List<string>() {
                $"quantity: {quantity}",
                $"Product: "};
            foreach(string s in lineProduct.ToStringList()){
                stringlist.Add(s);
            }
            

            return stringlist;
        }
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

        public List<string> ToStringList(){
        List<string> stringlist = new List<string>() {
                $"name: {name}",
                $"description: {description}",
                $"category: {category}",
                $"price: {price}"};

            return stringlist;
        }
    }
}
