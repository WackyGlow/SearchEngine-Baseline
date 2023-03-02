using Microsoft.AspNetCore.Mvc;
using LoadBalancer.LoadBalancer;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceRegController : ControllerBase
{
    private readonly ILoadBalancer _loadBalancer;
    
    [HttpPost]
    public void registerApiService(string url)
    {
        _loadBalancer.AddService(url);
    }
}