using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class AddOrderMenu : IMenu
    {
        public void Display()
        {
            var Builder = new Tools();    
            var menulines = new List<string>()
            {"Fill in Order's info,",
            "which store is the order from?"};
            string location = Console.ReadLine();
            menulines.Add(location);
    
            Order newOrder = new Order(location);
            IBusiness BL = new Business();
            BL.AddClass(newOrder);
        }


        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Order;
                case "1":
                    return MenuType.AddOrder;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}