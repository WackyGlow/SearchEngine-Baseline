using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Services;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class LoadBalancerController : ControllerBase
{
    private readonly ILoadBalancer _loadBalancer = LoadBalancer.LoadBalancer.getInstance();
    
    [HttpGet] 
    public async Task<string> Search(string terms, int numberOfResults)
    {
        var nextService = _loadBalancer.NextService();
        HttpClient api = new HttpClient();
        api.BaseAddress = new Uri(nextService);
        Task<string> task = api.GetStringAsync("/Search?terms=" + terms + "&numberOfResults=" + numberOfResults);
        task.Wait();
        if (task.Result == null)
        {
            return new Exception("You done goofed").Message;
        }
        return task.Result;
    }

    [HttpGet(template:"DevTest")]
    public List<string> GetAllServices()
    {
        return _loadBalancer.GetAllServices();
    }
}