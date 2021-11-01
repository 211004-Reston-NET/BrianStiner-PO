using System;
using System.Collections.Generic;
using BusinessLogic;
using Toolbox;

namespace UserInterface{
    public class CheckoutMenu : IMenu{
        MenuBuilder Builder; IBusiness BL;
        public CheckoutMenu(IBusiness BusinessLogic){
            BL = BusinessLogic;
            Builder = new MenuBuilder(BL);
        }
        public void Display(){
            Builder.Reset(new List<string>()
                {"Checkout time!",
                "We'll auto-purchase and ring you up!"
                });
                Builder.Pause(Current.customer.ToStringList());
                
        }

        public MenuType Choice(){return MenuType.Main;}
    }
}
