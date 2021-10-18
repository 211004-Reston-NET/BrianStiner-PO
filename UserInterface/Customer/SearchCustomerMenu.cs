using System;
using System.Collections.Generic;
using Toolbox;
using Models;
using BusinessLogic;

namespace UserInterface
{
    class SearchCustomerMenu : IMenu
    {
        private string entered;
        private bool FindInput(Customer p_IC){
            if (p_IC.Name.Contains(entered)) {
                return true;
            } else if (p_IC.Address.Contains(entered)) {
                return true;
            } else if (p_IC.Email.Contains(entered)) {
                return true;
            } else if (p_IC.PhoneNumber.Contains(entered)) {
                return true;
            } else {
                return false;
            }
        }

        //ask for a string and search against all of the Customer database to return a select List<Customer>, show it, user selects one, modify that customer.
        public void Display()
        {
            Tools Builder = new Tools();
            IBusiness BL = new Business();  
            List<Customer> AllCustomers = BL.GetAllClasses(new Customer());  
            List<Customer> SelectCustomers = new List<Customer>();  

            bool repeat = false;
            var menulines = new List<string>();
            do
            {
                menulines.Add("Search Customers:");
                Builder.BuildMenu(menulines);

                this.entered = Console.ReadLine();
                SelectCustomers = AllCustomers.FindAll(FindInput);

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
                    repeat = false;
                }
            } while (repeat);

            menulines.Add("Select number for ");
            menulines.Add("the customer you want.");
            Builder.BuildMenu(menulines);
            
            int choice = Int32.Parse(Console.ReadLine());

            //DelClass old, AddClass new?
            BL.DelClass(SelectCustomers[choice]);
            SelectCustomers[choice].Name = "Changed";
            BL.AddClass(SelectCustomers[choice]);

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
