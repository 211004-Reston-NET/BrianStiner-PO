﻿using System;
using System.Collections.Generic;
using Toolbox;

namespace UserInterface
{
    public class MainMenu : IMenu
    {
        public void Display()
        {
            Tools Builder = new Tools();
            Builder.Reset(new List<string>()
                {"Welcome to the Main Menu,",
                "Which menu do you want?", 
                "[1] - Customers", 
                "[2] - Storefronts", 
                "[3] - Products",
                "[4] - Exit"});
            
            Builder.BuildMenu();
        }

        public MenuType Choice()
            {
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        return MenuType.Customer;
                    case "2":
                        return MenuType.Storefront;
                    case "3":
                        return MenuType.Product;
                    case "4":
                        return MenuType.Exit;
                    default:
                        Console.WriteLine("Not a choice. Try again.");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.Main;
                }
            }
    }
}
