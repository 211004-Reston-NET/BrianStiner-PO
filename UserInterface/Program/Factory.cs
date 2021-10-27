using System.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DataAccessLogic.Entity;
using DataAccessLogic;
using BusinessLogic;

namespace UserInterface{ 
    class Factory : IFactory{
        public IMenu GetMenu(MenuType currentMenu){

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("./../UserInterface/appsettings.json") //TODO: File not found exception. Get help.
                .Build();
            
            DbContextOptionsBuilder<revaturedatabaseContext> options = new DbContextOptionsBuilder<revaturedatabaseContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            switch (currentMenu){

                //Customer
                case MenuType.Customer:
                    return new CustomerMenu(new Business(new Repository(new revaturedatabaseContext(options.Options))));

                case MenuType.ShowAllCustomers:
                    return new ShowAllCustomersMenu(new Business(new Repository( new revaturedatabaseContext(options.Options))));
                case MenuType.AddCustomer:
                    return new AddCustomerMenu(new Business(new Repository( new revaturedatabaseContext(options.Options))));
                case MenuType.DeleteCustomer:
                    return new DeleteCustomerMenu(new Business(new Repository( new revaturedatabaseContext(options.Options))));

                case MenuType.ModifyCustomer:
                    return new ModifyCustomerMenu(new Business(new Repository(new revaturedatabaseContext(options.Options))));
                case MenuType.SelectCustomer:
                    return new SelectCustomerMenu(new Business(new Repository(new revaturedatabaseContext(options.Options)))); 
                case MenuType.ShowCurrentCustomer:
                    return new ShowCurrentCustomerMenu(new Business(new Repository(new revaturedatabaseContext(options.Options))));     

                //Storefront
                case MenuType.Storefront:
                    return new StorefrontMenu(new Business(new Repository(new revaturedatabaseContext(options.Options))));

                case MenuType.ShowAllStorefronts:
                    return new ShowAllStorefrontsMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                case MenuType.AddStorefront:
                    return new AddStorefrontMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                case MenuType.DeleteStorefront:
                    return new DeleteStorefrontMenu(new Business(new Repository( new revaturedatabaseContext(options.Options))));

                case MenuType.ModifyStorefront:
                    return new ModifyStorefrontMenu(new Business(new Repository(new revaturedatabaseContext(options.Options))));
                case MenuType.SelectStorefront:
                    return new SelectStorefrontMenu(new Business(new Repository(new revaturedatabaseContext(options.Options)))); 
                case MenuType.ShowCurrentStorefront:
                    return new ShowCurrentCustomerMenu(new Business(new Repository(new revaturedatabaseContext(options.Options)))); 
                
                //Product
                case MenuType.Product:
                    return new ProductMenu(new Business(new Repository(new revaturedatabaseContext(options.Options))));

                case MenuType.ShowAllProducts:
                    return new ShowAllProductsMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                case MenuType.AddProduct:
                    return new AddProductMenu(new Business(new Repository( new revaturedatabaseContext(options.Options))));  
                case MenuType.ModifyProduct:
                    return new ModifyProductMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                case MenuType.DeleteProduct:
                    return new DeleteProductMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                
                //Order
                case MenuType.Order:
                    return new OrderMenu(new Business(new Repository(new revaturedatabaseContext(options.Options))));

                case MenuType.ShowAllOrders:
                    return new ShowAllOrdersMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                case MenuType.AddOrder:
                    return new AddOrderMenu(new Business(new Repository( new revaturedatabaseContext(options.Options))));  
                case MenuType.ModifyOrder:
                    return new ModifyOrderMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                case MenuType.DeleteOrder:
                    return new DeleteOrderMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 

                //Others
                case MenuType.Exit:
                    return new ExitMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                case MenuType.RealExit:
                    return new RealExitMenu(new Business(new Repository( new revaturedatabaseContext(options.Options)))); 
                    
                default:
                    return new MainMenu(new Business(new Repository( new revaturedatabaseContext(options.Options))));  
            }
        }
    }
}