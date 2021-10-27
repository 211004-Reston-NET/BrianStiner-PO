using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface{
    public class ShowAllCustomersMenu : IMenu{
        public void Display(){
            IBusiness BL = new Business();
            MenuBuilder Builder = new MenuBuilder();

            Builder.ShowAll(BL.GetAll(new Customer()));

            Builder.Pause();
        }
        public MenuType Choice(){return MenuType.Customer;}
    }
}
