using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteProductMenu : IMenu
    {

        //Ask for a string and search against all of the Product database to return a select List<Product>, show it, user selects one, modify that Product.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset();

            List<Product> SelectProducts = Builder.Search(new Product());

            Product OurProduct = Builder.ChooseClassFromList(SelectProducts);

            BL.DelClass(OurProduct);

            Builder.ShowAll(BL.GetAllClasses(OurProduct));

            Builder.Pause();

            Builder.Reset(new List<string>(){
                "Product Deleted!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Product"});
        }

        public MenuType Choice()
        {
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Product;
                case 1:
                    return MenuType.DeleteProduct;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.Main;
            }
            
        }

    }
}
