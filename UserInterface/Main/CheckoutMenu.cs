using System;
using System.Collections.Generic;
using BusinessLogic;
using Toolbox;
using Models;

namespace UserInterface{
    public class CheckoutMenu : IMenu{
        MenuBuilder Builder; IBusiness BL;
        public CheckoutMenu(IBusiness BusinessLogic){
            BL = BusinessLogic;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){
            Builder.ResetPause(new List<string>()
            {"Checkout time!",
            "We'll auto-purchase your orders",
            "and ring you up!"});   
                
            var c = Current.customer;
            var s = Current.storefront;

            // Store buying All orders from distributor and adding to Inventory
            if(s.StoreOrders.Count > 0){
                Builder.ResetPause(s.ToStringList());
                foreach(StoreOrder so in  s.StoreOrders){
                    if(so.Orders.Active){
                    foreach(OrdersLineItem oli in so.Orders.OrdersLineItems){
                        s.Expenses += oli.LineItem.Total*.7M;                                                                                       //Stores get a discount from the distributor
                        if(s.Inventory.Find(inv => inv.LineItem.ProductId == oli.LineItem.ProductId) != null){                                      //does it exist?
                        s.Inventory.Find(inv => inv.LineItem.ProductId == oli.LineItem.ProductId).LineItem.Quantity += oli.LineItem.Quantity;       //add if it does by merging
                        }else{s.Inventory.Add(new Inventory(oli.LineItem, s));}                                                                      //add if it doesn't by adding
                    }
                    }   
                    so.Orders.Active = false;
                    Builder.Add($"Order {so.Id} with {so.Orders.OrdersLineItems.Count} items complete.");     
                } 
            }
            // Customer buying from store, increasing store revanue, decreasing store Inventory, and increasing customer's totalspent
            bool orderSuccess = true;
            if(c.CustomerOrders.Count > 0){
                Builder.ResetPause(c.ToStringList());
                foreach(CustomerOrder co in  c.CustomerOrders){
                if(co.Orders.Active){
                foreach(OrdersLineItem oli in co.Orders.OrdersLineItems){
                    if(s.Inventory.Find(inv => inv.LineItem.ProductId == oli.LineItem.ProductId) != null){                                           // if it exists,
                    if(s.Inventory.Find(inv => inv.LineItem.ProductId == oli.LineItem.ProductId).LineItem.Quantity >= oli.LineItem.Quantity){        // if it has enough,
                        s.Inventory.Find(inv => inv.LineItem.ProductId == oli.LineItem.ProductId).LineItem.Quantity -= oli.LineItem.Quantity;        // remove from store
                        s.Revenue += oli.LineItem.Total;                                                                                             // add to store revenue 
                        c.TotalSpent += oli.LineItem.Total;                                                                                          // add to customer spent                                               
                    }else{
                        Builder.ResetPause(new List<string>()
                        {"Sorry, we don't have enough of",
                        $"{oli.LineItem.Product.Name} to complete your order"});  
                        orderSuccess = false; break;
                    }}}                                                                                     
                Builder.Add($"Order {co.Id} with {co.Orders.OrdersLineItems.Count} items complete.");                                                        // if it doesn't exist,
                co.Orders.Active = !orderSuccess;
                }}   
            }
            

            Current.customer = c;
            Current.storefront = s;
            BL.Update(Current.customer);
            BL.Update(Current.storefront);
            Builder.ResetPause("Thank you for shopping with us!");
            
        }
        public MenuType Choice(){return MenuType.Main;}
    }
}
