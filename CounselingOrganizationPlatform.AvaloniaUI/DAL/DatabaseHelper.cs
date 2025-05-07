using System;
using Microsoft.Data.SqlClient;

namespace CounselingOrganizationPlatform.AvaloniaUI.DAL
{
    public class DatabaseHelper
    {
        private string connectionString = "Server=YOUR_SERVER;Database=YourDatabase;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
