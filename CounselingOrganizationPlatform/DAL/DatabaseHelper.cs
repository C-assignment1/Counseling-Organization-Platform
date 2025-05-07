using System;
using System.Data.SqlClient;

namespace CounselingOrganizationPlatform.DAL
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
