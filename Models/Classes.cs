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
        private decimal totalSpent;
        internal FaceFarm faceFarm = new FaceFarm();
        private int picture = 0;
        private List<Order> customerOrders = new List<Order>();

        //Constructors ---------------------------------------------------------------------------
        public Customer(){this.picture = faceFarm.AssignFace();}
        public Customer(string p_name):this(){this.name = p_name;}
        public Customer(string p_name, string p_address):this(p_name){this.address = p_address;}
        public Customer(string p_name, string p_address, string p_email):this(p_name, p_address){this.email = p_email;}
        
        public Customer(string p_name, string p_address, string p_email, string p_phone):this(p_name, p_address, p_email){this.phone = p_phone;}
        public Customer(string p_name, string p_address, string p_email, string p_phone, decimal p_totalSpent):this(p_name, p_address, p_email, p_phone){this.totalSpent = p_totalSpent;}
        public Customer(string p_name, string p_address, string p_email, string p_phone, int p_picture, decimal p_totalSpent):this(p_name, p_address, p_email, p_phone, p_totalSpent){this.picture = p_picture;}
        public Customer(string p_name, string p_address, string p_email, string p_phone, List<Order> p_Orders):this(p_name, p_address, p_email, p_phone){this.customerOrders = p_Orders;}
        public Customer(string p_name, string p_address, string p_email, string p_phone, int p_picture, List<Order> p_Orders):this(p_name, p_address, p_email, p_phone, p_Orders){this.picture = p_picture;}
        public Customer(string p_name, string p_address, string p_email, string p_phone, int p_picture, decimal p_totalSpent, List<Order> p_Orders):this(p_name, p_address, p_email, p_phone, p_picture, p_totalSpent){this.customerOrders = p_Orders;}


        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public decimal TotalSpent { get => totalSpent; set => totalSpent = value; }
        public List<Order> CustomerOrders { get => customerOrders; set => customerOrders = value; }
        public int Picture { get => picture; set => picture = value; }

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Customer"; }
        public List<string> ToStringList(){return ToStringList(false);}
        public List<string> ToStringList(bool p_showpastorders){
            List<string> stringlist = new List<string>(){
            " ",
            $"name: {this.name}",
            $"address: {this.address}",
            $"email: {this.email}",
            $"phoneNumber: {this.phone}",
            $"totalSpent: {this.totalSpent}",
            $"Orders: "};
            try{
                int cnt = 0;
                foreach(Order o in this.customerOrders){
                    if(o.Active || p_showpastorders){
                        stringlist.Add($"-[{cnt++}]-");
                        foreach(string s in o.ToStringList()){
                            stringlist.Add($"|  {s}");
                        }
                    }
                }
            }catch (System.Exception){
                stringlist.Add("Customer has NULL orders.");
                throw;
            }
            stringlist.Add("");stringlist.Add("Picture:"); stringlist.AddRange(faceFarm.GetFace(picture));
            return stringlist;
        }
    }

    public class Storefront : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private string name, address;
        private decimal expenses, revenue;
        private List<LineItem> storeLineItems = new List<LineItem>();
        private List<Order> storeOrders = new List<Order>();

        //Constructors ---------------------------------------------------------------------------
        public Storefront(){}
        public Storefront(string p_name, string p_address){
            this.name = p_name;
            this.address = p_address;
        }
        public Storefront(string p_name, string p_address, List<LineItem> p_LineItems){
            this.name = p_name;
            this.address = p_address;
            storeLineItems = p_LineItems;
        }
        public Storefront(string p_name, string p_address, List<Order> p_orders){
            this.name = p_name;
            this.address = p_address;
            storeOrders = p_orders;
        }
        public Storefront(string p_name, string p_address, List<LineItem> p_LineItems, List<Order> p_Orders){
            this.name = p_name;
            this.address = p_address;
            this.storeLineItems = p_LineItems;
            this.storeOrders = p_Orders;
        }

        //Get & Set -------------------------------------------------------------------------------
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public decimal Expenses { get => expenses; set => expenses = value; }
        public decimal Revenue { get => revenue; set => revenue = value; }
        public decimal Profit { get => revenue - expenses; }
        public List<LineItem> StoreLineItems { get => storeLineItems; set => storeLineItems = value; }
        public List<Order> StoreOrders { get => storeOrders; set => storeOrders = value; }

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Storefront"; }
        public List<string> ToStringList(){return ToStringList(false);}
        public List<string> ToStringList(bool p_showpastorders){
            List<string> stringlist = new List<string>() {
            $"name: {name}",
            $"address: {address}",
            $"Expenses: {expenses}",
            $"Revenue: {revenue}",
            $"Profit: {Profit}",
            $"Inventory: ",
            };
            if(storeLineItems.Count > 0){
                foreach(LineItem l in storeLineItems){
                    stringlist.Add("---------------------------");
                    stringlist.AddRange(l.ToStringList());
                }
            }else{stringlist.Add("   None");}
            stringlist.Add($"Orders: ");
            if(storeOrders.Count != 0){
                int cnt = 0;
                foreach(Order o in storeOrders){
                    if(o.Active || p_showpastorders){
                        stringlist.Add($"-[{cnt++}]-");
                        foreach(string s in o.ToStringList()){
                            stringlist.Add($"  {s}");
                        }
                    }
                }
            }else{stringlist.Add("   None");}
            return stringlist;
        }
            
    }

    public class Order : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        private List<LineItem> orderLineItems = new List<LineItem>(); 
        private string delivery = "";
        private bool active = true;
        private decimal totalPrice = 0;

        //Constructors ---------------------------------------------------------------------------
        public Order(){totalPrice = CalculateTotalPrice();}
        public Order(int p_Id):this(){this.Id = p_Id;}
        public Order(string p_location):this(){this.delivery = p_location;}
        public Order(string p_location, int p_Id):this(p_Id){this.delivery = p_location;}
        public Order(string p_location, int p_Id, List<LineItem> p_LineItems):this(p_location, p_Id){this.orderLineItems = p_LineItems;}
        public Order(string p_location, int p_Id, bool p_Active, List<LineItem> p_LineItems):this(p_location, p_Id, p_LineItems){this.Active = p_Active;}

        //Get & Set -------------------------------------------------------------------------------

        public List<LineItem> OrderLineItems { get => orderLineItems; set => orderLineItems = value; }
        public string Location { get => delivery; set => delivery = value; }
        public decimal TotalPrice { get => CalculateTotalPrice(); set => totalPrice = CalculateTotalPrice(); }
        public int ID { get => Id; set => Id = value; }
        public bool Active { get => active; set => active = value; }

        

        //Interface --------------------------------------------------------------------------------

        public string Identify() { return "Order"; }
        
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>(){
            $"Active:   {this.Active}",
            $"Order ID: {Id}",
            $"Address:  {delivery}",
            $"LineItems: "};
            foreach(LineItem LI in OrderLineItems){ 
                foreach(string s in LI.ToStringList()){
                    stringlist.Add($"| {s}");
                }
            }
            stringlist.Add($"-------------------------------");
            stringlist.Add($"                 Total: {TotalPrice}");
            return stringlist;
        }

        //Methods ---------------------------------------------------------------------------------
        public decimal CalculateTotalPrice(){
            decimal orderTotal = 0;
            foreach(LineItem LI in OrderLineItems){orderTotal += LI.Total;}
            return orderTotal;
        }
    }

    public class LineItem : IClass
    {
        //Variables -----------------------------------------------------------------------------
        public int Id { get; set; }
        public int ProductId { get; set; }
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
            List<string> stringlist = new List<string>();
            stringlist.Add($"Product:");
            foreach(string s in lineProduct.ToStringList()){
                stringlist.Add($"| {s}");
            }
            stringlist.Add($"Quantity: {quantity}");
            stringlist.Add($"------------------------------");
            stringlist.Add($"                Total: {Total}");
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

    public class FaceFarm
    {
        private List<List<string>> faceList = new List<List<string>>();
        public FaceFarm()
        {
            faceList.Add(      new List<string>(){  @"    ___________",
                                                    @"   /___     ___\",
                                                    @"  //   `---'   \\",
                                                    @"  ||           || ",
                                                    @"  |/ _________ \| ",
                                                    @" n|=|-o-)=(-o-|=|n ",
                                                    @" \| `--'| |`--' |/ ",
                                                    @"  |    `._.'    | ",
                                                    @"   \   _____   / ",
                                                    @"    \    --   / ",
                                                    @"    |`-.____-'| "});

            faceList.Add(      new List<string>(){  @"   _,-'}{'-._  ",
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
                                                    @"|__Y________Y__|"});

            faceList.Add(      new List<string>(){  @"     ,-~~~~~\~~-.  ",
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
                                                    @"     \_\____/ / \\  "});

            faceList.Add(      new List<string>(){  @"  ,-~~~~~\~~~~~-.  ",
                                                    @"  |          \   \  ",
                                                    @"  | .---------'\_  | ",
                                                    @"  |/|_--. .--_  |\ |\ ",
                                                    @"  | | (o)  (o)   |, \", 
                                                    @"  |(|   |  )     | ",
                                                    @"  /`|   `--'     |' \ ",
                                                    @"  |/ \  ______  /| || ",
                                                    @"  / / \  ---   /   \  ",
                                                    @" />   |\_____/ |   \\ ",
                                                    @"  //-|\       / |-\\ ",
                                                    @"     \_\_____/ / \\  "});

            faceList.Add(      new List<string>(){  @"      ________",
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
                                                    @" _/______________\_"});

            faceList.Add(      new List<string>(){  @"         _____    ",
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
                                                    @"  ______\_____/______"});

            //faceList.Add(      new List<string>(){  @"  ,-~~~~~\~~-.  ",
        }

        //Returns a random face's index
        public int AssignFace()
        {
            Random rnd = new Random();
            return rnd.Next(0, faceList.Count);
        }
        //Given an index, returns a face
        public List<string> GetFace(int index)
        {
            return faceList[index];
        }
    }

}
