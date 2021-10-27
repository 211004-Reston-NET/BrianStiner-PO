using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface{
    public class ShowAllLineItemsMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public ShowAllLineItemsMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){

            Builder.ShowAll(BL.GetAll(new LineItem()));

            Builder.Pause("LineItems in database shown!");
        }

        public MenuType Choice(){return MenuType.LineItem;}
        
    }
}
