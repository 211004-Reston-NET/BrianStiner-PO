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

            Order freshOrder = new Order();
            do{    
                freshOrder = Builder.CreateOrder();
                Current.customer.CustomerOrders.Add(freshOrder);
                Builder.Add("Would you like to add another order?");
            }while(Builder.Choice());
            BL.Update(Current.customer);
         

            Builder.Reset(new List<string>(){
                "Welcome to the Create Order Menu",
                "[0] - Go Back"
            });
        }
        public MenuType Choice(){return MenuType.Customer;}
    }
}