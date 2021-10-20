using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class StorefrontMenu : IMenu
    {
        public void Display()
        {
            
            List<string> menulines = new List<string>()
                {"Storefront Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add Storefront", 
                "[2] - Show all Storefronts"};
            Tools Builder = new Tools();
            Builder.BuildMenu(menulines);
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Main;
                case "1":
                    return MenuType.AddStorefront;
                case "2":
                    return MenuType.ShowAllStorefronts;  
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
