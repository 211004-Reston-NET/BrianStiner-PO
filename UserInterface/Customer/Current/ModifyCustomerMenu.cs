using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class ModifyCustomerMenu : IMenu
    {

        // This should instead modify Current Customer.
        //ask for a string and search against all of the Customer database to return a select List<Customer>, show it, user selects one, modify that customer.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset(Current.customer.ToStringList());

            //Modify Customer
            bool repeat = false;
            do{
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Name",
                    "[2] - Address",
                    "[3] - Email",
                    "[4] - Phone Number"},'f');

                int choice = Builder.GetInt();

                switch(choice)
                {
                    case 1:
                        Current.customer.Name = Builder.GetString();
                        break;
                    case 2:
                        Current.customer.Address = Builder.GetString();
                        break;  
                    case 3:
                        Current.customer.Email = Builder.GetEmail();
                        break;
                    case 4:
                        Current.customer.PhoneNumber = Builder.GetPhoneNumber();
                        break;
                    default:
                        break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {Current.customer.Name}?"},'f');

                repeat = Builder.Choice();

            } while(repeat);

            
            
            //Reset display for new menu selection
            Builder.Pause();

         /*/   Builder.Reset(new List<string>(){
                "Customer Modified!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Change another Customer"});/*/
        }

        public MenuType Choice()
        {   return MenuType.Customer;
        /*/    MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Customer;
                case 1:
                    return MenuType.ModifyCustomer;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.ModifyCustomer;
            }/*/
            
        }

    }
}
