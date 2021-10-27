using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class DeleteProductMenu : IMenu{

        //Ask for a string and search against all of the Product database to return a select List<Product>, show it, user selects one, modify that Product.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();

            Product OurProduct = Builder.SearchAndSelect(new Product());

            BL.Delete(OurProduct);

            Builder.Pause($"{OurProduct.Name} has been deleted.");
        }

        public MenuType Choice(){return MenuType.Product;}
            
        

    }
}
