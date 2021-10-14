using System.Collections.Generic;
using Models;

namespace DataAccessLogic
{
    public interface IRepository
    {
        /// <summary>
        /// These will add an IClass in our database
        /// </summary>
        /// <param name="p_rest">This is the IClass we will be adding to the database</param>
        void AddClass(Customer p_IC);
        void AddClass(Storefront p_IC);
        void AddClass(Order p_IC);
        void AddClass(LineItem p_IC);
        void AddClass(Product p_IC);


        /// <summary>
        /// These will return a list of IClasses stored in the database.
        /// </summary>
        /// <returns>It will return a list of IClasss</returns>
        List<Customer> GetAllClasses(Customer p_IC);
        List<Storefront> GetAllClasses(Storefront p_IC);
        List<Order> GetAllClasses(Order p_IC);
        List<LineItem> GetAllClasses(LineItem p_IC);
        List<Product> GetAllClasses(Product p_IC);

    }
}