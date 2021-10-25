using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class StorefrontMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            Builder.Reset(new List<string>()
                {"Storefront Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add Storefront", 
                "[2] - Delete a Storefront",
                "[3] - Modify a Storefront",
                "[4] - Show all Storefronts"});
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
                    return MenuType.AddStorefront;
                case 2:
                    return MenuType.DeleteStorefront; 
                case 3:
                    return MenuType.ModifyStorefront; 
                case 4:
                    return MenuType.ShowAllStorefronts;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Storefront;
            }
            
        }
    }
}
