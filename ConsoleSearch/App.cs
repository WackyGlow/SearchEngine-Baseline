using System;
using System.Collections.Generic;

namespace ConsoleSearch
{
    public class App
    {
        public void Run()
        {
            //SearchLogic mSearchLogic = new SearchLogic(new Database());
            Console.WriteLine("Console Search");
            
            while (true)
            {
                Console.WriteLine("enter search terms - q for quit");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.Equals("q")) break;


            }
        }
    }
}
