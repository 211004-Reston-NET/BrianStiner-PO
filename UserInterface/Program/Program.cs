using System;

namespace UserInterface{
    class Program{
        static void Main(string[] args){
            bool repeat = true;
            IFactory factory = new Factory();
            IMenu page = factory.GetMenu(MenuType.Main);

            while (repeat){
                page.Display();
                MenuType nextmenu = page.Choice(); if(nextmenu == MenuType.RealExit) {repeat = false; break;}
                page = factory.GetMenu(nextmenu);                           
            }
        }
    }
}