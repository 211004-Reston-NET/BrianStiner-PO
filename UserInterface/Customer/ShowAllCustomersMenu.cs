/*
Server=tcp:revature-database-server.database.windows.net,1433;Initial Catalog=revature-database;Persist Security Info=False;User ID=a-dmin;Password=FDFwhjnXM5Rx!L4;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
*/
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
            Tools Builder = new Tools();

            List<Customer> Customers = BL.GetAllClasses(new Customer());

            Builder.ShowAll(Customers);

            Builder.Pause();

            Builder.Reset(new List<string>(){
                "Customers in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Customers again."});

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
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}
