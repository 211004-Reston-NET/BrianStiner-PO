using System;

namespace UserInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeat = true;
            IFactory factory = new Factory();
            IMenu page = factory.GetMenu(MenuType.Main);

            while (repeat)
            {
                Console.Clear();
                if(page != new RealExitMenu()){
                    page.Display();
                    page = factory.GetMenu(page.Choice());
                }else{
                    page.Display();
                    repeat = false;
                }
            }
        }
    }
}