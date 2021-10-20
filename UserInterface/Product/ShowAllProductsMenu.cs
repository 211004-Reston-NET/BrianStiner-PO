using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowAllProductsMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            Tools Builder = new Tools();

            Builder.ShowAll(new Product());

            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Products in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Products again."});

        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Product;
                case "1":
                    return MenuType.ShowAllProducts;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
