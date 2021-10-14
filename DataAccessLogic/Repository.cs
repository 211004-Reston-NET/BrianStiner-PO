using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Models;

/* The logic to perform CRUD operations on the models.
Contains repository specific logic on storing and accessing data
*/

namespace DataAccessLogic
{
    //Access the json files where data is stored.
    public class Repository : IRepository
    {
        private const string c_filepath = "./../RRDL/Database/";
        private string _jsonString;
    
        public void AddIClass(IClass p_IC)
        {
            //The IClass must say where they go.
            List<IClass> listOfIClasses = GetAllIClasses(p_IC.Identify());

            //We add one IClass to the file by first adding to a list of IClasses, translating that list into json serial, then overwriting to the correct file.
            listOfIClasses.Add(p_IC);
            _jsonString = JsonSerializer.Serialize(listOfIClasses, new JsonSerializerOptions{WriteIndented=true});
            File.WriteAllText(c_filepath + p_IC.Identify(), _jsonString);
        }
        public List<IClass> GetAllIClasses(string p_homefile)
        {
            //File IClass will announce their place and be put in a .json they choose
            _jsonString = File.ReadAllText(c_filepath+p_homefile);
            return JsonSerializer.Deserialize<List<IClass>>(_jsonString);
        }

    }
}