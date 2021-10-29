using System;
using System.Collections.Generic;
using BusinessLogic;
using Toolbox;

namespace UserInterface
{
    public class StorefrontMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public StorefrontMenu(IBusiness BL) {
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){
            Builder.Reset(new List<string>()
                {"Storefront Menu,",
                "What do you want to do?", 
                "[0] - Go back",
                "----------Database------------", 
                "[1] - Add Storefront", 
                "[2] - Delete a Storefront",
                "[3] - View all Storefronts",
                "----------Current-------------",
                "[4] - Select Storefront",
                "[5] - View Storefront",
                "[6] - Modify Storefront",});
        }

        public MenuType Choice(){

            switch (Builder.GetInt())
            {
                case 0:
                    return MenuType.Main;
                case 1:
                    return MenuType.AddStorefront;
                case 2:
                    return MenuType.DeleteStorefront; 
                case 3:
                    return MenuType.ShowAllStorefronts;
                case 4:
                    return MenuType.SelectStorefront;
                case 5:
                    return MenuType.ShowStorefront;
                case 6:
                    return MenuType.ModifyStorefront;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.Storefront;
            }
            
        }
    }
}
