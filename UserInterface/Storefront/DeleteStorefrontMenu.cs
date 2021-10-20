using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteStorefrontMenu : IMenu
    {

        //ask for a string and search against all of the Storefront database to return a select List<Storefront>, show it, user selects one, modify that Storefront.
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();
            Builder.Reset();

        //Search database for Storefront list
            List<Storefront> SelectStorefronts = Builder.Search(new Storefront());

        //Select Storefront from list
            Storefront OurStorefront = Builder.ChooseClassFromList(SelectStorefronts);

        //Delete Storefront
            BL.DelClass(OurStorefront);

        //Show Storefront database
            Builder.ShowAll(new Storefront());

            //Reset menu for new menu selection
            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Storefront Deleted!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Storefront"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Storefront;
                case "1":
                    return MenuType.DeleteStorefront;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }

    }
}
