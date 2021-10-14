using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    class ShowAllCustomersMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            List<IClass> AllCustomers = BL.GetAllIClasses(new Customer("anon").Identify()); //"Customers.json"
            List<string> menulines = new List<string>()
                {"Show all Customers,"};
            foreach(IClass c in AllCustomers){
                foreach(string s in c.ToStringList()){
                    menulines.Add(s);
                }
                menulines.Add("  ----------  ");
            }
            Tools Builder = new Tools();
            menulines.Add("Press Enter to Continue...");
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            menulines.Add("What do you want to do?"); 
            menulines.Add("[0] - Go back"); 
            menulines.Add("[1] - Show Again");
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
