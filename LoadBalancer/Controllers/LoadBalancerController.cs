using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class LoadBalancerController : ControllerBase
{
    private readonly ILoadBalancer _loadBalancer;
    
    [HttpGet] 
    public async Task<string> Search(string terms, int numberOfResults)
    {
        var nextService = _loadBalancer.NextService();
        HttpClient api = new HttpClient();
        api.BaseAddress = new Uri(nextService);
        Task<string> task = api.GetStringAsync("/Search?terms=" + terms + "&numberOfResults=" + numberOfResults);
        task.Wait();
        return task.Result;
    }
}