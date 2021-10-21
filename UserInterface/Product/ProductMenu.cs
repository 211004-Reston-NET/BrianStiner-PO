using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class ProductMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();
            Builder.Reset(new List<string>()
                {"Product Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add Product", 
                "[2] - Delete a Product",
                "[3] - Modify a Product",
                "[4] - Show all Products"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Main;
                case "1":
                    return MenuType.AddProduct;
                case "2":
                    return MenuType.DeleteProduct; 
                case "3":
                    return MenuType.ModifyProduct; 
                case "4":
                    return MenuType.ShowAllProducts;
                default:
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}
