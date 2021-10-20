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
    
        /// <summary> These will pass a Class to our _repo database </summary>
        /// <param name="p_IC">This is the IClass we will be adding to the database</param>
        void AddClass(Customer p_IC);
        void AddClass(Storefront p_IC);
        void AddClass(Order p_IC);
        void AddClass(LineItem p_IC);
        void AddClass(Product p_IC);


        /// <summary> These will pass a Class to the database. </summary>
        /// <returns>It will return a list of Classes</returns>
        List<Customer> GetAllClasses(Customer p_IC);
        List<Storefront> GetAllClasses(Storefront p_IC);
        List<Order> GetAllClasses(Order p_IC);
        List<LineItem> GetAllClasses(LineItem p_IC);
        List<Product> GetAllClasses(Product p_IC);


        /// <summary> These will pass a Class to the database for deletion. </summary>
        void DelClass(Customer p_IC);
        void DelClass(Storefront p_IC);
        void DelClass(Order p_IC);
        void DelClass(LineItem p_IC);
        void DelClass(Product p_IC);


        /// <summary> These will pass a Class to the database. </summary>
        /// <returns>It will return a list of Classes</returns>
        List<Customer> SearchClass(Customer p_IC, string p_search);
        List<Storefront> SearchClass(Storefront p_IC, string p_search);
        List<Order> SearchClass(Order p_IC, string p_search);
        List<LineItem> SearchClass(LineItem p_IC, string p_search);
        List<Product> SearchClass(Product p_IC, string p_search);

        /* <summary> These will pass a Class to the database. </summary>
        /// <returns>It will return a list of Classes</returns>
        Customer ChooseClassFromList(List<Customer> p_ICList);
        Storefront ChooseClassFromList(List<Storefront> p_ICList);
        Order ChooseClassFromList(List<Order> p_ICList);
        LineItem ChooseClassFromList(List<LineItem> p_ICList);
        Product ChooseClassFromList(List<Product> p_ICList);*/

    }
}