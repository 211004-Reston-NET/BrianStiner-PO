using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class DeleteLineItemMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public DeleteLineItemMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }

        //ask for a string and search against all of the LineItem database to return a select List<LineItem>, show it, user selects one, modify that LineItem.
        public void Display(){

            LineItem OurLineItem = Builder.SearchAndSelect(new LineItem()); //Search database for LineItem list//Select LineItem from list

            BL.Delete(OurLineItem);                                         //Delete LineItem

            Builder.Pause("LineItem Deleted!");
        }

        public MenuType Choice(){return MenuType.LineItem;}
        
            
    }

}

