namespace LoadBalancer.LoadBalancer;

public interface ILoadBalancerStrategy
{

    public string GetActiveStrategy();

    public string SetActiveStrategy(string newStrategy);

    public string NextService(List<string> services);

    public string RoundRobin(List<string> services);

    public string LeastConnection(List<string> services);
}