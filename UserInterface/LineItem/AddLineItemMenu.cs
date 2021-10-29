using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class AddLineItemMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public AddLineItemMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){ 
 
            Builder.Add("Fill in LineItem's info:");
            Builder.Add("What is the Product?",'b');

            Product OurProduct = Builder.SearchAndSelect(new Product());

            Builder.Add("How many of this product are there?",'b');
            int quantity = Builder.GetInt();

            LineItem newLineItem = new LineItem(quantity, OurProduct);
            BL.Add(newLineItem);

            Builder.Pause("LineItem Added!");
            
        }

        public MenuType Choice(){return MenuType.LineItem;}
            
    }
}
