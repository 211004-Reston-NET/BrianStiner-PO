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
                "[1] - Add Storefront", 
                "[2] - Delete a Storefront",
                "[3] - Modify a Storefront",
                "[4] - Show all Storefronts"});
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
                    return MenuType.ModifyStorefront; 
                case 4:
                    return MenuType.ShowAllStorefronts;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.Storefront;
            }
            
        }
    }
}
