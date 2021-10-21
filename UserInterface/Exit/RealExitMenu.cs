using System;
using Toolbox;
using System.Collections.Generic;

namespace UserInterface
{
    public class RealExitMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();
            Builder.Add("GoodBye!",1);
            Builder.BuildMenu();

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
