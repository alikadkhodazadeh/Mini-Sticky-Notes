namespace BookStore.Common
{
    public static class AppSettingExtentions
    {
        public static IConfiguration? Configuration { get; private set; }
        public static string? DatabaseConnection { get; private set; }

        public static void AddAppSettings(this IConfiguration configuration)
        {
            Configuration = configuration
                ?? throw new ArgumentNullException();

            DatabaseConnection = configuration.GetConnectionString("DatabaseConnection")
                ?? throw new ArgumentNullException();
        }

        public static string GetByKey(string key)
        {
            return Configuration?[key]
                ?? throw new ArgumentNullException();
        }
    }
}
