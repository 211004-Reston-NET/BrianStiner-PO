using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    class ShowAllProductsMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            List<Product> AllProducts = BL.GetAllClasses(new Product()); //"Products.json"
            List<string> menulines = new List<string>()
                {"Show all Products,"};
            foreach(Product c in AllProducts){
                foreach(string s in c.ToStringList()){
                    menulines.Add(s);
                }
                menulines.Add("  ----------  ");
            }
            menulines.Add("Press Enter to Continue...");
            
            Tools Builder = new Tools();
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            menulines = new List<string>(){
                "Products in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Products again."};
            
            Builder.BuildMenu(menulines);
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
