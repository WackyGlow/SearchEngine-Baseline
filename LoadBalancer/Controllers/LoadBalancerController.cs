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
    public async Task<SearchResult> Search(string terms, int numberOfResults)
    {
        var nextService = _loadBalancer.NextService();
        HttpClient api = new HttpClient();
        api.BaseAddress = new Uri(nextService);
        api.GetAsync("/Search?terms=" + terms + numberOfResults);
        return null;
    }
}