namespace LoadBalancer.LoadBalancer;

public interface ILoadBalancerStrategy
{

    public string NextService(List<string> services);

    public Task<string> RoundRobin();

    public Task<string> IpHash();
}