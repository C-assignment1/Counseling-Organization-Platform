using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

public class AuthService
{
    public async Task<bool> RegisterAsync(string name, string email, string password, string role)
    {
        using var conn = new DatabaseHelper().GetConnection();
        await conn.OpenAsync();
        // TODO: Implement async registration logic here, e.g., insert user into database
        return true;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        using var conn = new DatabaseHelper().GetConnection();
        await conn.OpenAsync();
        // TODO: Implement async login logic here, e.g., verify user credentials
        return true;
    }
}
