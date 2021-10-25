using System;
using Toolbox;
using System.Collections.Generic;

namespace UserInterface
{
    public class ExitMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            Builder.Reset(new List<string>()
                {"Exit Menu",
                "Are you sure you want to quit?", 
                "[0] - Go back", 
                "[1] - Actually quit"});

        }

        public MenuType Choice()
        {
            {
                MenuBuilder Builder = new MenuBuilder();
                int userChoice = Builder.GetInt();
                switch (userChoice)
                {
                    case 0:
                        return MenuType.Main;
                    case 1:
                        return MenuType.RealExit;
                    default:
                        Console.WriteLine("Not a choice. Try again.",1);
                        return MenuType.Exit;
                }
            }
        }
    }
}
