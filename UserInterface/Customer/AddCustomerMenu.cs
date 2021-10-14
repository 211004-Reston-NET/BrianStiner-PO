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
            Customer newCustomer = new Customer();
            IBusiness BL = new Business();
            BL.AddIClass(newCustomer);

            List<string> menulines = new List<string>(){
                "Customer Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Customer"};
            
            var Builder = new Tools(); 
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
