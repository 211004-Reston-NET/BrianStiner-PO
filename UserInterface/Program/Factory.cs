namespace UserInterface{ 
    class Factory : IFactory{
        public IMenu GetMenu(MenuType currentMenu){
            IMenu nextPage;
            switch (currentMenu){

                case MenuType.Main:
                    nextPage = new MainMenu();
                    break;

                case MenuType.Customer:
                    nextPage = new CustomerMenu();
                    break;
                case MenuType.ShowAllCustomers:
                    nextPage = new ShowAllCustomersMenu();
                    break;
                case MenuType.AddCustomer:
                    nextPage = new AddCustomerMenu();
                    break;
                case MenuType.ModifyCustomer:
                    nextPage = new ModifyCustomerMenu();
                    break;
                case MenuType.DeleteCustomer:
                    nextPage = new DeleteCustomerMenu();
                    break;
                case MenuType.SelectCustomer:
                    nextPage = new SelectCustomerMenu();
                    break;
                case MenuType.ShowCurrentCustomer:
                    nextPage = new ShowCurrentCustomerMenu();
                    break;    

                case MenuType.Storefront:
                    nextPage = new StorefrontMenu();
                    break;
                case MenuType.ShowAllStorefronts:
                    nextPage = new ShowAllStorefrontsMenu();
                    break;
                case MenuType.AddStorefront:
                    nextPage = new AddStorefrontMenu();
                    break;
                case MenuType.ModifyStorefront:
                    nextPage = new ModifyStorefrontMenu();
                    break;
                case MenuType.DeleteStorefront:
                    nextPage = new DeleteStorefrontMenu();
                    break;
                case MenuType.SelectStorefront:
                    nextPage = new SelectStorefrontMenu();
                    break;
                case MenuType.ShowCurrentStorefront:
                    nextPage = new ShowCurrentCustomerMenu();
                    break;
                

                case MenuType.Product:
                    nextPage = new ProductMenu();
                    break;
                case MenuType.ShowAllProducts:
                    nextPage = new ShowAllProductsMenu();
                    break;
                case MenuType.AddProduct:
                    nextPage = new AddProductMenu();
                    break; 
                case MenuType.ModifyProduct:
                    nextPage = new ModifyProductMenu();
                    break;
                case MenuType.DeleteProduct:
                    nextPage = new DeleteProductMenu();
                    break;
                

                case MenuType.Order:
                    nextPage = new OrderMenu();
                    break;
                case MenuType.ShowAllOrders:
                    nextPage = new ShowAllOrdersMenu();
                    break;
                case MenuType.AddOrder:
                    nextPage = new AddOrderMenu();
                    break; 
                case MenuType.ModifyOrder:
                    nextPage = new ModifyOrderMenu();
                    break;
                case MenuType.DeleteOrder:
                    nextPage = new DeleteOrderMenu();
                    break;

                case MenuType.Exit:
                    nextPage = new ExitMenu();
                    break;
                case MenuType.RealExit:
                    nextPage = new RealExitMenu();
                    break;
                    
                default:
                    nextPage = new MainMenu();
                    break; 
            }
            
            return nextPage;
        }
    }
}