using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class ModifyLineItemMenu : Menu{
        IBusiness BL; MenuBuilder Builder;
        public ModifyLineItemMenu(IBusiness BL, MenuBuilder Builder){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }

        //ask for a string and search against all of the LineItem database to return a select List<LineItem>, show it, user selects one, modify that LineItem.
        public void Display(){

            LineItem OurLineItem = Builder.SearchAndSelect(new LineItem());//Search database for LineItem list//Select LineItem from list
            if (OurLineItem != null){
                Builder.Add("Enter Quantity: ");
                OurLineItem.Quantity = Builder.GetInt();
                BL.Update(OurLineItem);
            }else{
                Builder.Add("No LineItem found.");
            }
            Builder.Pause($"{OurLineItem.LineProduct.Name}'s LineItem modified.");
        }
        public MenuType Choice(){return MenuType.LineItem;}

    }
}
            

