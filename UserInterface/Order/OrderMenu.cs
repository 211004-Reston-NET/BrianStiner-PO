using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class OrderMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            Builder.Reset(new List<string>()
                {"Order Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add Order", 
                "[2] - Delete a Order",
                "[3] - Modify a Order",
                "[4] - Show all Orders"});
        }

        public MenuType Choice()
        {
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
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
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}
