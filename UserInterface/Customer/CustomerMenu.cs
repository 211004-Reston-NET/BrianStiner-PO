using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class CustomerMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            Builder.Reset(new List<string>()
                {"Customer Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "------ Database ------",
                "[1] - Add a Customer", 
                "[2] - Delete a Customer",
                "[3] - Show all Customers",
                "------ Current  -------",
                "[4] - Select Customer",
                "[5] - Modify Customer",
                "[6] - Show Customer",
                "[7] - Create Order for Customer",
                "[8] - Delete Order from Customer"});
        }

        public MenuType Choice()
        {
            MenuBuilder Builder = new MenuBuilder();
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
                    return MenuType.ShowAllCustomers; 
                case 4:
                    return MenuType.SelectCustomer;
                case 5:
                    return MenuType.ModifyCustomer;
                case 6:
                    return MenuType.ShowCurrentCustomer;
                case 7:
                //    return MenuType.CreateOrder;
                case 8:
                //    return MenuType.DeleteCurrentOrder;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.Customer;
            }
            
        }
    }
}
