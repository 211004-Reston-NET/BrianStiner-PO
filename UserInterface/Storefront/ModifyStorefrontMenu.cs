using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class ModifyStorefrontMenu : IMenu
    {

        //ask for a string and search against all of the Storefront database to return a select List<Storefront>, show it, user selects one, modify that Storefront.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset();

        //Search database for Storefront list
            List<Storefront> SelectStorefronts = Builder.Search(new Storefront());
        //Select Storefront from list
            Storefront OurStorefront = Builder.ChooseClassFromList(SelectStorefronts);

        //Modify Storefront
            bool repeat = false;
            BL.DelClass(OurStorefront);
            do{
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Name",
                    "[2] - Address"});

                string choice2 = Console.ReadLine();

                Builder.Add("What is the new value?",'b');
                string newvalue = Console.ReadLine();
                Builder.Add(newvalue);

                switch(choice2)
                {
                    case "1":
                        OurStorefront.Name = newvalue;
                        break;
                    case "2":
                        OurStorefront.Address = newvalue;
                        break;
                    default:
                        break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {OurStorefront.Name}?"});

                repeat = Builder.Choice();

            } while(repeat);
            BL.AddClass(OurStorefront);

            //Reset display for new menu selection
            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Storefront Modified!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Storefront"});
        }

        public MenuType Choice()
        {
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Storefront;
                case 1:
                    return MenuType.ModifyStorefront;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.ModifyStorefront;
            }
            
        }

    }
}
