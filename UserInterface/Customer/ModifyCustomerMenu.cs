using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class ModifyCustomerMenu : IMenu
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

            //Modify Customer
            bool repeat = false;
            BL.DelClass(OurCustomer);
            do{
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Name",
                    "[2] - Address",
                    "[3] - Email",
                    "[4] - Phone Number"},'f');

                string choice2 = Console.ReadLine();

                Builder.Add("What is the new value?",'b');
                string newvalue = Console.ReadLine();
                Builder.Add(newvalue);

                switch(choice2)
                {
                    case "1":
                        OurCustomer.Name = newvalue;
                        break;
                    case "2":
                        OurCustomer.Address = newvalue;
                        break;  
                    case "3":
                        OurCustomer.Email = newvalue;
                        break;
                    case "4":
                        OurCustomer.PhoneNumber = newvalue;
                        break;
                    default:
                        break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {OurCustomer.Name}?"},'f');

                repeat = Builder.Choice();

            } while(repeat);
            BL.AddClass(OurCustomer);

             //Reset display for new menu selection
            Builder.Pause();

            Builder.Reset(new List<string>(){
                "Customer Modified!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Customer"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Customer;
                case "1":
                    return MenuType.ModifyCustomer;
                default:
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }

    }
}
