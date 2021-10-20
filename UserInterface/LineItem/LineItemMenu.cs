using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class LineItemMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();
            Builder.Reset(new List<string>()
                {"LineItem Menu,",
                "What do you want to do?", 
                "[0] - Go back", 
                "[1] - Add LineItem", 
                "[2] - Delete a LineItem",
                "[3] - Modify a LineItem",
                "[4] - Show all LineItems"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Main;
                case "1":
                    return MenuType.AddLineItem;
                case "2":
                    return MenuType.DeleteLineItem; 
                case "3":
                    return MenuType.ModifyLineItem; 
                case "4":
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
