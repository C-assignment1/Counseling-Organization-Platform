using Microsoft.Data.SqlClient;

public class DatabaseHelper
{
    private const string ConnectionString = 
        "Server=localhost;Database=CounselingDB;User Id=sa;Password=YourPassword;TrustServerCertificate=True;";

    public SqlConnection GetConnection() => new SqlConnection(ConnectionString);
}
