using System;
using System.Collections.Generic;
using BusinessLogic;
using Models;
using Toolbox;

namespace UserInterface{
    class CreateOrderMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public CreateOrderMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        
        public void Display(){
            Builder.Reset(new List<string>(){
                "Welcome to the Create Order Menu",
                "[0] - Go Back"
            });
        }
        public MenuType Choice(){return MenuType.Customer;}
    }
}