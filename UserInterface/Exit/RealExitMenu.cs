using System;
using Toolbox;
using System.Collections.Generic;

namespace UserInterface
{
    public class RealExitMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            Builder.Add("GoodBye!");
            Builder.Pause();
        }

        public MenuType Choice(){  
            return MenuType.RealExit;
        }
    }
}
