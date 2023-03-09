namespace LoadBalancer.LoadBalancer;

public interface ILoadBalancer
{
    public List<string> GetAllServices();
    public int AddService(string url);
    public int RemoveService(int id);
    public ILoadBalancerStrategy GetActiveStrategy();
    public void SetActiveStrategy(ILoadBalancerStrategy strategy, string newStrategy);
    public string NextService();
}