using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class ModifyStorefrontMenu : IMenu{
        public void Display(){
            MenuBuilder Builder = new MenuBuilder();

            do{
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Name",
                    "[2] - Address"});

                int choice = Builder.GetInt();
                Builder.Add(choice.ToString());

                switch(choice){
                    case 1:
                        Current.storefront.Name = Builder.GetString();      break;
                    case 2:
                        Current.storefront.Address = Builder.GetAddress();  break;
                    default:                                                
                        Builder.Reset(new List<string>(){
                            $"Invalid choice. Only 1 and 2 work.",
                            $"{Current.storefront.Name} has not been updated.",
                            $"Please try again."});
                        break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {Current.storefront.Name}?"});

            } while(Builder.Choice());

            Builder.Pause($"{Current.storefront.Name} has been updated!");
        }

        public MenuType Choice(){return MenuType.Storefront;}

    }
}
