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
        //MAY NOT WORK! progably...
        // Initialize variables
        List<Service> _services = new List<Service>();
        int minConnections = int.MaxValue;
        List<Service> list = new List<Service>();
        
        // Find the services with the minimum number of connections
        foreach(var service in _services) {
            if(service.Connections < minConnections)
            {
                // If a new minimum is found, clear the list of services with the previous minimum
                minConnections = service.Connections;
                list.Clear();
            }
            
            // Add the current service to the list of services with the current minimum
            if (service.Connections == minConnections) {
                list.Add(service);
            }
        }
        
        // Choose a random service from the list of services with the current minimum
        var random = new Random();
        int index = random.Next(list.Count);
        var chosenService = list[index];

        // Increment the number of connections for the chosen service
        foreach (var service in _services) {
            if (service.Url.Equals(chosenService.Url))
            {
                service.Connections++;
            }
        }
        
        // Output the service that was used and the number of connections it now has
        Console.WriteLine("Used service:" + chosenService.Url + " Connections: " + chosenService.Connections);

        // Return the URL of the chosen service
        return chosenService.Url;
    }
}