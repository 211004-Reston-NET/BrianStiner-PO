using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteLineItemMenu : IMenu
    {

        //ask for a string and search against all of the LineItem database to return a select List<LineItem>, show it, user selects one, modify that LineItem.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();
            Builder.Reset();

            //Search database for LineItem list
            List<LineItem> SelectLineItems = Builder.Search(new LineItem());

            //Select LineItem from list
            LineItem OurLineItem = Builder.ChooseClassFromList(SelectLineItems);

            //Delete LineItem
            BL.DelClass(OurLineItem);

            //Show LineItem database
            Builder.ShowAll(BL.GetAllClasses(OurLineItem));

            //Reset menu for new menu selection
            Builder.Add(" ",1);

            Builder.Reset(new List<string>(){
                "LineItem Deleted!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another LineItem"});
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.LineItem;
                case "1":
                    return MenuType.DeleteLineItem;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }

    }
}
