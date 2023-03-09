﻿namespace LoadBalancer.LoadBalancer;

public interface ILoadBalancer
{
    public Dictionary<Guid, string> GetAllServices();
    public Guid AddService(string url);
    public Guid RemoveService(Guid id);
    public ILoadBalancerStrategy GetActiveStrategy();
    public void SetActiveStrategy(ILoadBalancerStrategy strategy, string newStrategy);
    public string NextService();
}