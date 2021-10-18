using System;
using System.Collections.Generic;  

namespace Models
{
    public interface IClass{

        /// <returns> a string containing the name of the class.</returns>
        string Identify();

        /// <summary>
        /// It will return a List<string> containing each of its variables displayed for the menubuilder.
        /// </summary>
        /// <returns>{$"name:{name}","phone:{phone}","color:{color}"}</returns>
        List<string> ToStringList();
    }

}