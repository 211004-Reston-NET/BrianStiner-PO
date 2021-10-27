using System;
using System.Collections.Generic;
using Toolbox;
using Models;

namespace UserInterface{
    public class ShowCurrentCustomerMenu : IMenu{
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();

            Builder.Add("---Showing Current Customer---");
            Builder.Add();
            Builder.Add(Current.customer.ToStringList());

            Builder.Pause($"{Current.customer.Name} shown!");
        }

        public MenuType Choice(){return MenuType.Customer;}
    }
}
