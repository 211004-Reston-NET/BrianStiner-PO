using System;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;

            IMenu page = new MainMenu();
            while (repeat)
            {
                
                Console.Clear();
                page.Display();
                MenuType currentPage = page.Choice();

                switch (currentPage)
                {
                    case MenuType.Main:
                        page = new MainMenu();
                        break;

                    case MenuType.Customer:
                        page = new CustomerMenu();
                        break;

                    case MenuType.ShowAllCustomers:
                        page = new ShowAllCustomersMenu();
                        break;
                     case MenuType.AddCustomer:
                        page = new AddCustomerMenu();
                        break;

                    case MenuType.Customer:
                        page = new OrderMenu();
                        break;

                    case MenuType.Storefront:
                        page = new StorefrontMenu();
                        break;
                     case MenuType.Main:
                        page = new MainMenu();
                        break;

                    case MenuType.Customer:
                        page = new OrderMenu();
                        break;

                    case MenuType.Storefront:
                        page = new StorefrontMenu();
                        break;
                        
                    default:
                        Console.WriteLine("somehow there wasn't a menu.");
                        break;
                }
            }

        }
    }
}