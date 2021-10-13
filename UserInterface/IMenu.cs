namespace UserInterface
{
     //This enum will hold the different types of Menu the user can go through
    public enum MenuType
    {
        Main,
        Customer, ShowAllCustomers, AddCustomer,
        Storefront, ShowAllStorefronts, AddStorefront,
        Order, ShowAllOrders, AddOrder,
        LineItem, ShowAllLineItems, AddLineItem,
        Product, ShowAllProducts, AddProduct,
        Exit
    }
 

 
    //The purpose of the interface is to ensure that every menu that we will create will have
    //the following methods in this case we can also use polymorphism
    public interface IMenu
    {
        /// <summary>
        /// Displays the choices available for the user to choose from
        /// </summary>
        void Display();

        /// <summary>
        /// Records the choice the user made from the options.
        /// </summary>
        /// <returns>
        /// This method returns a MenuType from the users choice.
        /// </returns>
        MenuType Choice();
    }
}