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
            List<Customer> AllCustomers = BL.GetAllClasses(new Customer());
            List<string> menulines = new List<string>()
                {"Show all Customers,"};
            foreach(Customer c in AllCustomers){
                foreach(string s in c.ToStringList()){
                    menulines.Add(s);
                }
                menulines.Add("  ----------  ");
            }
            menulines.Add("Press Enter to Continue...");

            Tools Builder = new Tools();
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            menulines = new List<string>(){
                "Customers in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Customers again."};
            
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
                    return MenuType.ShowAllCustomers;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
