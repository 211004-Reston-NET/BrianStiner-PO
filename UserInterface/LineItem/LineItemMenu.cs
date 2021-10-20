using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class AddLineItemMenu : IMenu
    {
        AddLineItemMenu(){}
        public void Display()
        {
            var Builder = new Tools();    
            var menulines = new List<string>()
            {"Choose a product and a quantity"};
            
            Product newProduct = new Product();
            int quantity = Int32.Parse(Console.ReadLine());

            LineItem newLineItem = new LineItem(quantity, newProduct);

            IBusiness BL = new Business();
            BL.AddClass(newLineItem);
            
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
