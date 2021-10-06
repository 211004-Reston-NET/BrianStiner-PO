using System;

/*
Customer, Storefront, Orders, Products, LineItems
*/

namespace Models
{
    public class Customer
    {
        string name, address, email, phoneNumber;
        List<Orders> CustomerOrders = new List<Orders>();
    }

    public class Storefront
    {
        string name, address;
        List<Products> StoreProducts = new List<Products>();
        List<Orders> StoreOrders = new List<Orders>();
    }

    public class Orders
    {

        List<LineItems> OrderLineItems = new List<LineItems>(); 
        string location;
        decimal totalPrice;

    }

    public class Products
    {
        string name, description, category;
        decimal price;
    }

    public class LineItems
    {
        Product lineProduct;
        int quantity
    }
}
