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

                    case MenuType.Storefront:
                        page = new StorefrontMenu();
                        break;

                    case MenuType.ShowAllStorefronts:
                        page = new ShowAllStorefrontsMenu();
                        break;
                      
                     case MenuType.AddStorefront:
                        page = new AddStorefrontMenu();
                        break;

                    case MenuType.Product:
                        page = new ProductMenu();
                        break;

                    case MenuType.ShowAllProducts:
                        page = new ShowAllProductsMenu();
                        break;
                       
                    case MenuType.AddProduct:
                        page = new AddProductMenu();
                        break;

                    case MenuType.Exit:
                        page = new ExitMenu();
                        break;

                    case MenuType.RealExit:
                        page = new RealExitMenu();
                        repeat = false;
                        break;       
                    default:
                        Console.WriteLine("Somehow there wasn't a menu. ");
                        break;
                }
            }

        }
    }
}