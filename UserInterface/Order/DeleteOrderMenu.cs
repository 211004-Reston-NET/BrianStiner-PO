using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteOrderMenu : IMenu
    {

        //ask for a string and search against all of the Order database to return a select List<Order>, show it, user selects one, modify that Order.
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();
            Builder.Reset();

        //Search database for Order list
            List<Order> SelectOrders = Builder.Search(new Order());

        //Select Order from list
            Order OurOrder = Builder.ChooseClassFromList(SelectOrders);

        //Delete Order
            BL.DelClass(OurOrder);

        //Show Order database
            Builder.ShowAll(new Order());

            //Reset menu for new menu selection
            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Order Deleted!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Order"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Order;
                case "1":
                    return MenuType.DeleteOrder;
                default:
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }

    }
}
