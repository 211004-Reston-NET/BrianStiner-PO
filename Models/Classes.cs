using System;
using System.Collections.Generic;

/*
Customer, Storefront, Orders, Products, LineItems
*/

namespace Models
{
    // All the classes have a public int ID and inherit from IClass which requires the ToStringList() and Identify() methods.
    public class Customer : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private string name, address, email, phone;
        private List<string> picture = new List<string>(){@"¯\_(ツ)_/¯"," （˶′◡‵˶）"};
        private List<Order> customerOrders = new List<Order>();

        //Constructors ---------------------------------------------------------------------------
        public Customer(){}
        public Customer(string p_name){this.name = p_name;}
        public Customer(string p_name, string p_address, string p_email, string p_phone){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phone;
        }
        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber, List<string> p_picture){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phoneNumber;
            this.picture = p_picture;
        }
        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phoneNumber;
            this.customerOrders = p_Orders;
        }
        public Customer(string p_name, string p_address, string p_email, string p_phoneNumber, List<string> p_picture, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phoneNumber;
            this.picture = p_picture;
            this.customerOrders = p_Orders;
        }


        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public List<Order> CustomerOrders { get => customerOrders; set => customerOrders = value; }
        public List<string> Picture { get => picture; set => picture = value; }

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Customer"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>(){
            " ",
            $"name: {this.name}",
            $"address: {this.address}",
            $"email: {this.email}",
            $"phoneNumber: {this.phone}",
            $"Orders: "};
            try{
                foreach(Order o in this.customerOrders){
                    foreach(string s in o.ToStringList()){
                        stringlist.Add(s);
                    }
                }
            }catch (System.Exception){
                stringlist.Add("Customer has no orders.");
                throw;
            }
            stringlist.Add(""); stringlist.AddRange(picture);
            return stringlist;
        }
    }

    //Storefront has a list of products and orders, as well as a name and address.
    public class Storefront : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private string name, address;
        private List<string> picture = new List<string>(){@"¯\_(ツ)_/¯"," （˶′◡‵˶）"};
        private List<Product> storeProducts;
        private List<Order> storeOrders;

        //Constructors ---------------------------------------------------------------------------
        public Storefront(){}
        public Storefront(string p_name, string p_address){
            this.name = p_name;
            this.address = p_address;

            storeProducts = new List<Product>();
            storeOrders = new List<Order>();

        }
        public Storefront(string p_name, string p_address, List<string> p_picture){
            this.name = p_name;
            this.address = p_address;
            this.picture = p_picture;

            storeProducts = new List<Product>();
            storeOrders = new List<Order>();
        }
        public Storefront(string p_name, string p_address, List<Product> p_Products, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.storeProducts = p_Products;
            this.storeOrders = p_Orders;
        }
        public Storefront(string p_name, string p_address, List<string> p_picture, List<Product> p_Products, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.picture = p_picture;
            this.storeProducts = p_Products;
            this.storeOrders = p_Orders;
        }

        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public List<Product> StoreProducts { get => storeProducts; set => storeProducts = value; }
        public List<Order> StoreOrders { get => storeOrders; set => storeOrders = value; }
        public List<string> Picture { get => picture; set => picture = value; }

        //Interface --------------------------------------------------------------------------------
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

            stringlist.Add("");
            stringlist.AddRange(Picture);
            return stringlist;
        }
            
    }

    //Order has a list of LineItems, a total price, and an address to ship to
    public class Order : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private List<LineItem> orderLineItems; 
        private string location;
        private decimal totalPrice;

        //Constructors ---------------------------------------------------------------------------
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


        //Get & Set -------------------------------------------------------------------------------

        public List<LineItem> OrderLineItems { get => orderLineItems; set => orderLineItems = value; }
        public string Location { get => location; set => location = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        

        //Interface --------------------------------------------------------------------------------

        public string Identify() { return "Order"; }
        
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>(){
            $"location: {location}",
            $"totalPrice: {totalPrice}",
            $"LineItems: "};
            foreach(LineItem LI in OrderLineItems){
                foreach(string s in LI.ToStringList()){
                    stringlist.Add(s);
                }
            }
            return stringlist;
        }
    }

    //LineItem has a quantity and a product. Total is calulated without storing it.
    public class LineItem : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private Product lineProduct;
        private int quantity;


        //Constructors ---------------------------------------------------------------------------
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
  
        //Get & Set -------------------------------------------------------------------------------

        public int Quantity { get => quantity; set => quantity = value; }
        public Product LineProduct { get => lineProduct; set => lineProduct = value; }
        public decimal Total { get => quantity*lineProduct.Price; }


        
        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "LineItem"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>(){
            $"quantity: {quantity}",
            $"product: {lineProduct.ToStringList()}",
            $"------------------------------",
            $"                Total: {Total}",
            ""};
            return stringlist;
        }
    }

    public class Product : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private string name, description, category;
        private decimal price;

        //Constructors ---------------------------------------------------------------------------
        public Product(){}
        public Product(string p_name, string p_description, string p_category, decimal p_price){
            this.name = p_name;
            this.description = p_description;
            this.category = p_category;
            this.price = p_price;
        }

        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
        public decimal Price { get => price; set => price = value; }

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Product"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>(){
            $"name: {name}",
            $"description: {description}",
            $"category: {category}",
            $"price: {price}"};
            return stringlist;
        }
    }
}
