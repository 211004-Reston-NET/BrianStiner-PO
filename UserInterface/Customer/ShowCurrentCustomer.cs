using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowCurrentCustomerMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();

            Builder.Add("---Showing Current Customer---");
            Builder.Add("");
            Builder.Add(Current.customer.ToStringList());

            Builder.Pause();

            Builder.Reset(new List<string>(){
                "Current Customer shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Customer again."});

        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Customer;
                case "1":
                    return MenuType.ShowCurrentCustomer;
                default:
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}
