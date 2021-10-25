using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class MainMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            Builder.Reset(new List<string>()
                {"Welcome to the Main Menu,",
                "Which menu do you want?",
                "[0] - Exit", 
                "[1] - Customers", 
                "[2] - Storefronts", 
                "[3] - Products"});
        }

        public MenuType Choice()
            {
                MenuBuilder Builder = new MenuBuilder();
                int userChoice = Builder.GetInt();
                switch (userChoice)
                {
                    case 1:
                        return MenuType.Customer;
                    case 2:
                        return MenuType.Storefront;
                    case 3:
                        return MenuType.Product;
                    case 0:
                        return MenuType.Exit;
                    default:
                        Builder.Add("Not a choice. Try again.",1);
                        return MenuType.Main;
                }
            }
    }
}
