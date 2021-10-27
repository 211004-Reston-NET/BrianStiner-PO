using System;
using System.Collections.Generic;
using BusinessLogic;
using Toolbox;

namespace UserInterface{
    public class OrderMenu : IMenu{
        MenuBuilder Builder; IBusiness BL;
        public OrderMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){
            Builder.Reset(new List<string>()
                {"Order Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add Order", 
                "[2] - Delete a Order",
                "[3] - Modify a Order",
                "[4] - Show all Orders"});
        }

        public MenuType Choice(){
            switch (Builder.GetInt())
            {
                case 0:
                    return MenuType.Main;
                case 1:
                    return MenuType.AddOrder;
                case 2:
                    return MenuType.DeleteOrder; 
                case 3:
                    return MenuType.ModifyOrder; 
                case 4:
                    return MenuType.ShowAllOrders;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.Main;
            }
            
        }
    }
}
