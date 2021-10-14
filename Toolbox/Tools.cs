using System;
using System.Collections.Generic;

/* For now this makes pretty menus out of List<strings>
*/

namespace Toolbox
{
    //Access the json files where data is stored.
    public class Tools
    {
    
        public void BuildMenu(List<string> p_menulines)
        {
            Console.Clear();
            //menulines typically = title, go back, first, second, third options 

            Console.WriteLine(@"   ___________________________________     ");
            Console.WriteLine(@" / \                                  \.   ");
            Console.WriteLine(@" \_ |                                 |.   ");
            foreach( string line in p_menulines)
            {
            Console.WriteLine($"    |   {line}{new string(' ', 30-line.Length)}|.   ");
            } 
            Console.WriteLine(@"    |                                 |.   "); 
            Console.WriteLine(@"    |                                 |.   "); 
            Console.WriteLine(@"    |   ______________________________|___ ");
            Console.WriteLine(@"    |  /                                 /.");
            Console.WriteLine(@"    \_/_________________________________/. ");

        }

    }
}