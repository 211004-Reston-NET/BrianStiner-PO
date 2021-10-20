using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    public class SearchCustomerMenu : IMenu
    {

        //ask for a string and search against all of the Customer database to return a select List<Customer>, show it, user selects one, modify that customer.
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();
            List<Customer> SelectCustomers = new List<Customer>();    

            bool repeat = false;
            List<string> menulines = new List<string>();


            //search customer
            do
            {
                menulines.Add("Search Customers:");
                Builder.BuildMenu(menulines);
                string entered = Console.ReadLine();
                menulines.Add(entered);

                SelectCustomers = BL.SearchClass(new Customer(), entered);

                //Builder.BuildSearchResult(SelectCustomers)
                if(SelectCustomers.Count == 0){menulines.Add("No search results."); repeat = true;}
                else{
                    menulines.Add("Show searched Customers");
                    int cnt = 0;
                    foreach(Customer c in SelectCustomers){
                        cnt++;
                        menulines.Add($"[{cnt}]--------------------");
                        foreach(string s in c.ToStringList()){
                            menulines.Add("  "+s);
                        }
                    }
                    menulines.Add("Do you want to search again?");
                    repeat = Builder.Choice();
                }

            } while (repeat);


            //select customer
            menulines.Add("Select number for ");
            menulines.Add("the customer you want.");
            Builder.BuildMenu(menulines);

            Customer OurCustomer = BL.ChooseClassFromList(SelectCustomers);
            
            


            //Modify Customer
            BL.DelClass(OurCustomer);
            do{
                menulines.Add("What do you want to change?");
                menulines.Add("[1] - Name");
                menulines.Add("[2] - Address");
                menulines.Add("[3] - Email");
                menulines.Add("[4] - Phone Number");
                Builder.BuildMenu(menulines);
                string choice2 = Console.ReadLine();

                menulines.Add("What is the new value?");
                Builder.BuildMenu(menulines);
                string newvalue = Console.ReadLine();
                menulines.Add(newvalue);

                switch(choice2)
                {
                    case "1":
                        OurCustomer.Name = newvalue;
                        break;
                    case "2":
                        OurCustomer.Address = newvalue;
                        break;  
                    case "3":
                        OurCustomer.Email = newvalue;
                        break;
                    case "4":
                        OurCustomer.PhoneNumber = newvalue;
                        break;
                    default:
                        break;

                }
                menulines.Add("---------------------------");
                menulines.Add("Do you want to make another");
                menulines.Add($"change to {OurCustomer.Name}?");
                Builder.BuildMenu(menulines);
                repeat = Builder.Choice();

            } while(repeat);
            BL.AddClass(OurCustomer);



            //reset menu for new menu selection
            menulines.Add("Press Enter to Continue...");
            Builder.BuildMenu(menulines);
            Console.ReadLine();

            menulines = new List<string>(){
                "Customer Found!",
                "---------------",
                "What do you want to do?",
                "[0] - Go back",
                "[1] - Find another Customer"};
            
            Builder.BuildMenu(menulines);
        }

        public MenuType Choice()
        {
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "0":
                    return MenuType.Customer;
                case "1":
                    return MenuType.SearchCustomer;
                default:
                    Console.WriteLine("Not a choice. Try again.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return MenuType.Main;
            }
            
        }

    }
}
