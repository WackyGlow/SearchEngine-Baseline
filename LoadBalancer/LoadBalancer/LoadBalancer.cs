using Microsoft.AspNetCore.Http.HttpResults;

namespace LoadBalancer.LoadBalancer;

public class LoadBalancer : ILoadBalancer

{
    private static ILoadBalancer instance;
    private Dictionary<Guid, string> _services;
    private List<string> serviceUrlList;
    private LoadBalancer()
    {
        _services = new Dictionary<Guid, string>();
        serviceUrlList = new List<string>();
        
    }

    public static ILoadBalancer getInstance()
    {
        if (instance == null)
        {
            instance = new LoadBalancer();
        }

        return instance;
    }
    
    public Dictionary<Guid, string> GetAllServices()
    {
        return _services;
    }

    public Guid AddService(string url)
    {
        var id = Guid.NewGuid();
        _services.Add(id,url);
        return id;
    }
    

    public Guid RemoveService(Guid id)
    {
        _services.Remove(id);
        return id;
    }

    public ILoadBalancerStrategy GetActiveStrategy()
    {
       return LoadBalancerStrategy.GetInstance();
    }
    
    public void SetActiveStrategy(ILoadBalancerStrategy strategy, string newStrategy)
    {
        strategy.SetActiveStrategy(newStrategy);
    }

    public string NextService()
    {
        return LoadBalancerStrategy.GetInstance().NextService(GetAllServices());
    }
}