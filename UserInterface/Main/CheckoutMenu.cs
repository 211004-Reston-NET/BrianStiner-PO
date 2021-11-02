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
                "We'll auto-purchase and ring you up!"
                });
            var c = Current.customer;
            var s = Current.storefront;

            // Store buying from distributor
            if(s.StoreOrders.Count > 0){
                Builder.ResetPause(s.ToStringList());
                foreach(Order o in  s.StoreOrders){
                    if(o.Active){
                    foreach(LineItem li in o.OrderLineItems){
                        s.Expenses += li.Total*.7M;                                                         //Stores get a discount from the distributor
                        if(s.StoreLineItems.Find(x => x.ProductId == li.ProductId) != null){                //does it exist
                        s.StoreLineItems.Find(x => x.ProductId == li.ProductId).Quantity += li.Quantity;    //add if it does
                        }else{s.StoreLineItems.Add(li); }                                                   //add if it doesn't
                    }
                    }   
                    o.Active = false;     
                } 
            }
            // Customer buying from store
            bool orderSuccess = true;
            if(c.CustomerOrders.Count > 0){
                Builder.ResetPause(c.ToStringList());
                foreach(Order o in  c.CustomerOrders){
                    if(o.Active){
                        foreach(LineItem li in o.OrderLineItems){
                            if(s.StoreLineItems.Find(x => x.ProductId == li.ProductId) != null){                        // if it exists,
                            if(s.StoreLineItems.Find(sli => sli.ProductId == li.ProductId).Quantity >= li.Quantity){    // if it has enough,
                                s.StoreLineItems.Find(sli => sli.ProductId == li.ProductId).Quantity -= li.Quantity;    // remove from store
                                s.Revenue += li.Total;                                                                  // add to store revenue 
                                c.TotalSpent += li.Total;                                                               // add to customer spent                                               
                            }else{
                                Builder.ResetPause(new List<string>()
                                    {"Sorry, we don't",
                                     "have enough of", 
                                    $"{li.LineProduct.Name}", 
                                    "to complete your order" }); 
                                orderSuccess = false;break;
                            }
                            }  
                        }
                    o.Active = !orderSuccess;
                    }
                
                }   
            }
            

            Current.customer = c;
            Current.storefront = s;
            BL.Update(Current.customer);
            BL.Update(Current.storefront);
            Builder.Pause("Thank you for shopping with us!");
            
        }

        public MenuType Choice(){return MenuType.Main;}
    }
}
