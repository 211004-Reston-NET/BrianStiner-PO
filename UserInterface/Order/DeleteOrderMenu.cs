using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class DeleteOrderMenu : IMenu
    {

        //ask for a string and search against all of the Order database to return a select List<Order>, show it, user selects one, modify that Order.
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();
            IBusiness BL = new Business();

            Order OurOrder = Builder.SearchAndSelect(new Order());  //Search database for Order list, Select Order from list

            BL.Delete(OurOrder);                                    //Delete Order

            Builder.Pause("Order Deleted!");
        }

        public MenuType Choice(){return MenuType.Order;}

    }
}
