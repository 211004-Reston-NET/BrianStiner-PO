using System;
using System.Collections.Generic;
using Tools;

namespace UserInterface
{
    class CustomerMenu : IMenu
    {
        public void Display()
        {
            var menulines = new List<string>()
                {"Customer Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add Customer", 
                "[2] - Show all Customers"};
            Tools builder = new Tools.buildmenu(menulines);
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
                case "2":
                    return MenuType.ShowAllCustomers;  
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
