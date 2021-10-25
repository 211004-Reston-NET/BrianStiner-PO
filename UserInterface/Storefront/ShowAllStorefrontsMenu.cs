using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowAllStorefrontsMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            MenuBuilder Builder = new MenuBuilder();

            Builder.ShowAll(BL.GetAllClasses(new Storefront()));

            Builder.Add(" ");
            Builder.Add("Press Enter to Continue...",'b');
            Console.ReadLine();

            Builder.Reset(new List<string>(){
                "Storefronts in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Storefronts again."});

        }

        public MenuType Choice()
        {
            MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Storefront;
                case 1:
                    return MenuType.ShowAllStorefronts;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.ShowAllStorefronts;
            }
            
        }
    }
}
