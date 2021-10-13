using System;
using System.Collections.Generic;

/* The logic to perform CRUD operations on the models.
Contains repository specific logic on storing and accessing data
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

            Console.WriteLine(@"   ______________________________     ");
            Console.WriteLine(@" / \                             \.   ");
            Console.WriteLine(@" \_ |                            |.   ");
            foreach( string line in p_menulines)
            {
            line.PadRight(26-line.Length, ' ');
            Console.WriteLine($"    |   {line}|.   ");
            } 
            Console.WriteLine(@"    |                            |.   "); 
            Console.WriteLine(@"    |                            |.   "); 
            Console.WriteLine(@"    |   _________________________|___ ");
            Console.WriteLine(@"    |  /                            /.");
            Console.WriteLine(@"    \_/____________________________/. ");

        }

    }
}