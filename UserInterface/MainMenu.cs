using System;

namespace UserInterface
{
    class MainMenu : IMenu
    {
        public void Display()
        {
           Console.WriteLine(@"   ______________________________     ");
           Console.WriteLine(@" / \                             \.   ");
           Console.WriteLine(@" \_ |                            |.   ");
           Console.WriteLine(@"    |  Welcome to the Main Menu! |.   "); 
           Console.WriteLine(@"    |  What do you want to do?   |.   "); 
           Console.WriteLine(@"    |  [1] - Customers           |.   "); 
           Console.WriteLine(@"    |  [2] - Storefronts         |.   "); 
           Console.WriteLine(@"    |  [3] - Products            |.   "); 
           Console.WriteLine(@"    |  [4] - Exit                |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |   _________________________|___ ");
           Console.WriteLine(@"    |  /                            /.");
           Console.WriteLine(@"    \_/____________________________/. ");

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
