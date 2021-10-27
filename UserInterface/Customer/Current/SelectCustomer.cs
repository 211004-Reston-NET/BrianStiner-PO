using System;
using System.Collections.Generic;
using Toolbox;
using Models;

namespace UserInterface{
    public class SelectCustomerMenu : IMenu{

        //Calls Search and Select from builder, then sets CurrentCustomer to the selected customer
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();

            Customer OurCustomer = Builder.SearchAndSelect(new Customer());

            Current.customer = OurCustomer;

            Builder.Pause($"Customer is now {Current.customer.Name}!");
        }
        public MenuType Choice(){return MenuType.Customer;}
    }
}