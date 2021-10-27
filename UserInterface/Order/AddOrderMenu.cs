using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class AddOrderMenu : IMenu{
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();    
 
            Builder.Add("Fill in Order's info,");
            Builder.Add("Where is the Order from?",'b');
            string location = Builder.GetAddress();
            Builder.Add(location);

            Order newOrder = new Order(location);
            IBusiness BL = new Business();
            BL.Add(newOrder);

            Builder.Pause("Order Added!");
        }

        public MenuType Choice(){return MenuType.Order;}
        
            
        
    }
}
