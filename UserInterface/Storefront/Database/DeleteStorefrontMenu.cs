using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class DeleteStorefrontMenu : IMenu{
        IBusiness BL;
        MenuBuilder Builder;
        public DeleteStorefrontMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){
            
            List<Storefront> SelectStorefronts = Builder.Search(new Storefront());      //Search database for Storefront list

            Storefront OurStorefront = Builder.Select(SelectStorefronts);               //Select Storefront from list

            BL.Delete(OurStorefront);                                                   //Delete Storefront from database

            Builder.Pause("Storefront deleted!");                                       //Reset menu for new menu selection

        }

        public MenuType Choice(){return MenuType.Storefront;}

    }
}
