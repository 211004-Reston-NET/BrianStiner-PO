using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface{
    public class DeleteOrderMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public DeleteOrderMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }

        //ask for a string and search against all of the Order database to return a select List<Order>, show it, user selects one, modify that Order.
        public void Display(){

            Order OurOrder = Builder.SearchAndSelect(new Order());  //Search database for Order list, Select Order from list

            BL.Delete(OurOrder);                                    //Delete Order

            Builder.Pause("Order Deleted!");
        }
        public MenuType Choice(){return MenuType.Order;}

    }
}
