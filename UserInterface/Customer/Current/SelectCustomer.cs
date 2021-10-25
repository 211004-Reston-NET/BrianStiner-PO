using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class SelectCustomerMenu : IMenu
    {

        //Calls Search and Select from builder, then sets CurrentCustomer to the selected customer
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
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
        {   return MenuType.Customer;
         /*/   MenuBuilder Builder = new MenuBuilder();
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
            }/*/
            
        }
    }
}