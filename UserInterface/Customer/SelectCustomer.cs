using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class SelectCustomerMenu : IMenu
    {

        //ask for a string and search against all of the Customer database to return a select List<Customer>, show it, user selects one, modify that customer.
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();
            Builder.Reset();

            //Search database for Customer list
            List<Customer> SelectCustomers = Builder.Search(new Customer());

            //Select Customer from search list
            Customer OurCustomer = Builder.ChooseClassFromList(SelectCustomers);

            Current.customer = OurCustomer;

            Builder.Pause();
            Builder.Reset(new List<string>(){
                "Current Customer Set!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Change Customer again"});
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
                    return MenuType.SelectCustomer;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.SelectCustomer;
            }
            
        }
    }
}