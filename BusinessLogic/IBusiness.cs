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
        /// This will return a list of restaurants stored in the database
        /// It will also capitalize every name of the restaurant
        /// </summary>
        /// <returns>It will return a list of restaurants</returns>
        List<IClass> GetAllIClasses(string p_homefile);

        /// <summary>
        /// Adds a restaurant to the database
        /// </summary>
        /// <param name="p_IC">This is the restaurant we are adding</param>
        /// <returns>It returns the added restaurant</returns>
        IClass AddIClass(IClass p_IC);
    }
}