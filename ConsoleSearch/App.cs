﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

namespace ConsoleSearch
{
    public class App
    {
        public void Run()
        {
            HttpClient api = new HttpClient();
            api.BaseAddress = new Uri("http://localhost:5171");
            //SearchLogic mSearchLogic = new SearchLogic(new Database());
            Console.WriteLine("Console Search");
            
            while (true)
            {
                Console.WriteLine("enter search terms - q for quit");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.Equals("q")) break;

                Task<string> task = api.GetStringAsync("/Search?terms=" + input + "&numberOfResults=10");
                task.Wait();
                string resultString = task.Result;
                SearchResult result = JsonConvert.DeserializeObject<SearchResult>(resultString);

                foreach (var ignored in result.IgnoredTerms)
                {
                    Console.Write(ignored +  "was ignored");
                }

                foreach (var resltDocument in result.Documents)
                {
                    Console.WriteLine(resltDocument.Id + ": " + resltDocument.Path + " - number of terms found: " + resltDocument.NumberOfOccurrences);
                }
                
                Console.WriteLine("Found " + result.Documents.Count + " in " + result.ElapsedMilliseconds + " ms");

            }
        }
    }
}
