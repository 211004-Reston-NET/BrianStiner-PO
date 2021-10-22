using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface
{
    public class ShowAllLineItemsMenu : IMenu
    {
        public void Display()
        {
            IBusiness BL = new Business();
            Tools Builder = new Tools();

            Builder.ShowAll(BL.GetAllClasses(new LineItem()));

            Builder.Add(" ",1);

            Builder.Reset(new List<string>(){
                "LineItems in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show LineItems again."});

        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.LineItem;
                case "1":
                    return MenuType.ShowAllLineItems;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
