using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class AddLineItemMenu : IMenu{
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();    
 
            Builder.Add("Fill in LineItem's info:");
            Builder.Add("What is their name?",'b');
            int quantity = Int32.Parse(Console.ReadLine());
            Builder.Pause($"{quantity}");

            LineItem newLineItem = new LineItem(quantity);
            BL.Add(newLineItem);

            Builder.Pause("LineItem Added!");
            
        }

        public MenuType Choice(){return MenuType.LineItem;}
            
    }
}
