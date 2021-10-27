using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class SelectStorefrontMenu : IMenu{

        //Search database for Storefront list, Select Storefront from search list, Assign to Current.storefront
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();
            
            Current.storefront = Builder.SearchAndSelect(new Storefront());  

            Builder.Pause($"Store set to {Current.storefront.Name}!");
        }

        public MenuType Choice(){return MenuType.Storefront;}
    }
}