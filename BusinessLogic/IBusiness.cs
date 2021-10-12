using System;
using System.Collections.Generic;
using RRModels;


/* The logic to perform CRUD operations on the models.
Contains repository specific logic on storing and accessing data
*/

namespace RRBL
{
    public interface IRestaurantBL
    {
        /// <summary>
        /// This will return a list of restaurants stored in the database
        /// It will also capitalize every name of the restaurant
        /// </summary>
        /// <returns>It will return a list of restaurants</returns>
        List<Restaurant> GetAllRestaurant();

        /// <summary>
        /// Adds a restaurant to the database
        /// </summary>
        /// <param name="p_rest">This is the restaurant we are adding</param>
        /// <returns>It returns the added restaurant</returns>
        Restaurant AddRestaurant(Restaurant p_rest);
    }
}