using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class AddStorefrontMenu : IMenu
    {
        public void Display()
        {
            MenuBuilder Builder = new MenuBuilder();    
 
            Builder.Add("Fill in Storefront's info:");
            Builder.Add("What is their name?",'b');
            string name = Console.ReadLine();
            Builder.Add(name);

            Builder.Add("What is their address?",'b');
            string address = Console.ReadLine();
            Builder.Add(address);


            Storefront newStorefront = new Storefront(name, address);
            IBusiness BL = new Business();
            BL.Add(newStorefront);

            Builder.Add("Storefront added!");
            Builder.Pause();
            /*/
            Builder.Reset(new List<string>(){
                "Storefront Added!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Add another Storefront"});
            /*/
        }

        public MenuType Choice()
        {  return MenuType.Storefront;
           /*/ MenuBuilder Builder = new MenuBuilder();
            int userChoice = Builder.GetInt();
            switch (userChoice)
            {
                case 0:
                    return MenuType.Storefront;
                case 1:
                    return MenuType.AddStorefront;
                default:
                    Builder.Add("Not a choice. Try again.",1);
                    return MenuType.AddStorefront;
            }/*/
            
        }
    }
}
