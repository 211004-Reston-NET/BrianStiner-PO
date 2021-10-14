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
        /// Passes an IClass to the repo to store in the database
        /// </summary>
        /// <param name="p_IC">This is the IClass we are passing</param>
        void AddIClass(IClass p_IC);
        
        /// <summary>
        /// This will return a list of IClasses of a type stored in the database
        /// </summary>
        /// <returns>It will return a list of IClasses from  that file</returns>
        List<IClass> GetAllIClasses(string p_homefile);

    }
}