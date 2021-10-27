using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class AddOrderMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public AddOrderMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){   
 
            Builder.Add("Fill in Order's info,");
            Builder.Add("Where is the Order from?",'b');
            string location = Builder.GetAddress();
            Builder.Add(location);

            Order newOrder = new Order(location);

            BL.Add(newOrder);

            Builder.Pause("Order Added!");
        }

        public MenuType Choice(){return MenuType.Order;}
        
            
        
    }
}
