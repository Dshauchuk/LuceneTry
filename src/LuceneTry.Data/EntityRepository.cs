using Dapper;
using LuceneTry.Models;
using System.Data.SqlClient;

namespace LuceneTry.Data;

public class EntityRepository
{
    public async Task<IEnumerable<Entity>> GetAsync()
    {
        using var connection = new SqlConnection("Server=.\\SQLExpress;Database=GTRACS-NONPROD;Integrated Security=True;");
        await connection.OpenAsync();

        try
        {
            string sql = "select * from dbo.Tires";

            var result = await connection.QueryAsync<Entity>(sql);

            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }
}