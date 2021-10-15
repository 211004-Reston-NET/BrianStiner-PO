using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    class SearchCustomerMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();  
            List<Customer> AllCustomers = BL.GetAllClasses(new Customer());  
            List<Customer> SelectCustomers = new List<Customer>();  

            var menulines = new List<string>()
                {"What do you want to search by?",
                "[1] - name",
                "[2] - address",
                "[3] - email",
                "[4] - phone number"};
            Builder.BuildMenu(menulines);
            string choice = Console.ReadLine();
            menulines.Add(choice);

            switch (choice)
            {
                case {"name", "Name", "1", "NAME"}:
                    break;
                case {"address", "Address", "2", "ADDRESS"}:
                    break;
                case {"email", "Email", "3", "e-mail", "EMAIL", "E-mail"}:
                    break;
                case {"phone", "Phone", "PHONE", "4", "phonenumber", "phone number", "Phone number", "Phone Number", "PHONE NUMBER"}:
                    break;
                default:
                    Console.WriteLine("That wasn't a choice. ");
                    break;
            }


            menulines.Add("Press Enter to Continue...");
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            Customer newCustomer = new Customer(name, address, email, phoneNumber);
            IBusiness BL = new Business();
            BL.AddClass(newCustomer);

            menulines = new List<string>(){
                "Customer Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Customer"};
            
            Builder.BuildMenu(menulines);
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Customer;
                case "1":
                    return MenuType.AddCustomer;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
