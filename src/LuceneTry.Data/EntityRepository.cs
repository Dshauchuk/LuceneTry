using Dapper;
using LuceneTry.Models;
using System.Data.SqlClient;
using System.Diagnostics;

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
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }

    public async Task<bool> AddAsync(IEnumerable<Entity> entities)
    {
        using var connection = new SqlConnection("Server=.\\SQLExpress;Database=LuceneTryDb;Integrated Security=True;");
        await connection.OpenAsync();

        try
        {
            string sql = "insert into dbo.Entities " +
                "(StringField1" +
                ",StringField2" +
                ",StringField3" +
                ",StringField4" +
                ",StringField5" +
                ",StringField6" +
                ",StringField7" +
                ",StringField8" +
                ",StringField9" +
                ",StringField10" +
                ",IntField1" +
                ",IntField2" +
                ",IntField3" +
                ",IntField4" +
                ",IntField5) " +
                "values" +
                "(@StringField1" +
                ",@StringField2" +
                ",@StringField3" +
                ",@StringField4" +
                ",@StringField5" +
                ",@StringField6" +
                ",@StringField7" +
                ",@StringField8" +
                ",@StringField9" +
                ",@StringField10" +
                ",@IntField1" +
                ",@IntField2" +
                ",@IntField3" +
                ",@IntField4" +
                ",@IntField5)";

            var result = await connection.ExecuteAsync(sql, entities);

            return result > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }

    public async Task<bool> DeleteAsync()
    {
        using var connection = new SqlConnection("Server=.\\SQLExpress;Database=LuceneTryDb;Integrated Security=True;");
        await connection.OpenAsync();

        try
        {
            string sql = "delete from dbo.Entities";

            var result = await connection.ExecuteAsync(sql);

            return result > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            throw;
        }
    }
}