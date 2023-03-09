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
    public string NextService(List<string> services)
    {
        if (_chosenStrategy == "roundrobin")
        {
            RoundRobin(services);
        } else if (_chosenStrategy == "leastconnection")
        {
            LeastConnection(services);
        }
        return services[_serviceCounter];
    }

    public string RoundRobin(List<string> services)
    {
        int index = _serviceCounter % services.Count;
        string nextService = services[index];

        if (_serviceCounter !> services.Count - 1)
        {
            _serviceCounter = 0;
        }
        _serviceCounter++;
        return nextService;
    }

    public string LeastConnection(List<string> services)
    {
        throw new NotImplementedException();
    }
}