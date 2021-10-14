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
            Tools Builder = new Tools();    
            var menulines = new List<string>()
                {"Fill in Customer's info,",
                "What is their name?"};
            Builder.BuildMenu(menulines);
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

            menulines.Add("Press Enter to Continue...");
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            Customer newCustomer = new Customer(name, address, email, phoneNumber);
            IBusiness BL = new Business();
            BL.AddClass(newCustomer);

            menulines = new List<string>(){
                "Customer Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Customer"};
            
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
