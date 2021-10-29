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
        private List<string> picture = new FaceFarm().GetFace();
        private List<Order> customerOrders = new List<Order>();

        //Constructors ---------------------------------------------------------------------------
        public Customer(){}
        public Customer(string p_name){this.name = p_name;}
        public Customer(string p_name, string p_address){this.name = p_name; this.address = p_address;}
        public Customer(string p_name, string p_address, string p_email){this.name = p_name; this.address = p_address; this.email = p_email;}
        public Customer(string p_name, string p_address, string p_email, string p_phone){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phone;
        }
        public Customer(string p_name, string p_address, string p_email, string p_phone, List<string> p_picture){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phone;
            this.picture = p_picture;
        }
        public Customer(string p_name, string p_address, string p_email, string p_phone, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phone;
            this.customerOrders = p_Orders;
        }
        public Customer(string p_name, string p_address, string p_email, string p_phone, List<Order> p_Orders, List<string> p_picture){
            this.name = p_name;
            this.address = p_address;
            this.email = p_email;
            this.phone = p_phone;
            this.customerOrders = p_Orders;
            this.picture = p_picture;
        }


        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public List<Order> CustomerOrders { get => customerOrders; set => customerOrders = value; }
        public List<string> Picture { get => picture; }

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
                stringlist.Add("Customer has NULL orders.");
                throw;
            }
            stringlist.Add("");stringlist.Add("Picture:"); stringlist.AddRange(picture);
            return stringlist;
        }
    }

    //Storefront has a list of products and orders, as well as a name and address.
    public class Storefront : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private string name, address;
        private List<Product> storeProducts = new List<Product>();
        private List<Order> storeOrders = new List<Order>();

        //Constructors ---------------------------------------------------------------------------
        public Storefront(){}
        public Storefront(string p_name, string p_address){
            this.name = p_name;
            this.address = p_address;
        }
        public Storefront(string p_name, string p_address, List<Product> p_products){
            this.name = p_name;
            this.address = p_address;
            storeProducts = p_products;
        }
        public Storefront(string p_name, string p_address, List<Order> p_orders){
            this.name = p_name;
            this.address = p_address;
            storeOrders = p_orders;
        }
        public Storefront(string p_name, string p_address, List<Product> p_Products, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.storeProducts = p_Products;
            this.storeOrders = p_Orders;
        }

        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public List<Product> StoreProducts { get => storeProducts; set => storeProducts = value; }
        public List<Order> StoreOrders { get => storeOrders; set => storeOrders = value; }

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Storefront"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>() {
            $"name: {name}",
            $"address: {address}",
            $"Products: "};
            if(storeProducts.Count != 0){
                foreach(Product p in storeProducts){
                    stringlist.Add("---------------------------");
                    stringlist.AddRange(p.ToStringList());
                }
            }else{stringlist.Add("   None");}
            stringlist.Add($"Orders: ");
            if(storeOrders.Count != 0){
                foreach(Order o in storeOrders){
                    stringlist.Add("---------------------------");
                    stringlist.AddRange(o.ToStringList());
                }
            }else{stringlist.Add("   None");}
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

    class FaceFarm
    {
        private List<List<string>> faceList = new List<List<string>>();
        public FaceFarm()
        {
            int n = 0;
            faceList[n++] =    new List<string>(){  @"    ___________",
                                                    @"   /___     ___\",
                                                    @"  //   `---'   \\",
                                                    @"  ||           || ",
                                                    @"  |/ _________ \| ",
                                                    @" n|=|-o-)=(-o-|=|n ",
                                                    @" \| `--'| |`--' |/ ",
                                                    @"  |    `._.'    | ",
                                                    @"   \   _____   / ",
                                                    @"    \    --   / ",
                                                    @"    |`-.____-'| "};

            faceList[n++] =    new List<string>(){  @"   _,-'}{'-._  ",
                                                    @"  /,;;//\\;;.\ ",
                                                    @"  ///'_  _`\\\ ",
                                                    @"  |Y '_  _` Y| ",
                                                    @"  || ( .. ) || ",
                                                    @"  (_  (__)  _) ",
                                                    @"   l        j  ",
                                                    @"    l  --' j  ",
                                                    @"     \_  _/  ",
                                                    @"    _j    l_",
                                                    @"  ,' `.__,' `.",
                                                    @" /            \",
                                                    @"|__Y________Y__|"};

            faceList[n++] =    new List<string>(){  @"     ,-~~~~~\~~-.  ",
                                                    @"   ,'        \   \  ",
                                                    @"  , .--------'\_  | ",
                                                    @" ,|/| --. .--  |\ |\ ",
                                                    @" | |  (o) (o)   |, \", 
                                                    @" |(|    |)      | ",
                                                    @" /`|    `-'     |' \ ",
                                                    @" |/ \   ____   /| || ",
                                                    @" / / \   --   /   \  ",
                                                    @" />   |\____/ |   \\ ",
                                                    @"  //-|\      / |-\\ ",
                                                    @"     \_\____/ / \\  "};

            faceList[n++] =    new List<string>(){  @"  ,-~~~~~\~~-.  ",
                                                    @"  |        \   \  ",
                                                    @"  | .--------'\_  | ",
                                                    @"  |/| --. .--  |\ |\ ",
                                                    @"  | | (o)  (o)   |, \", 
                                                    @"  |(|   |  )     | ",
                                                    @"  /`|   `--'     |' \ ",
                                                    @"  |/ \  _____   /| || ",
                                                    @"  / / \   --   /   \  ",
                                                    @" />   |\_____/ |   \\ ",
                                                    @"  //-|\       / |-\\ ",
                                                    @"     \_\_____/ / \\  "};

            faceList[n++] =    new List<string>(){  @"      ________",
                                                    @"     / ~~'~~~ \",
                                                    @"   /  _/ - -\_  \",
                                                    @" .   /        \  \", 
                                                    @" | / ---   ---    |", 
                                                    @" |_l (O}   {O)  |_|", 
                                                    @" (|.            .|)",   
                                                    @"  |.     --'    .|",   
                                                    @"   \   .::::,   /",   
                                                    @"    \  `----  /",   
                                                    @"     |\,,,,,,'|",   
                                                    @"     |  . ..  |",  
                                                    @"    /'. . . . '\",   
                                                    @" _/______________\_"};

            faceList[n++] =    new List<string>(){  @"         _____    ",
                                                    @"       --=====-- ",
                                                    @"     // ======= \\  ",
                                                    @"    ||/         \|| ",
                                                    @"    | .-==_ _==-. |  ",
                                                    @"   _|  -o-   -o-  |_ ",
                                                    @"   ||     / \     ||  ",
                                                    @"   \|    '-_-`    |/ ",
                                                    @"     |   _===_   | ",
                                                    @"     |  |-___-|  | ",
                                                    @"      \ |.....| /  ",
                                                    @"   ____`-|||||-'____  ",
                                                    @"  ______\_____/______"};
                                                    
            //faceList[n++] =    new List<string>(){  @"  ,-~~~~~\~~-.  ",
        }

        //Method GetFace returns a random face
        public List<string> GetFace()
        {
            Random rnd = new Random();
            int randint = rnd.Next(0, faceList.Count);
            return faceList[randint];
        }
    }

}
