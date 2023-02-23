namespace Common
{
    public static class Config
    {
        public static string DatabasePath { get; } = "/Users/stamp/DLS/database.db";
        public static string DataSourcePath { get; } = "/Users/stamp/Downloads/EnronMini";
        public static int NumberOfFoldersToIndex { get; } = 10; // Use 0 or less for indexing all folders
    }
}