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
            MenuBuilder Builder = new MenuBuilder();    
 
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
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Order;
                case 1:
                    return MenuType.AddOrder;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}
