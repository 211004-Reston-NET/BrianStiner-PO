using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class ModifyStorefrontMenu : IMenu{
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset();

            do{
                
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Name",
                    "[2] - Address"});

                int choice = Builder.GetInt();
                Builder.Add(choice.ToString());

                Builder.Add("What is the new value?",'b');
                string newvalue = Builder.GetString();
                Builder.Add(newvalue);

                switch(choice){
                    case 1:
                        Current.storefront.Name = newvalue;     break;
                    case 2:
                        Current.storefront.Address = newvalue;  break;
                    default:                                    break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {Current.storefront.Name}?"});

            } while(Builder.Choice());

            Builder.Pause(); // Pause for the user to read the menu.
        }

        public MenuType Choice(){return MenuType.Storefront;}

    }
}
