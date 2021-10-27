using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class AddStorefrontMenu : IMenu{
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();    
 
            Builder.Add("Fill in Storefront's info:");
            Builder.Add("What is their name?",'b');
            string name = Console.ReadLine();
            Builder.Add(name);

            Builder.Add("What is their address?",'b');
            string address = Console.ReadLine();
            Builder.Add(address);


            Storefront newStorefront = new Storefront(name, address);

            IBusiness BL = new Business();
            BL.Add(newStorefront);

            Builder.Pause("Storefront added!");
        }

        public MenuType Choice(){return MenuType.Storefront;}   
    }
}
