using System;
using System.Collections.Generic;  

namespace Models
{
    public interface IClass{
        /// <summary>
        /// It will return a string containing the name of the class its in with .json on the end.
        /// Maybe will update to just display name and use more generally.
        /// </summary>
        /// <returns>The homeland of the Class</returns>
        string Identify();
    }

}