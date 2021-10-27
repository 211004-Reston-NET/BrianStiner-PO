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

            Builder.ShowAll(BL.GetAll(new Storefront()));

            Builder.Pause();
        }

        public MenuType Choice(){return MenuType.Storefront;}
        
    }
}
