using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class ModifyOrderMenu : IMenu
    {

        //ask for a string and search against all of the Order database to return a select List<Order>, show it, user selects one, modify that Order.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset();

        //Search database for Order list
            List<Order> SelectOrders = Builder.Search(new Order());
        //Select Order from list
            Order OurOrder = Builder.ChooseClassFromList(SelectOrders);

        //Modify Order
            bool repeat = false;
            BL.DelClass(OurOrder);
            do{
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Location"});

                string choice2 = Console.ReadLine();

                Builder.Add("What is the new value?",'b');
                string newvalue = Console.ReadLine();
                Builder.Add(newvalue);

                switch(choice2)
                {
                    case "1":
                        OurOrder.Location = newvalue;
                        break;
                    default:
                        break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {OurOrder.Location}?"});

                repeat = Builder.Choice();

            } while(repeat);
            BL.AddClass(OurOrder);

        //Reset display for new menu selection
            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Order Modified!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Order"});
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
                    return MenuType.ModifyOrder;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }

    }
}
