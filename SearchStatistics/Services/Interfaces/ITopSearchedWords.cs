namespace SearchStatistics.Services.Interfaces
{
    public interface ITopSearchedWords<T>
    {
        List<T> GetAll();
        List<T> Get(int? amount, string? order);
        void Post(string query);
    }
}
