using Microsoft.AspNetCore.Mvc;
using LoadBalancer.LoadBalancer;
using Microsoft.AspNetCore.Authorization;

namespace LoadBalancer.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceRegController : ControllerBase
{

    private readonly ILoadBalancer _loadBalancer = LoadBalancer.LoadBalancer.getInstance();
    [HttpPost]
    public void RegisterApiService([FromQuery]string url)
    {
        LoadBalancer.LoadBalancer.getInstance().AddService(url);
    }
}