namespace UserInterface
{
    class Factory : IFactory
    {
        public IMenu GetMenu(MenuType currentPage)
        {
            IMenu page;
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
                case MenuType.ModifyCustomer:
                    page = new ModifyCustomerMenu();
                    break;
                case MenuType.DeleteCustomer:
                    page = new DeleteCustomerMenu();
                    break;
                case MenuType.SelectCustomer:
                    page = new SelectCustomerMenu();
                    break;
                case MenuType.ShowCurrentCustomer:
                    page = new ShowAllCustomersMenu();
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
                case MenuType.ModifyStorefront:
                    page = new ModifyStorefrontMenu();
                    break;
                case MenuType.DeleteStorefront:
                    page = new DeleteStorefrontMenu();
                    break;
                case MenuType.SelectStorefront:
                    page = new SelectStorefrontMenu();
                    break;
                case MenuType.ShowCurrentStorefront:
                    page = new ShowAllStorefrontsMenu();
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
                case MenuType.ModifyProduct:
                    page = new ModifyProductMenu();
                    break;
                case MenuType.DeleteProduct:
                    page = new DeleteProductMenu();
                    break;
                

                case MenuType.Order:
                    page = new OrderMenu();
                    break;
                case MenuType.ShowAllOrders:
                    page = new ShowAllOrdersMenu();
                    break;
                case MenuType.AddOrder:
                    page = new AddOrderMenu();
                    break; 
                case MenuType.ModifyOrder:
                    page = new ModifyOrderMenu();
                    break;
                case MenuType.DeleteOrder:
                    page = new DeleteOrderMenu();
                    break;

                case MenuType.Exit:
                    page = new ExitMenu();
                    break;
                case MenuType.RealExit:
                    page = new RealExitMenu();
                    break;
                    
                default:
                    page = new MainMenu();
                    break; 
            }
            return page;
        }
    }
}