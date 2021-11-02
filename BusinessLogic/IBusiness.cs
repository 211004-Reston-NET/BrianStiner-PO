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
        Customer Add(Customer p_IC);
        Storefront Add(Storefront p_IC);
        Order Add(Order p_IC);
        LineItem Add(LineItem p_IC);
        Product Add(Product p_IC);


        /// <summary> These will pass a Class to the database. </summary>
        /// <returns>It will return a list of Classes</returns>
        List<Customer> GetAll(Customer p_IC, bool? p_Active);
        List<Storefront> GetAll(Storefront p_IC, bool? p_Active);
        List<Order> GetAll(Order p_IC, bool? p_Active);
        List<LineItem> GetAll(LineItem p_IC);
        List<Product> GetAll(Product p_IC);


        /// <summary> These will pass a Class to the database for deletion. </summary>
        void Delete(Customer p_IC);
        void Delete(Storefront p_IC);
        void Delete(Order p_IC);
        void Delete(LineItem p_IC);
        void Delete(Product p_IC);

        /// <summary> These return a Class from the database that matches the Id </summary>
        Customer Get(Customer p_IC);
        Storefront Get(Storefront p_IC);
        Order Get(Order p_IC);
        LineItem Get(LineItem p_IC);
        Product Get(Product p_IC);

        /// <summary> These will pass a Class to the database for updating. </summary>
        void Update(Customer p_IC);
        void Update(Storefront p_IC);
        void Update(Order p_IC);
        void Update(LineItem p_IC);
        void Update(Product p_IC);



        /// <summary> These will pass a Class to the database. </summary>
        /// <returns>It will return a list of Classes</returns>
        List<Customer> Search(Customer p_IC, string p_search);
        List<Storefront> Search(Storefront p_IC, string p_search);
        List<Order> Search(Order p_IC, string p_search);
        List<LineItem> Search(LineItem p_IC, string p_search);
        List<Product> Search(Product p_IC, string p_search);

    }
}