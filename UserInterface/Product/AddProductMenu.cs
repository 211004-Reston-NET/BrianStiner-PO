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
            MenuBuilder Builder = new MenuBuilder();    
 
            Builder.Add("Fill in Product's info,");
            Builder.Add("What is their name?",'b');
            string name = Builder.GetString();
            Builder.Add(name);

            Builder.Add("What is their Category?",'b');
            string category = Builder.GetString();
            Builder.Add(category);

            Builder.Add("What is their Description?",'b');
            string description = Builder.GetString();
            Builder.Add(description);

            Builder.Add("What is their price?",'b');
            decimal price = Builder.GetDecimal();
            Builder.Add("${price}");

            Product newProduct = new Product(name, category, description, price);
            IBusiness BL = new Business();
            BL.Add(newProduct);

            Builder.Pause($"{newProduct.Name} Added!");   
        }

        public MenuType Choice(){return MenuType.Product;}
        
            
    }
}

