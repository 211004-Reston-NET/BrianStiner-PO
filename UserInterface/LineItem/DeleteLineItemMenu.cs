using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteLineItemMenu : IMenu
    {

        //ask for a string and search against all of the LineItem database to return a select List<LineItem>, show it, user selects one, modify that LineItem.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();

            LineItem OurLineItem = Builder.SearchAndSelect(new LineItem()); //Search database for LineItem list//Select LineItem from list

            BL.Delete(OurLineItem);                                         //Delete LineItem

            Builder.Pause("LineItem Deleted!");
        }

        public MenuType Choice(){return MenuType.LineItem;}
        
            
    }

}

