using System;
using System.Collections.Generic;
using Tools;
using Models;

namespace UserInterface
{
    class AddCustomerMenu : IMenu
    {
        public void Display()
        {
            var Builder = new Tools();    
            var menulines = new List<string>()
            {"Fill in Customer's info,",
            "What is their name?"};
            var name = Console.ReadLine();
            menulines.Add(name);

            menulines.Add("What is their address?");
            Builder.BuildMenu(menulines);
            var address = Console.ReadLine();
            menulines.Add(address);

            menulines.Add("What is their email?");
            Builder.BuildMenu(menulines);
            var email = Console.ReadLine();
            menulines.Add(email);

            menulines.Add("What is their phone number?");
            Builder.BuildMenu(menulines);
            var phoneNumber = Console.ReadLine();
            menulines.Add(phoneNumber);

            var continue = true;
            do
            {
                
            } while (continue);

            IClass newCustomer = new Customer(name, address, email, phoneNumber, desires);
            IBusiness BL = new Business();
            BL.AddIClass(IClass newCustomer);
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Main;
                case "1":
                    return MenuType.AddCustomer;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
