using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface{
    public class LineItemMenu : IMenu{
        MenuBuilder Builder = new MenuBuilder();
        public void Display(){
            
            Builder.Reset(new List<string>()
                {"LineItem Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add LineItem", 
                "[2] - Delete a LineItem",
                "[3] - Modify a LineItem",
                "[4] - Show all LineItems"});
        }

        public MenuType Choice(){
            
            switch (Builder.GetInt()){
                case 0:
                    return MenuType.Main;
                case 1:
                    return MenuType.AddLineItem;
                case 2:
                    return MenuType.DeleteLineItem; 
                case 3:
                    return MenuType.ModifyLineItem; 
                case 4:
                    return MenuType.ShowAllLineItems;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.LineItem;
            }
            
        }
    }
}
