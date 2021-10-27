using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowAllOrdersMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            MenuBuilder Builder = new MenuBuilder();

            Builder.ShowAll(BL.GetAll(new Order()));

            Builder.Pause();

            Builder.Reset(new List<string>(){
                "Orders in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Orders again."});

        }

        public MenuType Choice()
        {
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Order;
                case 1:
                    return MenuType.ShowAllOrders;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.Main;
            }
            
        }
    }
}
