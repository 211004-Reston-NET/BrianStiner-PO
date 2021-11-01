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
            Builder.Reset(new List<string>()
                {"Checkout time!",
                "We'll auto-purchase and ring you up!"
                });
            if(Current.storefront.StoreOrders.Count > 0){
                Builder.Pause(Current.customer.ToStringList());
                foreach(Order o in  Current.storefront.StoreOrders){
                    foreach(LineItem li in o.OrderLineItems){
                        Current.storefront.Expenses += li.Total*.9M; //Stores get a discount from the distributor
                        if(Current.storefront.StoreLineItems.Contains(li)){
                            Current.storefront.StoreLineItems.Find(x => x.ProductId == li.ProductId).Quantity += li.Quantity;
                        }else{
                            Current.storefront.StoreLineItems.Add(li);
                        }
                    }
                    BL.Delete(o);
                    o.OrderLineItems.Clear();
                }
            }
            if(Current.customer.CustomerOrders.Count > 0){
                foreach(Order o in  Current.customer.CustomerOrders){
                    foreach(LineItem li in o.OrderLineItems){
                        Current.customer.TotalSpent += li.Total;
                        Current.storefront.Revenue += li.Total;
                        Current.storefront.StoreLineItems.Find(x => x.ProductId == li.ProductId).Quantity -= li.Quantity;
                    }
                    BL.Delete(o);
                    o.OrderLineItems.Clear();
                }
            }
            Current.customer.CustomerOrders.Clear();
            BL.Update(Current.customer);
            BL.Update(Current.storefront);
            Builder.Pause("Thank you for shopping with us!");
        }

        public MenuType Choice(){return MenuType.Main;}
    }
}
