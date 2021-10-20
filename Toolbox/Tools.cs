using System;
using System.Collections.Generic;

/* For now this makes pretty menus out of List<strings>
*/

namespace Toolbox
{
    //Access the json files where data is stored.
    public class Tools
    {

        List<string> menulines = new List<string>();
    
        public void BuildMenu(List<string> p_menulines)
        {
            Console.WriteLine("\x1b[3J"); //This should clear the scrollback buffer?
            Console.Clear();
            //menulines typically = title, go back, first, second, third options
            //try catch for a string thats too long and needs to get split by spaces. 
            Console.WriteLine(@"   ___________________________________     ");
            Console.WriteLine(@" / \                                  \.   ");
            Console.WriteLine(@" \_ |                                 |.   ");
            foreach( string line in p_menulines)
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
                char YorN = Char.ToLower(Convert.ToChar(Console.Read()));
                switch(YorN){
                    case 'y': case 'a': case '1': TorF = true;  chooseagain = false; break;
                    case 'n': case 'b': case '2': TorF = false; chooseagain = false; break;
                    default:
                        Console.WriteLine("Can't interpret answer. Y/N only.");
                        Console.WriteLine("Choose again:");
                        chooseagain = true;
                        break;
                }
            }while(chooseagain);

            return TorF;

        }
        /*
        public bool BuildSearchResult(List<IClass> p_ICList) {  
            if(p_ICList.Count == 0){menulines.Add("No search results."); return true;}
                else{
                    menulines.Add("Show searched Customers");
                    int cnt = 0;
                    foreach(IClass IC in p_ICList){
                        cnt++;
                        menulines.Add($"[{cnt}]--------------------");
                        foreach(string s in c.ToStringList()){
                            menulines.Add("  "+s);
                        }
                    }
                    return false;
                }
        }*/
    }
}


//Console.WriteLine(string.Join(",", s.GetRange(i,m)));