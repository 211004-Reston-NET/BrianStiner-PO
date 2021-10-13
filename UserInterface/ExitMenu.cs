using System;
using Toolbox;
using System.Collections.Generic;

namespace UserInterface
{
    class OrderMenu : IMenu
    {
        public void Display()
        {
            List<string> menulines = new List<string>()
                {"Exit Menu,",
                "Are you sure you want to exit?", 
                "[0] - Go back", 
                "[1] - Actually exit"};
            Tools Builder = new Tools();
            Builder.BuildMenu(menulines);

        }

        public MenuType Choice()
        {
            {
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "0":
                        return MenuType.Main;
                    case "1":
                        return MenuType.Main;
                        //return null;
                        //don't know how to exit if I'm required to return menutype
                    default:
                        Console.WriteLine("Not a choice. Try again.");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.Exit;
                }
            }
        }
    }
}
