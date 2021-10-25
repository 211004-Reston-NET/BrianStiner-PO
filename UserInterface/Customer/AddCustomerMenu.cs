using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class AddCustomerMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();    
 
            Builder.Add("Fill in Customer's info,");
            Builder.Add("What is their name?",'b');
            string name = Console.ReadLine();
            Builder.Add(name);

            Builder.Add("What is their address?",'b');
            string address = Console.ReadLine();
            Builder.Add(address);

            Builder.Add("What is their email?",'b');
            string email = Console.ReadLine();
            Builder.Add(email);

            Builder.Add("What is their phone number?",'b');
            string phoneNumber = Console.ReadLine();
            Builder.Add(phoneNumber,1);

            Customer newCustomer = new Customer(name, address, email, phoneNumber);
            IBusiness BL = new Business();
            BL.AddClass(newCustomer);

            Builder.Reset(new List<string>(){
                "Customer Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Customer"});
            
        }

        public MenuType Choice()
        {
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Customer;
                case 1:
                    return MenuType.AddCustomer;
                default:
                    Builder.Add("Not a choice. Try again.");
                    Builder.Pause();
                    return MenuType.Main;
            }
            
        }
    }
}
