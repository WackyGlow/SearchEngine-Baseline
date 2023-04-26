using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleSearch
{
    public class App
    {
        public void Run()
        {
            HttpClient api = new HttpClient();
            HttpClient searchStatsApi = new HttpClient();
            api.BaseAddress = new Uri("http://localhost:9011");
            searchStatsApi.BaseAddress = new Uri("http://localhost:9012");
            //SearchLogic mSearchLogic = new SearchLogic(new Database());
            Console.WriteLine("Console Search");
            
            while (true)
            {
                Console.WriteLine("enter search terms - q for quit");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.Equals("q")) break;

                Task<string> task = api.GetStringAsync("/LoadBalancer?terms=" + input + "&numberOfResults=10");
                task.Wait();
                string resultString = task.Result;
                SearchResult result = JsonConvert.DeserializeObject<SearchResult>(resultString);

                var data = JObject.FromObject(new
                {
                    query = input
                });

                var searchStatsTask = searchStatsApi.PostAsync("/words",
                                  new StringContent(JsonConvert.SerializeObject(data),
                                  Encoding.UTF8, "application/json")).Result;
                

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
