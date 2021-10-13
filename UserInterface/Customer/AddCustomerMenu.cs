using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

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
            string name = Console.ReadLine();
            menulines.Add(name);

            menulines.Add("What is their address?");
            Builder.BuildMenu(menulines);
            string address = Console.ReadLine();
            menulines.Add(address);

            menulines.Add("What is their email?");
            Builder.BuildMenu(menulines);
            string email = Console.ReadLine();
            menulines.Add(email);

            menulines.Add("What is their phone number?");
            Builder.BuildMenu(menulines);
            string phoneNumber = Console.ReadLine();
            menulines.Add(phoneNumber);

            IClass newCustomer = new Customer(name, address, email, phoneNumber);
            IBusiness BL = new Business();
            BL.AddIClass(newCustomer);

            menulines.Add("Customer Added!");
            menulines.Add("---------------");
            menulines.Add("What do you want to do?");
            menulines.Add("[0] - Go back");
            menulines.Add("[1] - Add another Customer");
            Builder.BuildMenu(menulines);
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Customer;
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
