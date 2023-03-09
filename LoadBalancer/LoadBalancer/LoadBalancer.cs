using Microsoft.AspNetCore.Http.HttpResults;

namespace LoadBalancer.LoadBalancer;

public class LoadBalancer : ILoadBalancer

{
    private static ILoadBalancer instance;
    private List<string> serviceUrlList;
    private LoadBalancer()
    {
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
    
    public List<string> GetAllServices()
    {
        throw new NotImplementedException();
    }

    public int AddService(string url)
    {
        serviceUrlList.Add(url);
        return 200;
    }

    public int RemoveService(int id)
    {
        throw new NotImplementedException();
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