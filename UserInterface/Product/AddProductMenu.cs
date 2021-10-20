using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class AddProductMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();    
            var menulines = new List<string>()
                {"Fill in Product's info,",
                "What is the product's name?"};
            Builder.BuildMenu(menulines);
            string name = Console.ReadLine();
            menulines.Add(name);

            menulines.Add($"Describe {name}");
            Builder.BuildMenu(menulines);
            string description = Console.ReadLine();
            menulines.Add(description);
            
            menulines.Add($"What is {name}'s category?");
            Builder.BuildMenu(menulines);
            string category = Console.ReadLine();
            menulines.Add(category);

            menulines.Add($"How much does {name} cost?");
            Builder.BuildMenu(menulines);
            decimal price = Decimal.Parse(Console.ReadLine()); // How to convert string to decimal? Decimal.Parse()
            menulines.Add($"{price}");

            menulines.Add("Press Enter to Continue...");
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            Product newProduct = new Product(name, description, category, price);
            IBusiness BL = new Business();
            BL.AddClass(newProduct);

            menulines = new List<string>(){
                "Product Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Product"};
            
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
                    return MenuType.AddProduct;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
