using System;
using Toolbox;
using System.Collections.Generic;

namespace UserInterface
{
    class ExitMenu : IMenu
    {
        public void Display()
        {
            List<string> menulines = new List<string>()
                {"Exit Menu",
                "Are you sure you want to quit?", 
                "[0] - Go back", 
                "[1] - Actually quit"};
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
                        return MenuType.RealExit;
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