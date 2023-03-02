using Microsoft.AspNetCore.Mvc;
using LoadBalancer.LoadBalancer;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceRegController : ControllerBase
{

    private readonly ILoadBalancer _loadBalancer = LoadBalancer.LoadBalancer.getInstance();
    
    [HttpPost]
    public void RegisterApiService(string url)
    {
        _loadBalancer.AddService(url);
    }
}