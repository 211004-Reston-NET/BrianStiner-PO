using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteCustomerMenu : IMenu
    {

        //ask for a string and search against all of the Customer database to return a select List<Customer>, show it, user selects one, modify that customer.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset();

            List<Customer> SelectCustomers = Builder.Search(new Customer());     //Search database for string and get a Customer list

            Customer OurCustomer = Builder.ChooseClassFromList(SelectCustomers); //Select Customer from Customer list

            BL.Delete(OurCustomer);                                            //Delete Customer
    
            //Builder.ShowAll(BL.GetAllClasses(OurCustomer));                    //Show Customer database
        
            Builder.Pause("Customer deleted from database");                     //Reset menu for new menu selection

        /*/ Builder.Reset(new List<string>(){
                "Customer Deleted!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Delete another Customer"}); /*/
        }

        public MenuType Choice()
        {
            return MenuType.Customer;
            /*
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Customer;
                case 1:
                    return MenuType.DeleteCustomer;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.DeleteCustomer;
            }
            */
        }

    }
}
