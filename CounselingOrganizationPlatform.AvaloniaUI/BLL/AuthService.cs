using System;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using CounselingOrganizationPlatform.AvaloniaUI.DAL;

namespace CounselingOrganizationPlatform.AvaloniaUI.BLL
{
    public class AuthService
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        public bool RegisterUser(string name, string email, string password, string role)
        {
            string hashedPassword = HashPassword(password);
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Users (Name, Email, PasswordHash, Role) VALUES (@Name, @Email, @PasswordHash, @Role)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@Role", role);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Login(string email, string password)
        {
            using (SqlConnection conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT PasswordHash FROM Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    var storedHash = cmd.ExecuteScalar()?.ToString();
                    return VerifyPassword(password, storedHash);
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHash)
        {
            return HashPassword(enteredPassword) == storedHash;
        }
    }
}
