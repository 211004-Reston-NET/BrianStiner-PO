using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class AddLineItemMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();    
 
            Builder.Add("Fill in LineItem's info,");
            Builder.Add("What is their name?",'b');
            int quantity = Int32.Parse(Console.ReadLine());
            Builder.Add($"{quantity}",1);

            LineItem newLineItem = new LineItem(quantity);
            IBusiness BL = new Business();
            BL.AddClass(newLineItem);

            Builder.Reset(new List<string>(){
                "LineItem Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another LineItem"});
            
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.LineItem;
                case "1":
                    return MenuType.AddLineItem;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }
    }
}
