using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Models;
using BusinessLogic;

/* For now this makes pretty menus out of List<strings>
*/

namespace Toolbox
{
    //This set of methods builds the visuals out of List<string> menulines, which is where the menu data is stored
    //Some useful methods are: Buildmenu, Add, Reset, Pause, TestInt, TestString, Search, ShowAll, and SelectClassFromList
    public class MenuBuilder
    {
        
        List<string> menulines = new List<string>(); //This is the list of strings that will be displayed

        public void BuildMenu()
        {
            int max = 38;
            //menulines is foreach'd and each string is checked for length, rest of length is filled with spaces, and then written to the screen.
            //if else for a string thats too long and needs to get split by spaces. 
            Console.Clear();
            Console.WriteLine(@"   ___________________________________________     ");
            Console.WriteLine(@" / \                                          \.   ");
            Console.WriteLine(@" \_ |                                         |.   ");
            foreach( string line in menulines)
            {
                if(line.Length<max){
                    Console.WriteLine($"    |   {line}{new string(' ', max-line.Length)}|.   ");
                }else{
                    foreach(string subline in line.Split(' ')){
                        Console.WriteLine($"    |   {subline}{new string(' ', max-subline.Length)}|.   ");}
                }
            } 
            Console.WriteLine(@"    |                                         |.   "); 
            Console.WriteLine(@"    |                                         |.   "); 
            Console.WriteLine(@"    |   ______________________________________|___ ");
            Console.WriteLine(@"    |  /                                         /.");
            Console.WriteLine(@"    \_/_________________________________________/. ");

        }
        public void Add(string s = ""){         //no BuildMenu for single lines. //If nothing is sent in, just adds a blank line
            menulines.Add(s);
        }
        public void Add(string s, char f){      //char f is just an overloading flag that puts a BuildMenu after line. The value doesn't matter.
            Add(s);
            BuildMenu();
        }
        public void Add(List<string> ls){
            foreach(string s in ls){Add(s);}
        }
        public void Add(List<string> ls,char f){ //char f is just an overloading flag that puts a BuildMenu after line. The value doesn't matter.
            foreach(string s in ls){Add(s);}
            BuildMenu();
        }
        public void Reset(List<string> ls){
            menulines = ls;
            BuildMenu();
        }
        public void Reset(){
            menulines = new List<string>();
            BuildMenu();
        }
        public void Pause(){
            Add();Add();
            Add("Press Enter to Continue...",'f');
            Console.ReadLine();
        }
        public void Pause(string s){
            Add(s);
            Pause();
        }



        //Method GetAddress: Returns a string that is the address of the user's input.
        public string GetAddress(){
            Add("Please enter your address: ", 'f');
            string address = Console.ReadLine(); Add(address); 
            while(!Regex.IsMatch(address, @"\d{1,6}\s\w.\s(\b\w*\b\s){1,5}\w*\.?")){        //address must be in this format: "123 Main St."
                Add("Invalid address format. Please try again: ", 'f');
                address = Console.ReadLine(); Add(address); 
            }
            return address;
        }

        //Method GetEmail: Returns a string that is the email address of the user.
        public string GetEmail(){
            Add($"Please enter your email address: ", 'f');
            string email = Console.ReadLine(); Add(email);
            while(!Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")){ //regex to check for valid email address
                Add("Invalid email address. Please try again: ", 'f');
                email = Console.ReadLine(); Add(email);
            }
            return email;
        }

        //Method GetPhoneNumber: Returns a string of the phone number entered by the user.
        public string GetPhoneNumber()
        {
            Add($"Please enter your phone number: ", 'f');
            string phone = Console.ReadLine(); Add(phone);
            while(!Regex.IsMatch(phone, @"^\d{3}-\d{3}-\d{4}$")){                               //regex for phone number
                Add("Invalid phone number. Please enter a valid phone number.", 'f');
                phone = Console.ReadLine(); Add(phone);
            }
            return phone;
        }

        //Method GetInt: Returns an int if the user enters a valid positive int using regex.
        public int GetInt(){
            string s = Console.ReadLine(); Add(s);
            int i = 0;
            bool valid = false;
            while(!valid){
                if(Regex.IsMatch(s, @"^\d+$")){                                             //regex for positive ints
                    i = int.Parse(s);
                    valid = true;
                }else{
                    Add("Please enter a valid positive integer.", 'f');
                    s = Console.ReadLine(); Add(s);
                }
            }
            return i;
        }

        //Method GetString: Returns a string if the user enters a valid string using regex.
        public string GetString(){
            string s = Console.ReadLine(); Add(s);
            string i = "";
            bool valid = false;
            while(!valid){
                if(Regex.IsMatch(s, @"^[a-zA-Z]+$")){                                       //regex for letters only.
                    i = s;
                    valid = true;
                    i = s;
                    valid = true;
                }else{
                    Add("Please enter a valid string.", 'f');
                    s = Console.ReadLine(); Add(s);
                } 
            }
            return i;
        }
        //Method Choice: no parameters. char YorN reads first char of input and checks for a valid choice. y,a,1 are true. n,b,2 are false.
        public bool Choice(){
            char YorN = Char.ToLower(Convert.ToChar(Console.ReadLine().Substring(0, 1))); 
            if(YorN=='y'||YorN=='a'||YorN=='1'){
                return true;
            }else if(YorN=='n'||YorN=='b'||YorN=='2'){
                return false;
            }else{
                Add(YorN.ToString());
                Add("Enter a valid choice. y/n a/b 1/2", 'f');
                return Choice();                                             //recursion
            }
        }

        //Methods named Search: Customer p_IC parameter: searchs Customer database List<Customer> that match the search string.

        public List<Customer> Search(Customer p_IC){
            
            bool repeat = true;
            IBusiness BL = new Business();
            List<Customer> SelectC = new List<Customer>();
            do
            {   
                Add();
                Add($"Search {p_IC.Identify()}s:",'b');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add();
                    Add($" Showing {p_IC.Identify()}s");
                    Add();
                    int cnt = 0;
                    foreach(Customer c in SelectC){
                        cnt++;
                        Add();
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add();
                    Add("Do you want to search again?", 'b');
                    repeat = Choice();
                }

            } while (repeat);
            return SelectC;
        }
        public List<Storefront> Search(Storefront p_IC){
            
            bool repeat = true;
            IBusiness BL = new Business();
            List<Storefront> SelectC = new List<Storefront>();
            do
            {   
                Add();
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add();
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(Storefront c in SelectC){
                        cnt++;
                        Add();
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add();
                    Add("Do you want to search again?", 'b');
                    repeat = Choice();
                }

            } while (repeat);
            return SelectC;
        }
        public List<Order> Search(Order p_IC){
            
            bool repeat = true;
            IBusiness BL = new Business();
            List<Order> SelectC = new List<Order>();
            do
            {   
                Add();
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add();
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(Order c in SelectC){
                        cnt++;
                        Add();
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add();
                    Add("Do you want to search again?", 'b');
                    repeat = Choice();
                }

            } while (repeat);
            return SelectC;
        }
        public List<LineItem> Search(LineItem p_IC){
            
            bool repeat = true;
            IBusiness BL = new Business();
            List<LineItem> SelectC = new List<LineItem>();
            do
            {   
                Add();
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add();
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(LineItem c in SelectC){
                        cnt++;
                        Add();
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add();
                    Add("Do you want to search again?", 'b');
                    repeat = Choice();
                }

            } while (repeat);
            return SelectC;
        }
        public List<Product> Search(Product p_IC){
            
            bool repeat = true;
            IBusiness BL = new Business();
            List<Product> SelectC = new List<Product>();
            do
            {   
                Add();
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add();
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(Product c in SelectC){
                        cnt++;
                        Add();
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add();
                    Add("Do you want to search again?", 'b');
                    repeat = Choice();
                }

            } while (repeat);
            return SelectC;
        }


        //Five overwritten "ShowAll Classes in this Class list" methods.

        public void ShowAll(List<Customer> AllIC){
            Add($"Show all {AllIC[0].Identify()}s,");
            foreach(Customer ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
            Add("",'f');
        }public void ShowAll(List<Storefront> AllIC){
            Add($"Show all {AllIC[0].Identify()}s,");
            foreach(Storefront ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
            Add("",'f');
        }public void ShowAll(List<Order> AllIC){
            Add($"Show all {AllIC[0].Identify()}s,");
            foreach(Order ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
            Add("",'f');
        }public void ShowAll(List<LineItem> AllIC){
            Add($"Show all {AllIC[0].Identify()}s,");
            foreach(LineItem ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
            Add("",'f');
        }public void ShowAll(List<Product> AllIC){
            Add($"Show all {AllIC[0].Identify()}s,");
            foreach(Product ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
            Add("",'f');
        }

        public Product ChooseClassFromList(List<Product> p_ICList){
            int choice = 0;
            bool repeat = false;
            Add("");
            Add("Enter number for your choice.",'b');
            do{
                try{
                    choice = GetInt();
                    repeat = false;
                }
                catch (System.Exception){repeat = true; Add("Thats not a valid selection. Try again."); Pause();}
            } while (repeat && choice <= p_ICList.Count && choice >= 0);

            return p_ICList[choice];
        }
        public LineItem ChooseClassFromList(List<LineItem> p_ICList){
            int choice = 0;
            bool repeat = false;
            Add("");
            Add("Enter number for your choice.",'b');
            do{
                try{choice = GetInt(); repeat = false;}
                catch (System.Exception){repeat = true; Pause("Thats not a valid selection. Try again.");}

            } while (repeat && choice <= p_ICList.Count && choice >= 0);

            return p_ICList[choice];
        }
        public Order ChooseClassFromList(List<Order> p_ICList){
            int choice = 0;
            bool repeat = false;
            Add("");
            Add("Enter number for your choice.",'b');
            do{
                try{
                    choice = GetInt();repeat = false;
                }
                catch (System.Exception){repeat = true; Add("Thats not a valid selection. Try again."); Pause();}
            } while (repeat && choice <= p_ICList.Count && choice >= 0);

            return p_ICList[choice];
        }
        public Customer ChooseClassFromList(List<Customer> p_ICList){
            int choice = 0;
            bool repeat = false;
            Add("");
            Add("Enter number for your choice.",'b');
            do{
                try{
                    choice = GetInt(); repeat = false;
                }
                catch (System.Exception){repeat = true; Add("Thats not a valid selection. Try again."); Pause(); }
            } while (repeat && choice <= p_ICList.Count && choice >= 1);

            return p_ICList[choice-1];
        }
        public Storefront ChooseClassFromList(List<Storefront> p_ICList){
            int choice = 0;
            bool repeat = false;
            Add("");
            Add("Enter number for your choice.",'b');
            do{
                try{
                    choice = GetInt();
                    repeat = false;
                }
                catch (System.Exception){repeat = true; Add("Thats not a valid selection. Try again."); Pause();}
            } while (repeat && choice <= p_ICList.Count && choice >= 0);

            return p_ICList[choice];
        }


        //Five overwritten methods to combine the above methods.
        public Order SearchAndSelect(Order p_IC){return ChooseClassFromList(Search(p_IC));}
        public LineItem SearchAndSelect(LineItem p_IC){return ChooseClassFromList(Search(p_IC));}
        public Product SearchAndSelect(Product p_IC){return ChooseClassFromList(Search(p_IC));}
        public Customer SearchAndSelect(Customer p_IC){return ChooseClassFromList(Search(p_IC));}
        public Storefront SearchAndSelect(Storefront p_IC){return ChooseClassFromList(Search(p_IC));}
    }
}