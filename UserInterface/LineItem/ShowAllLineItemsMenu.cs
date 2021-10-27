using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface{
    public class ShowAllLineItemsMenu : IMenu{
        public void Display(){
            IBusiness BL = new Business();
            MenuBuilder Builder = new MenuBuilder();

            Builder.ShowAll(BL.GetAll(new LineItem()));

            Builder.Pause("LineItems in database shown!");
        }

        public MenuType Choice(){return MenuType.LineItem;}
        
    }
}
