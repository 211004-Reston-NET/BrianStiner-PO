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
            Tools Builder = new Tools();    
 
            Builder.Add("Fill in Order's info,");
            Builder.Add("Where is the Order from?",'b');
            string location = Console.ReadLine();
            Builder.Add(location);

            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Order newOrder = new Order(location);
            IBusiness BL = new Business();
            BL.AddClass(newOrder);

            Builder.Reset(new List<string>(){
                "Order Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Order"});
            
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
