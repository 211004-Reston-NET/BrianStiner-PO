using System.Collections.Generic;
using Models;

namespace DataAccessLogic
{
    public interface IRepository
    {
        /// <summary>
        /// It will add an IClass in our database
        /// </summary>
        /// <param name="p_rest">This is the IClass we will be adding to the database</param>
        /// <returns>It will just return the IClass we are adding</returns>
        IClass AddIClass(IClass p_rest);

        /// <summary>
        /// This will return a list of IClasss stored in the database
        /// </summary>
        /// <returns>It will return a list of IClasss</returns>
        List<IClass> GetAllIClasses(string p_homefile);
    }
}