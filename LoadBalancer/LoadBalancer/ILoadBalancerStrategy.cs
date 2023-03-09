namespace LoadBalancer.LoadBalancer;

public interface ILoadBalancerStrategy
{

    public string GetActiveStrategy();

    public string SetActiveStrategy(string newStrategy);

    public string NextService(Dictionary<Guid, string> services);

    public string RoundRobin(Dictionary<Guid, string> services);

    public string LeastConnection(Dictionary<Guid, string> services);
}