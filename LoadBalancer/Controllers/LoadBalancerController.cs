using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;

namespace LoadBalancer.Controllers;


[Route("[controller]")]
[ApiController]
public class LoadBalancerController : ControllerBase
{   
    
    private readonly ILoadBalancer _loadBalancer = LoadBalancer.LoadBalancer.getInstance();
    
    [HttpGet] 
    public async Task<string> Search(string terms, int numberOfResults)
    {
        var nextService = _loadBalancer.NextService();
        HttpClient api = new HttpClient();
        api.BaseAddress = new Uri(nextService);
        Console.WriteLine("Sending request to: " + nextService 
                                                 + $", using terms: {terms} and number of results: {numberOfResults}");
        Task<string> task = api.GetStringAsync("/Search?terms=" 
                                               + terms + "&numberOfResults=" 
                                               + numberOfResults);
        task.Wait();
        if (task.Result != null)
        {
            Console.WriteLine("I recieved this response: " + task.Result);
            return task.Result;
        }
        Console.WriteLine("I did not recieve an answer, I will now delete this service from the dictionary");
        return "something went wrong";
    }
    
    /*
    private readonly ILoadBalancer _loadBalancer = LoadBalancer.LoadBalancer.getInstance();

    [HttpGet]
    public IActionResult Search(string terms, int numberOfResults)
    {
        // Hent addresse (url: string)
        var nextServiceUrl = _loadBalancer.NextService();
        
        // Brug Service URL
        using HttpClient client = new();
        client.BaseAddress = new Uri(nextServiceUrl);
        Task<string> task = client.GetStringAsync("/search?terms" + terms + "&numberOfResulsts=" + numberOfResults);
        task.Wait();
        string searchResult = task.Result;
        return Ok(searchResult);
    }
    */
    [HttpGet(template: "DevTest2")]
    public string GetNextService()
    {
        return _loadBalancer.NextService();
    }
    [HttpGet(template:"DevTest")]
    public Dictionary<Guid, string> GetAllServices()
    {
        return _loadBalancer.GetAllServices();
    }
}