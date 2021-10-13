using System;

namespace UserInterface
{
    class OrderMenu : IMenu
    {
        public void Display()
        {
           Console.WriteLine(@"   ______________________________     ");
           Console.WriteLine(@" / \                             \.   ");
           Console.WriteLine(@" \_ |                            |.   ");
           Console.WriteLine(@"    |  Are you sure you          |.   "); 
           Console.WriteLine(@"    |  want to quit?             |.   "); 
           Console.WriteLine(@"    |  [1] - Yes                 |.   "); 
           Console.WriteLine(@"    |  [2] - No                  |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |                            |.   "); 
           Console.WriteLine(@"    |   _________________________|___ ");
           Console.WriteLine(@"    |  /                            /.");
           Console.WriteLine(@"    \_/____________________________/. ");

        }

        public MenuType Choice()
        {
            {
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        return MenuType.Main;
                        //return null;
                    case "2":
                        return MenuType.Main;
                        //return null;
                    default:
                        Console.WriteLine("Not a choice. Try again.");
                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        return MenuType.Exit;
                }
            }
        }
    }
}
