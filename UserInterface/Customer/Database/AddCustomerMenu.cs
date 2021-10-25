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
            string name = Builder.GetString();
            Builder.Add(name);

            Builder.Add("What is their address?",'b');
            string address = Builder.GetAddress();
            Builder.Add(address);

            Builder.Add("What is their email?",'b');
            string email = Builder.GetEmail();
            Builder.Add(email);

            Builder.Add("What is their phone number?",'b');
            string phoneNumber = Builder.GetPhoneNumber();
            Builder.Add(phoneNumber);

            Customer newCustomer = new Customer(name, address, email, phoneNumber);
            IBusiness BL = new Business();
            BL.AddClass(newCustomer);

            Builder.Pause("Customer added to database.");
        }

        public MenuType Choice(){return MenuType.Customer;}
        
    }
}
