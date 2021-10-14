using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    class AddStorefrontMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();    
            var menulines = new List<string>()
                {"Fill in Storefront's info,",
                "What is the store's name?"};
            Builder.BuildMenu(menulines);
            string name = Console.ReadLine();
            menulines.Add(name);

            menulines.Add($"Whats the address for {name}?");
            Builder.BuildMenu(menulines);
            string address = Console.ReadLine();
            menulines.Add(address);

            menulines.Add("Press Enter to Continue...");
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            Storefront newStorefront = new Storefront(name, address);
            IBusiness BL = new Business();
            BL.AddClass(newStorefront);

            menulines = new List<string>(){
                "Storefront Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Storefront"};
            
            Builder.BuildMenu(menulines);
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Storefront;
                case "1":
                    return MenuType.AddStorefront;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
