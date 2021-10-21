using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class CustomerMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();
            Builder.Reset(new List<string>()
                {"Customer Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add Customer", 
                "[2] - Delete a Customer",
                "[3] - Modify a Customer",
                "[4] - Show all Customers"});
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
                    return MenuType.DeleteCustomer; 
                case "3":
                    return MenuType.ModifyCustomer; 
                case "4":
                    return MenuType.ShowAllCustomers;
                default:
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}
