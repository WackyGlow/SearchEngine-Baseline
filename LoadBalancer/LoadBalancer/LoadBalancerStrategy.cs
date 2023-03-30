namespace LoadBalancer.LoadBalancer;

public class LoadBalancerStrategy : ILoadBalancerStrategy
{
    private int _serviceCounter = 0;
    private string _chosenStrategy = "roundrobin";
    private static ILoadBalancerStrategy instance;

    public static ILoadBalancerStrategy GetInstance()
    {
        if (instance == null)
        {
            instance = new LoadBalancerStrategy();
        }

        return instance;
    }
    
    private LoadBalancerStrategy()
    {
        
    }
    public string GetActiveStrategy()
    {
        return _chosenStrategy;
    }
    public string SetActiveStrategy(string newStrategy)
    {
        _chosenStrategy = newStrategy.ToLower();
        return _chosenStrategy + "is now the chosen strategy";
    }
    public string NextService(Dictionary<Guid,string> services)
    {
        if (services.Count == 0)
        {
            return "No Available Services";
        }
        if (_chosenStrategy == "roundrobin")
        {
            RoundRobin(services);
        } else if (_chosenStrategy == "leastconnection")
        {
            LeastConnection(services);
        }
        else
        {
            RoundRobin(services);
        }
        return services.ElementAt(_serviceCounter).Value;
    }

    public string RoundRobin(Dictionary<Guid, string> services)
    {
        // If there are no services available, return null.
        if (services.Count == 0)
        {
            return null;
        }
        // Get the service at the current index.
        var nextService = services.ElementAt(_serviceCounter);
        
        // Increment the index and wrap around if it goes beyond the last index.
        _serviceCounter = (_serviceCounter + 1) % services.Count;
        
        return nextService.Value;
    }

    public string LeastConnection(Dictionary<Guid, string> services)
    {
        throw new NotImplementedException();
    }
}