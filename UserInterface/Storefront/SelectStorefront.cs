using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class SelectStorefrontMenu : IMenu
    {

        //ask for a string and search against all of the   Storefront database to return a select List<  Storefront>, show it, user selects one, modify that   Storefront.
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();
            Builder.Reset();

            //Search database for Storefront list
            List<  Storefront> SelectStorefronts = Builder.Search(new Storefront());

            //Select Storefront from search list
            Storefront OurStorefront = Builder.ChooseClassFromList(SelectStorefronts);

            Current.storefront = OurStorefront;

            Builder.Pause();
            Builder.Reset(new List<string>(){
                "Current Storefront Set!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Change Storefront again"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Storefront;
                case "1":
                    return MenuType.SelectStorefront;
                default:
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}