using System;
using Toolbox;
using System.Collections.Generic;

namespace UserInterface
{
    public class RealExitMenu : IMenu
    {
        public void Display()
        {
            List<string> menulines = new List<string>()
                {"GoodBye!"};
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
                    default:
                        Console.WriteLine("Not a choice. Try again.");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.RealExit;
                }
            }
        }
    }
}
