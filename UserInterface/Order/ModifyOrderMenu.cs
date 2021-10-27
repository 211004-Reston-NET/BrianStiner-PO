using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class ModifyOrderMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public ModifyOrderMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }

        //ask for a string and search against all of the Order database to return a select List<Order>, show it, user selects one, modify that Order.
        public void Display(){
            Builder.Reset();

        //Search database for Order list
            List<Order> SelectOrders = Builder.Search(new Order());
        //Select Order from list
            Order OurOrder = Builder.Select(SelectOrders);

        //Modify Order
            bool repeat = false;
            BL.Delete(OurOrder);
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
            BL.Add(OurOrder);

            Builder.Pause("Order Modified!");
        }

        public MenuType Choice(){return MenuType.Order;}
            

    }
}
