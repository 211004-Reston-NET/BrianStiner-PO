using System;
using System.Collections.Generic;
using Toolbox;
using BusinessLogic;
using Models;

namespace UserInterface{
    public class ShowAllOrdersMenu : IMenu{
        IBusiness BL; MenuBuilder Builder;
        public ShowAllOrdersMenu(IBusiness BL){
            this.BL = BL;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){

            Builder.ShowAll(BL.GetAll(new Order()));

            Builder.Pause();

            Builder.Reset(new List<string>(){
                "Orders in database shown!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Show Orders again."});

        }

        public MenuType Choice() {return MenuType.Order;}    
        
    }
}
