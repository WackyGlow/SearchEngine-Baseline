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
    public Task<SearchResult> SendToNextApi(Task<SearchResult> input)
    {
        var nextService = _loadBalancer.NextService();


        return null;
    }
}