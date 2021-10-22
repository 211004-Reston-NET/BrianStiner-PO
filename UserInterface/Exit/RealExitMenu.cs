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
            Builder.Add("GoodBye!");
            Builder.Pause();
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
                        Console.WriteLine("Not a choice. Try again.",1);
                        return MenuType.RealExit;
                }
            }
        }
    }
}
