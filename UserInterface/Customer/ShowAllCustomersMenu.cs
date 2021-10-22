using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowAllCustomersMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            Tools Builder = new Tools();

            List<Customer> Customers = BL.GetAllClasses(new Customer());

            Builder.ShowAll(Customers);

            Builder.Pause();

            Builder.Reset(new List<string>(){
                "Customers in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Customers again."});

        }

        public MenuType Choice()
        {
            Tools Builder = new Tools();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Customer;
                case 1:
                    return MenuType.ShowAllCustomers;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.ShowAllCustomers;
            }
            
        }
    }
}
