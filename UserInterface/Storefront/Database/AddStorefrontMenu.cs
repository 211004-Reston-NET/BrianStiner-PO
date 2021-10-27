using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class AddStorefrontMenu : IMenu{
        IBusiness BL;
        MenuBuilder Builder;
        public AddStorefrontMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){   
 
            Builder.Add("Fill in Storefront's info:");
            Builder.Add("What is their name?",'b');
            string name = Console.ReadLine();
            Builder.Add(name);

            Builder.Add("What is their address?",'b');
            string address = Console.ReadLine();
            Builder.Add(address);


            Storefront newStorefront = new Storefront(name, address);

            BL.Add(newStorefront);

            Builder.Pause("Storefront added!");
        }

        public MenuType Choice(){return MenuType.Storefront;}   
    }
}
