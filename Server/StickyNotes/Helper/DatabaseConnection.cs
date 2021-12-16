namespace StickyNotes.Helper
{
    public class DatabaseConnection : IDatabaseConnection
    {
        private readonly IConfiguration _configuration;

        public DatabaseConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SqlServerConnection => _configuration.GetConnectionString("SqlServerConnection");
    }
}
