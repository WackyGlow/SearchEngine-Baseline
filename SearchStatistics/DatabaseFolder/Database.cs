using Microsoft.Data.Sqlite;
using Common;
using SearchStatistics.Models;

namespace SearchStatistics.DatabaseFolder
{
    public class Database
    {
        private SqliteConnection _connection;

        public Database()
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.Mode = SqliteOpenMode.ReadWriteCreate;
            connectionStringBuilder.DataSource = Config.SearchStatisticsDB;

            _connection = new SqliteConnection(connectionStringBuilder.ConnectionString);
            _connection.Open();

            Execute("CREATE TABLE IF NOT EXISTS searchedWord(id INTEGER PRIMARY KEY, word TEXT, count INTEGER)");
        }
        private void Execute(string sql)
        {
            var cmd = _connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public List<SearchWord> GetAllWords()
        {
            var res = new List<SearchWord>();

            var sql = "SELECT * FROM searchedWord ;";

            var selectCmd = _connection.CreateCommand();
            selectCmd.CommandText = sql;

            using (var reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var word = reader.GetString(1);
                    var count = reader.GetInt32(2);

                    res.Add(new SearchWord(id, word, count));
                }
            }

            return res;
        }

        public List<SearchWord> Get(int? amount, string? order)
        {
            var res = new List<SearchWord>();

            var sql = "SELECT * " +
                      "FROM searchedWord " +
                      "ORDER BY count " + order + " " +
                      "LIMIT " + amount + ";";

            var selectCmd = _connection.CreateCommand();
            selectCmd.CommandText = sql;

            using (var reader = selectCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var word = reader.GetString(1);
                    var count = reader.GetInt32(2);

                    res.Add(new SearchWord(id, word, count));
                }
            }

            return res;
        }

        public void insertOrUpdateWord(string word)
        {
            if (wordExistInDB(word))

                updateWordCountInDB(word);
            else
                insertWordInDB(word);

        }

        private bool wordExistInDB(string word)
        {
            var sql = "SELECT word " +
                      "FROM searchedWord " +
                      "WHERE word = '" + word + "' " +
                      "LIMIT 1;";

            var selectCmd = _connection.CreateCommand();
            selectCmd.CommandText = sql;
            var reader = selectCmd.ExecuteReader();

            if (reader.HasRows)
                return true;
            else
                return false;
        }

        private void insertWordInDB(string word)
        {
            Execute("INSERT INTO searchedWord (word, count) VALUES ('" + word + "', 1) ;");
        }

        private void updateWordCountInDB(string word)
        {
            Execute("UPDATE searchedWord " +
                    "SET count = count + 1 " +
                    "WHERE word = '" + word + "'; ");
        }
    }
}
