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
            var CC = Current.customer;
            
            do{    
                newOrder = Builder.CreateOrder(CC.Address);
                CC.CustomerOrders.Add(newOrder);
                Builder.Add("Would you like to add another order?");
            }while(Builder.Choice());

            BL.Update(CC);

            Builder.Pause($"{CC.Name}'s Order created!");
        }
        public MenuType Choice(){return MenuType.Customer;}
    }
}