using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    class ShowAllStorefrontsMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            List<Storefront> AllStorefronts = BL.GetAllClasses(new Storefront()); //"Storefronts.json"
            List<string> menulines = new List<string>()
                {"Show all Storefronts,"};
            foreach(Storefront c in AllStorefronts){
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
                "Storefronts in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Storefronts again."};
            
            Builder.BuildMenu(menulines);
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Storefront;
                case "1":
                    return MenuType.ShowAllStorefronts;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
