using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class ModifyLineItemMenu : IMenu
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

        //Modify LineItem
            bool repeat = false;
            BL.DelClass(OurLineItem);
            do{
                Builder.Add(new List<string>(){
                    "What do you want to change?",
                    "[1] - Name"});

                string choice2 = Console.ReadLine();

                Builder.Add("What is the new value?",'b');

                switch(choice2)
                {
                    case "1":
                        OurLineItem.Quantity = Int32.Parse(Console.ReadLine());
                        break;
                    default:
                        break;
                }
                Builder.Add(new List<string>(){
                    "---------------------------",
                    "Do you want to make another",
                   $"change to {OurLineItem.Quantity}?"});

                repeat = Builder.Choice();

            } while(repeat);
            BL.AddClass(OurLineItem);

            //Reset display for new menu selection
            Builder.Pause();

            Builder.Reset(new List<string>(){
                "LineItem Modified!",
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
                    return MenuType.ModifyLineItem;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }

    }
}
