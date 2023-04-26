namespace Common
{
    public static class Config
    {
        public static string DatabasePath { get; } = "/data/database.db";
        public static string DataSourcePath { get; } = "/data/source";
        public static string SearchStatisticsDB { get; } = "/data/searchStats.db";

        //public static string DatabasePath { get; } = "/DLS/database.db";
        //public static string DataSourcePath { get; } = "/DLS/source";
        //public static string SearchStatisticsDB { get; } = "/DLS/searchStats.db";
        public static int NumberOfFoldersToIndex { get; } = 10; // Use 0 or less for indexing all folders
    }
}