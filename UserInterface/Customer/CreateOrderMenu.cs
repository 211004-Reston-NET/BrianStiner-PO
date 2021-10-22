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
            Tools Builder = new Tools();
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