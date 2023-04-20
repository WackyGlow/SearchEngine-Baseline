using SearchStatistics.DatabaseFolder;
using SearchStatistics.Models;
using SearchStatistics.Services.Interfaces;

namespace SearchStatistics.Services.Implementations
{
    public class TopSearchedWords : ITopSearchedWords<SearchWord>
    {
        private Database mDatabase;
        private readonly char[] sep = " \\\n\t\"$'!,?;.:-_**+=)([]{}<>/@&%€#".ToCharArray();

        public TopSearchedWords(Database database)
        {
            mDatabase = database;
        }

        public List<SearchWord> Get(int? amount, string order)
        {
            if (!amount.HasValue)
                amount = 10;

            if (order == null || !order.ToLower().Equals("ascending"))
                order = "DESC";
            else
                order = "ASC";

            return mDatabase.Get(amount, order);
        }

        public List<SearchWord> GetAll()
        {
            return mDatabase.GetAllWords();
        }

        public void Post(string query)
        {
            foreach (var word in query.Split(sep, StringSplitOptions.RemoveEmptyEntries))
            {
                mDatabase.insertOrUpdateWord(word);
            }
        }
    }
}
