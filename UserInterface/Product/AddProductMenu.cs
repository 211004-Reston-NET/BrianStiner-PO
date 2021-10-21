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
 
            Builder.Add("Fill in Product's info,");
            Builder.Add("What is their name?",'b');
            string name = Console.ReadLine();
            Builder.Add(name);

            Builder.Add("What is their Category?",'b');
            string category = Console.ReadLine();
            Builder.Add(category);

            Builder.Add("What is their Description?",'b');
            string description = Console.ReadLine();
            Builder.Add(description);

            Builder.Add("What is their price?",'b');
            decimal price = decimal.Parse(Console.ReadLine());
            Builder.Add("${price}");

            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Product newProduct = new Product(name, category, description, price);
            IBusiness BL = new Business();
            BL.AddClass(newProduct);

            Builder.Reset(new List<string>(){
                "Product Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Product"});
            
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
                    Tools Builder = new Tools();
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.Main;
            }
            
        }
    }
}
