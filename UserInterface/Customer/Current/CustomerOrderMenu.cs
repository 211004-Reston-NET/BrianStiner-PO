using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
using Toolbox;

namespace UserInterface{
    class CustomerOrderMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public CustomerOrderMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        
        public void Display(){

            Order newOrder = new Order();
            do{ 
                if(Current.storefront.Name == null || Current.storefront.Name == ""){
                    Builder.ResetPause("Please select a storefront for you Order.");
                    Current.storefront = Builder.SearchAndSelect(Current.storefront);}
                    
                newOrder = Builder.CreateOrder(Current.storefront.Name);

                Current.customer.CustomerOrders.Add(newOrder);
                Builder.Reset("Would you like to add another order?");
            }while(Builder.Choice());

            Builder.ResetPause($"{Current.customer.Name}'s Order created!");
            BL.Update(Current.customer);
        }
        public MenuType Choice(){return MenuType.Customer;}
    }
}