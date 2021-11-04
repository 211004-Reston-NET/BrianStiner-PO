using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public partial class Customer : IClass
    {
        //Variables -----------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public decimal TotalSpent { get; set; }
        [Required]
        public int Picture { get; set; }

        public virtual List<CustomerOrder> CustomerOrders { get; set; }

        //Constructors ---------------------------------------------------------------------------
        public Customer(){}
        public Customer( string p_name):this(){this.Name = p_name;}
        public Customer( string p_name, string p_address):this( p_name){this.Address = p_address;}
        public Customer( string p_name, string p_address, string p_email):this( p_name, p_address){this.Email = p_email;}
        public Customer( string p_name, string p_address, string p_email, string p_phone):this( p_name, p_address, p_email){this.Phone = p_phone;}
        public Customer( string p_name, string p_address, string p_email, string p_phone, decimal p_totalSpent):this( p_name, p_address, p_email, p_phone){this.TotalSpent = p_totalSpent;}
        public Customer( string p_name, string p_address, string p_email, string p_phone, decimal p_totalSpent, List<CustomerOrder> p_customerOrders):this( p_name, p_address, p_email, p_phone, p_totalSpent){this.CustomerOrders = p_customerOrders;}
        public Customer( string p_name, string p_address, string p_email, string p_phone, decimal p_totalSpent, List<CustomerOrder> p_customerOrders, int p_id):this( p_name, p_address, p_email, p_phone, p_totalSpent, p_customerOrders){this.Id = p_id;}

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Customer"; }
        public List<string> ToStringList(){return ToStringList(false);}
        public List<string> ToStringList(bool p_showpastorders){
            List<string> stringlist = new List<string>(){
            " ",
            $"name: {this.Name}",
            $"address: {this.Address}",
            $"email: {this.Email}",
            $"phoneNumber: {this.Phone}",
            $"totalSpent: {this.TotalSpent}",
            $"Orders: "};
            try{
                int cnt = 0;
                foreach(CustomerOrder o in this.CustomerOrders){
                    if(o.Orders.Active || p_showpastorders){
                        stringlist.Add($"-[{cnt++}]-");
                        foreach(string s in o.Orders.ToStringList()){
                            stringlist.Add($"|  {s}");
                        }
                    }
                }
            }catch (System.Exception){
                stringlist.Add("Customer has NULL orders.");
                throw;
            }
            stringlist.Add(" ");
            return stringlist;
        }
    }

    public partial class Store : IClass
    {
        //Variables -----------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public decimal Expenses { get; set; }
        [Required]
        public decimal Revenue { get; set; }
        [Required]
        public virtual List<Inventory> Inventory { get; set; }
        public virtual List<StoreOrder> StoreOrders { get; set; }
        public decimal Profit {get => Revenue-Expenses;}

        //Constructors ---------------------------------------------------------------------------
        public Store(){}
        public Store(string p_name, string p_address){this.Name = p_name;this.Address = p_address; }
        public Store(string p_name, string p_address, decimal p_expenses):this(p_name, p_address){this.Expenses = p_expenses;}
        public Store(string p_name, string p_address, decimal p_expenses, decimal p_revenue):this(p_name, p_address, p_expenses){this.Revenue = p_revenue;}
        public Store(string p_name, string p_address, decimal p_expenses, decimal p_revenue, List<Inventory> p_Inventory):this(p_name, p_address, p_expenses, p_revenue){this.Inventory = p_Inventory;}
        public Store(string p_name, string p_address, decimal p_expenses, decimal p_revenue, List<Inventory> p_Inventory, List<StoreOrder> p_storeOrders):this(p_name, p_address, p_expenses, p_revenue, p_Inventory){this.StoreOrders = p_storeOrders;}
        public Store(string p_name, string p_address, decimal p_expenses, decimal p_revenue, List<Inventory> p_Inventory, List<StoreOrder> p_storeOrders, int p_id):this(p_name, p_address, p_expenses, p_revenue, p_Inventory, p_storeOrders){this.Id = p_id;}
       
        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Storefront"; }
        public List<string> ToStringList(){return ToStringList(false);}
        public List<string> ToStringList(bool p_showpastorders){
            List<string> stringlist = new List<string>() {
            $"Name: {Name}",
            $"Address: {Address}",
            $"Expenses: {Expenses}",
            $"Revenue: {Revenue}",
            $"Profit: {Profit}",
            $"Inventory: ",
            };
            if(Inventory.Count > 0){
                foreach(Inventory l in Inventory){
                    stringlist.Add("---------------------------");
                    stringlist.AddRange(l.LineItem.ToStringList());
                }
            }else{stringlist.Add("   None");}
        stringlist.Add($"StoreOrders: ");
            if(StoreOrders.Count > 0){
                int cnt = 0;
                foreach(StoreOrder o in StoreOrders){
                    if(o.Orders.Active || p_showpastorders){
                        stringlist.Add($"-[{cnt++}]-");
                        foreach(string s in o.Orders.ToStringList()){
                            stringlist.Add($"  {s}");
                        }
                    }
                }
            }else{stringlist.Add("   None");}
            return stringlist;
        }
            
    }

    public partial class Order : IClass
    {
        //Variables -----------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Address { get; set; }
        [Required]
        public bool Active { get; set; }
        public decimal Total { get => CalculateTotalPrice(); }


        public virtual List<CustomerOrder> CustomerOrders { get; set; }
        public virtual List<OrdersLineItem> OrdersLineItems { get; set; }
        public virtual List<StoreOrder> StoreOrders { get; set; }

        //Constructors ---------------------------------------------------------------------------
        public Order(){}
        public Order(int p_Id):this(){this.Id = p_Id;}
        public Order(string p_location):this(){this.Address = p_location;}
        public Order(string p_location, int p_Id):this(p_Id){this.Address = p_location;}
        public Order(string p_location, int p_Id, List<OrdersLineItem> p_ordersLineitems):this(p_location, p_Id){this.OrdersLineItems = p_ordersLineitems;}
        public Order(string p_location, int p_Id, bool p_Active, List<OrdersLineItem> p_ordersLineitems):this(p_location, p_Id, p_ordersLineitems){this.Active = p_Active;}

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Order"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>(){
            $"Active:   {this.Active}",
            $"Order ID: {Id}",
            $"Address:  {Address}",
            $"LineItems: "};
            foreach(OrdersLineItem oli in OrdersLineItems){ 
                foreach(string s in oli.LineItem.ToStringList()){
                    stringlist.Add($"| {s}");
                }
            }
            stringlist.Add($"-------------------------------");
            stringlist.Add($"                 Total: {Total}");
            return stringlist;
        }
        
        //Methods ---------------------------------------------------------------------------------
        public decimal CalculateTotalPrice(){
            decimal orderTotal = 0;
            foreach(OrdersLineItem oli in OrdersLineItems){orderTotal += oli.LineItem.Total;}
            return orderTotal;
        }
    }

    public partial class LineItem : IClass
    {
        //Variables -----------------------------------------------------------------------------
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Total { get => Quantity*Product.Price; }


        public virtual Product Product { get; set; }
        public virtual List<Inventory> Inventories { get; set; }
        public virtual List<OrdersLineItem> OrdersLineitems { get; set; }


        //Constructors ---------------------------------------------------------------------------
        public LineItem(){Product = new Product();}
        public LineItem(int p_quantity){this.Quantity = p_quantity;}
        public LineItem(int p_quantity, Product p_lineProduct):this(p_quantity){this.Product = p_lineProduct;}
        public LineItem(int p_quantity, Product p_lineProduct, int p_Id):this(p_quantity, p_lineProduct){this.Id = p_Id;}

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "LineItem"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>();
            stringlist.Add($"Product:");
            foreach(string s in Product.ToStringList()){
                stringlist.Add($"| {s}");
            }
            stringlist.Add($"Quantity: {Quantity}");
            stringlist.Add($"------------------------------");
            stringlist.Add($"                Total: {Total}");
            return stringlist;
        }
    }

    public partial class Product : IClass
    {
        //Variables -----------------------------------------------------------------------------
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual List<LineItem> LineItems { get; set; }

        //Constructors ---------------------------------------------------------------------------
        public Product(){}
        public Product(string p_name):this(){this.Name = p_name;}
        public Product(string p_name, string p_description):this(p_name){this.Description = p_description;}
        public Product(string p_name, string p_description, string p_category):this(p_name, p_description){this.Category = p_category;}
        public Product(string p_name, string p_description, string p_category, decimal p_price):this(p_name, p_description, p_category){this.Price = p_price;}

        //Interface --------------------------------------------------------------------------------
        public string Identify() { return "Product"; }
        public List<string> ToStringList(){
            List<string> stringlist = new List<string>(){
            $"name: {Name}",
            $"description: {Description}",
            $"category: {Category}",
            $"price: {Price}"};
            return stringlist;
        }
    }

    public partial class CustomerOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrdersId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Orders { get; set; }

        public CustomerOrder(Customer p_customer, Order p_order){
            this.Customer = p_customer; this.CustomerId = p_customer.Id;
            this.Orders = p_order; this.OrdersId = p_order.Id;
        }
    }
    public partial class Inventory
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int LineItemId { get; set; }

        public virtual LineItem LineItem { get; set; }
        public virtual Store Store { get; set; }

        public Inventory(LineItem p_LineItem, Store p_Store){this.Store = p_Store; this.StoreId = p_Store.Id;this.LineItem = p_LineItem; this.LineItemId = p_LineItem.Id;}

    }
    public partial class OrdersLineItem
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int LineItemId { get; set; }

        public virtual LineItem LineItem { get; set; }
        public virtual Order Orders { get; set; }

        public OrdersLineItem(LineItem p_LineItem, Order p_Order){this.Orders = p_Order; this.OrdersId = p_Order.Id;this.LineItem = p_LineItem; this.LineItemId = p_LineItem.Id;}
    }
    public partial class StoreOrder
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public int OrdersId { get; set; }

        public virtual Order Orders { get; set; }
        public virtual Store Stores { get; set; }

        public StoreOrder(Order p_Order, Store p_Store){this.Stores = p_Store; this.StoreId = p_Store.Id;this.Orders = p_Order; this.OrdersId = p_Order.Id;}
    }
}
