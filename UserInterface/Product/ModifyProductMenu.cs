using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class ModifyProductMenu : IMenu
    {

        //ask for a string and search against all of the Product database to return a select List<Product>, show it, user selects one, modify that Product.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset();

        //Search database for Product list
            List<Product> SelectProducts = Builder.Search(new Product());
        //Select Product from list
            Product OurProduct = Builder.ChooseClassFromList(SelectProducts);

        //Modify Product
            bool repeat = false;
            BL.DelClass(OurProduct);
            do{
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Name",
                    "[2] - Category",
                    "[3] - Description",
                    "[4] - Price"});

                string choice2 = Console.ReadLine();

                Builder.Add("What is the new value?",'b');

                switch(choice2)
                {
                    case "1":
                        OurProduct.Name = Console.ReadLine();
                        break;
                    case "2":
                        OurProduct.Category = Console.ReadLine();
                        break;  
                    case "3":
                        OurProduct.Description = Console.ReadLine();
                        break;
                    case "4":
                        OurProduct.Price = decimal.Parse(Console.ReadLine());
                        break;
                    default:
                        break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {OurProduct.Name}?"});

                repeat = Builder.Choice();

            } while(repeat);
            BL.AddClass(OurProduct);

        //Reset display for new menu selection
            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Product Modified!",
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
                    return MenuType.ModifyProduct;
                default:
                    Builder.Pause("Not a choice. Try again.");
                    return MenuType.Main;
            }
            
        }

    }
}
