using System.Collections.Generic;
using Models;

namespace DataAccessLogic
{
    public interface IRepository
    {
        /// <summary>
        /// It will add a Customer in our database
        /// </summary>
        /// <param name="p_rest">This is the Customer we will be adding to the database</param>
        /// <returns>It will just return the Customer we are adding</returns>
        Customer AddCustomer(Customer p_rest);

        /// <summary>
        /// This will return a list of Customers stored in the database
        /// </summary>
        /// <returns>It will return a list of Customers</returns>
        List<Customer> GetAllCustomer();
    }
}