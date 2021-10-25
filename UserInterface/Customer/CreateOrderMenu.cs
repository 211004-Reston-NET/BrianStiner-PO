using System;
using System.Collections.Generic;
using Models;
using Toolbox;

namespace UserInterface
{
    class CreateOrderMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            Builder.Reset(new List<string>(){
                "Welcome to the Create Order Menu",
                "[0] - Go Back"

            });
        }
        public MenuType Choice()
        {
            throw new NotImplementedException();
        }


    }
}