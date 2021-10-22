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
                "------ Database ------",
                "[1] - Add a Customer", 
                "[2] - Delete a Customer",
                "[3] - Modify a Customer",
                "[4] - Show all Customers",
                "------ Current  -------",
                "[5] - Select Customer",
                "[6] - Show Customer",
                "[7] - Create Order for Customer",
                "[8] - Delete Order from Customer"});
        }

        public MenuType Choice()
        {
            Tools Builder = new Tools();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Main;
                case 1:
                    return MenuType.AddCustomer;
                case 2:
                    return MenuType.DeleteCustomer; 
                case 3:
                    return MenuType.ModifyCustomer; 
                case 4:
                    return MenuType.ShowAllCustomers;
                case 5:
                    return MenuType.SelectCustomer;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Customer;
            }
            
        }
    }
}
