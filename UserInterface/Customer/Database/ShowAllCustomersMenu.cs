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
            MenuBuilder Builder = new MenuBuilder();

            List<Customer> Customers = BL.GetAll(new Customer());

            Builder.ShowAll(Customers);

            Builder.Pause();

         /*/   Builder.Reset(new List<string>(){
                "Customers in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Customers again."});/*/

        }

        public MenuType Choice()
        {
            return MenuType.Customer;
            
            
            /*MenuBuilder Builder = new MenuBuilder();
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
            }*/
            
        }
    }
}
