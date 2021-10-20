using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteProductMenu : IMenu
    {

        //ask for a string and search against all of the Product database to return a select List<Product>, show it, user selects one, modify that Product.
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();
            Builder.Reset();

        //Search database for Product list
            List<Product> SelectProducts = Builder.Search(new Product());

        //Select Product from list
            Product OurProduct = Builder.ChooseClassFromList(SelectProducts);

        //Delete Product
            BL.DelClass(OurProduct);

        //Show Product database
            Builder.ShowAll(new Product());

            //Reset menu for new menu selection
            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Product Deleted!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Product"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Product;
                case "1":
                    return MenuType.DeleteProduct;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }

    }
}
