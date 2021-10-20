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
        //Variables -----------------------------------------------------------------------------
        private string name, address, email, phoneNumber;
        private List<Order> customerOrders = new List<Order>();

        //Constructors ---------------------------------------------------------------------------
        public Customer(){}
        public Customer(string p_name){this.name = p_name;}
        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phoneNumber = p_phoneNumber;
            Console.WriteLine($"name:{name} address:{address} email:{email} phone number:{phoneNumber}");
            Console.ReadLine();
        }
        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phoneNumber = p_phoneNumber;
            this.customerOrders = p_Orders;
        }

        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public List<Order> CustomerOrders { get => customerOrders; set => customerOrders = value; }

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Customer"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>() {
            $"name: {this.name}",
            $"address: {this.address}",
            $"email: {this.email}",
            $"phoneNumber: {this.phoneNumber}",
            $"Orders: "};
            try{
                foreach(Order o in this.customerOrders){
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
        private List<Product> storeProducts;
        private List<Order> storeOrders;

        public Storefront(){}
        public Storefront(string p_name, string p_address){
            this.name = p_name;
            this.address = p_address;

            storeProducts = new List<Product>();
            storeOrders = new List<Order>();

        }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public List<Product> StoreProducts { get => storeProducts; set => storeProducts = value; }
        public List<Order> StoreOrders { get => storeOrders; set => storeOrders = value; }

        public string Identify() { return "Storefront"; }
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
            foreach(Order o in storeOrders){
                foreach(string s in o.ToStringList()){
                    stringlist.Add(s);
                }
            }

            return stringlist;
        }
            
    }

    //to-do make Orders into Order
    public class Order : IClass
    {

  
        private List<LineItem> OrderLineItems; 
        private string location;
        private decimal totalPrice;



        public Order(){}
        public Order(string p_location)
        {
            this.location = p_location;
            this.totalPrice = 0;
            OrderLineItems = new List<LineItem>();
        }
        public Order(string p_location, List<LineItem> p_LineItems)
        {
            location = p_location;
            OrderLineItems = p_LineItems;
            foreach(LineItem LI in OrderLineItems){
                totalPrice += LI.Quantity*LI.LineProduct.Price;
            }
        }

        public List<LineItem> OrderLineItems1 { get => OrderLineItems; set => OrderLineItems = value; }
        public string Location { get => location; set => location = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Identify() { return "Order"; }

        public List<string> ToStringList(){
        List<string> stringlist = new List<string>() {
                $"location: {this.location}",
                $"total price: {this.totalPrice}",
                $"Line Items: "};

            foreach(LineItem l in this.OrderLineItems){
                foreach(string s in l.ToStringList()){
                    stringlist.Add(s);
                }
            }

            return stringlist;
        }
    }

    public class LineItem : IClass
    {
        private Product lineProduct;
        private int quantity;
        public LineItem(){}
        public LineItem(int p_quantity){
            this.quantity = p_quantity;
            lineProduct = new Product();
        }
        public LineItem(int p_quantity, Product p_product){
            this.quantity = p_quantity;
            lineProduct = p_product;
        }
        public LineItem(int p_quantity, string p_name, string p_description, string p_category, decimal p_price){
            this.quantity = p_quantity;
            lineProduct = new Product(p_name, p_description, p_category, p_price);
        }


        public int Quantity { get => quantity; set => quantity = value; }
        public Product LineProduct { get => lineProduct; set => lineProduct = value; }

        
        public string Identify() { return "LineItem"; }
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
        //variables
        private string name, description, category;
        private decimal price;


        //Constructors
        public Product(){}
        public Product(string p_name, string p_description, string p_category, decimal p_price){
            this.Name = p_name;
            this.description = p_description;
            this.category = p_category;
            this.price = p_price;
        }

        //Getters and Setters
        public string Name { get => name; set => name = value; }
        public string Category { get => category; set => category = value; }
        public string Description { get => description; set => description = value; }
        public decimal Price { get => price; set => price = value; }


        public string Identify() { return "Product"; }


        //The rest
        public List<string> ToStringList(){
        List<string> stringlist = new List<string>() {
                $"name: {Name}",
                $"description: {description}",
                $"category: {category}",
                $"price: {price}"};

            return stringlist;
        }
    }
}
