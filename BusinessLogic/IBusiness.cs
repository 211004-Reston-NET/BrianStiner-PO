using System;
using System.Collections.Generic;
using Models;


/* The logic to perform CRUD operations on the models.
Contains repository specific logic on storing and accessing data
*/

namespace BusinessLogic
{
    public interface IBusiness
    {
        /// <summary>
        /// These will pass an IClass to our _repo database
        /// </summary>
        /// <param name="p_rest">This is the IClass we will be adding to the database</param>
        void AddClass(Customer p_IC);
        void AddClass(Storefront p_IC);
        void AddClass(Order p_IC);
        void AddClass(LineItem p_IC);
        void AddClass(Product p_IC);


        /// <summary>
        /// These will pass an IClass to the database.
        /// </summary>
        /// <returns>It will return a list of IClasses</returns>
        List<Customer> GetAllClasses(Customer p_IC);
        List<Storefront> GetAllClasses(Storefront p_IC);
        List<Order> GetAllClasses(Order p_IC);
        List<LineItem> GetAllClasses(LineItem p_IC);
        List<Product> GetAllClasses(Product p_IC);

    }
}