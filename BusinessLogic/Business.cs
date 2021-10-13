using System;
using System.Collections.Generic;
using Models;
using DataAccessLogic;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the business logic for the our restuarant application
    /// They are in charge of further processing/sanitizing/furthur validation of data
    /// Any Logic
    /// </summary>
    public class Business :IBusiness
    {
        private IRepository _repo;

        public void AddIClass(IClass p_IC){
            //Passes to storage without change.        
        }

        public List<IClass> GetAllIClasses(string p_homefile){
            //Passes List from storage without change.
            return _repo.GetAllIClasses(p_homefile);
        }
    }
}