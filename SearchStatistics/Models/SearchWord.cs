namespace SearchStatistics.Models
{
    public class SearchWord
    {
        public SearchWord(int id, string word, int count) {
            Id = id;
            Word = word;
            Count = count;
        }

        public int Id { get; private set; }
        public string Word { get; private set; }
        public int Count { get; private set; }
    }
}
