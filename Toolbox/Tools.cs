using System;
using System.Collections.Generic;
using Models;
using BusinessLogic;

/* For now this makes pretty menus out of List<strings>
*/

namespace Toolbox
{
    //This set of methods builds the visuals out of a List<string>
    //There are cases for when a string is too long
    public class Tools
    {

        List<string> menulines = new List<string>();
    
        public void BuildMenu()
        {
            Console.WriteLine("\x1b[3J"); //This should clear the scrollback buffer?
            Console.Clear();
            //menulines typically = title, go back, first, second, third options
            //try catch for a string thats too long and needs to get split by spaces. 
            Console.WriteLine(@"   ___________________________________     ");
            Console.WriteLine(@" / \                                  \.   ");
            Console.WriteLine(@" \_ |                                 |.   ");
            foreach( string line in menulines)
            {
                try{Console.WriteLine($"    |   {line}{new string(' ', 30-line.Length)}|.   ");}
                catch (System.Exception){foreach(string subline in line.Split(' ')){
                        Console.WriteLine($"    |   {subline}{new string(' ', 30-subline.Length)}|.   ");
                    }
                }
            } 
            Console.WriteLine(@"    |                                 |.   "); 
            Console.WriteLine(@"    |                                 |.   "); 
            Console.WriteLine(@"    |   ______________________________|___ ");
            Console.WriteLine(@"    |  /                                 /.");
            Console.WriteLine(@"    \_/_________________________________/. ");

        }

        public bool Choice()
        {
            bool TorF = true;
            bool chooseagain = false;

            do{
                char YorN = Char.ToLower(Convert.ToChar(Console.ReadLine().Substring(0, 1)));
                switch(YorN){
                    case 'y': case 'a': case '1': TorF = true;  chooseagain = false; break;
                    case 'n': case 'b': case '2': TorF = false; chooseagain = false; break;
                    default:
                        Add("Can't interpret answer. Y/N only.");
                        Add("Choose again:\n");
                        chooseagain = true;
                        break;
                }
            }while(chooseagain);

            return TorF;

        }
        

        public void Add(string s){ //no BuildMenu for single lines.
            menulines.Add(s);
        }
        public void Add(string s, char b){ //char b is just an overloading flag that puts a BuildMenu in the Add.
            menulines.Add(s);
            BuildMenu();
        }
        public void Add(List<string> ls){
            foreach(string s in ls){Add(s);}
            BuildMenu();
        }
        public void Reset(){
            menulines = new List<string>();
            BuildMenu();
        }
        public void Reset(List<string> ls){
            menulines = ls;
            BuildMenu();
        }


        public List<Customer> Search(Customer p_IC){
            
            bool repeat = true;
            IBusiness BL = new Business();
            List<Customer> SelectC = new List<Customer>();
            do
            {   
                Add(" ");
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add(" ");
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(Customer c in SelectC){
                        cnt++;
                        Add(" ");
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add(" ");
                    Add(" ");
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
                Add(" ");
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add(" ");
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(Storefront c in SelectC){
                        cnt++;
                        Add(" ");
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add(" ");
                    Add(" ");
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
                Add(" ");
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add(" ");
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(Order c in SelectC){
                        cnt++;
                        Add(" ");
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add(" ");
                    Add(" ");
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
                Add(" ");
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add(" ");
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(LineItem c in SelectC){
                        cnt++;
                        Add(" ");
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add(" ");
                    Add(" ");
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
                Add(" ");
                Add($"Search {p_IC.Identify()}s:",'B');
                string entered = Console.ReadLine();
                Add(entered);

                SelectC = BL.SearchClass(p_IC, entered);

                if(SelectC.Count == 0){Add("No results."); repeat = true;}
                else{
                    Add(" ");
                    Add($" Showing {p_IC.Identify()}s");
                    int cnt = 0;
                    foreach(Product c in SelectC){
                        cnt++;
                        Add(" ");
                        Add($"[{cnt}] --------------------");
                        Add(c.ToStringList());
                    }
                    Add(" ");
                    Add(" ");
                    Add("Do you want to search again?", 'b');
                    repeat = Choice();
                }

            } while (repeat);
            return SelectC;
        }




        public void ShowAll(Customer p_IC){
            IBusiness BL = new Business();
            List<Customer> AllIC = BL.GetAllClasses(p_IC);
            Add($"Show all {p_IC.Identify()}s,");
            foreach(Customer ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
        }
        public void ShowAll(Storefront p_IC){
            IBusiness BL = new Business();
            List<Storefront> AllIC = BL.GetAllClasses(p_IC);
            Add($"Show all {p_IC.Identify()}s,");
            foreach(Storefront ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
        }
        public void ShowAll(Order p_IC){
            IBusiness BL = new Business();
            List<Order> AllIC = BL.GetAllClasses(p_IC);
            Add($"Show all {p_IC.Identify()}s,");
            foreach(Order ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
        }
        public void ShowAll(LineItem p_IC){
            IBusiness BL = new Business();
            List<LineItem> AllIC = BL.GetAllClasses(p_IC);
            Add($"Show all {p_IC.Identify()}s,");
            foreach(LineItem ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
        }
        public void ShowAll(Product p_IC){
            IBusiness BL = new Business();
            List<Product> AllIC = BL.GetAllClasses(p_IC);
            Add($"Show all {p_IC.Identify()}s,");
            foreach(Product ic in AllIC){
                Add(ic.ToStringList());
                Add("  ----------  ");
            }
        }

        public Product ChooseClassFromList(List<Product> p_ICList){
            int choice = 0;
            bool repeat = false;
            Add("");
            Add("Enter number for your choice.",'b');
            do{
                try{
                    choice = Int32.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch (System.Exception){repeat = true; Console.WriteLine("Thats not a valid selection. Try again.");}
            } while (repeat && choice <= p_ICList.Count && choice >= 0);

            return p_ICList[choice];
        }
        public LineItem ChooseClassFromList(List<LineItem> p_ICList){
            int choice = 0;
            bool repeat = false;
            Add("");
            Add("Enter number for your choice.",'b');
            do{
                try{
                    choice = Int32.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch (System.Exception){repeat = true; Console.WriteLine("Thats not a valid selection. Try again.");}
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
                    choice = Int32.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch (System.Exception){repeat = true; Console.WriteLine("Thats not a valid selection. Try again.");}
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
                    choice = Int32.Parse(Console.ReadLine()); repeat = false;}
                catch (System.Exception){
                    Console.WriteLine("Thats not a valid selection. Try again."); repeat = true;}
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
                    choice = Int32.Parse(Console.ReadLine());
                    repeat = false;
                }
                catch (System.Exception){repeat = true; Console.WriteLine("Thats not a valid selection. Try again.");}
            } while (repeat && choice <= p_ICList.Count && choice >= 0);

            return p_ICList[choice];
        }
    }
}


//Console.WriteLine(string.Join(",", s.GetRange(i,m)));