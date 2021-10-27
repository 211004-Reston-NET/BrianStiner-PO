using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class DeleteStorefrontMenu : IMenu{

        
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            
            List<Storefront> SelectStorefronts = Builder.Search(new Storefront());      //Search database for Storefront list

            Storefront OurStorefront = Builder.ChooseClassFromList(SelectStorefronts);  //Select Storefront from list

            BL.Delete(OurStorefront);                                                 //Delete Storefront from database

            Builder.Pause("Storefront deleted!");                                      //Reset menu for new menu selection

        }

        public MenuType Choice(){return MenuType.Storefront;}

    }
}
