using System;
using System.Collections.Generic;  

namespace Models
{
    interface ICustomer{

        string name, address, email, phoneNumber;
        List<Orders> customerOrders = new List<Orders>();
    }
    interface IStorefront{
        string name, address;
        List<Product> storeProducts = new List<Product>();
        List<Orders> storeOrders = new List<Orders>();

    }
    interface IOrders{
        List<LineItems> OrderLineItems = new List<LineItems>(); 
        string location;
        decimal totalPrice;

    }
    interface ILineItems{
        Product lineProduct;
        int quantity;

    }
    interface IProducts{
        string name, description, category;
        decimal price;

    }

}