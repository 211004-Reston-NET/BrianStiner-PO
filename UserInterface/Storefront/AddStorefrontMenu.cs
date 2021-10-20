using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class AddStorefrontMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();    
 
            Builder.Add("Fill in Storefront's info,");
            Builder.Add("What is their name?",'b');
            string name = Console.ReadLine();
            Builder.Add(name);

            Builder.Add("What is their address?",'b');
            string address = Console.ReadLine();
            Builder.Add(address);

            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Storefront newStorefront = new Storefront(name, address);
            IBusiness BL = new Business();
            BL.AddClass(newStorefront);

            Builder.Reset(new List<string>(){
                "Storefront Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Storefront"});
            
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
